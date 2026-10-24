param([Parameter(Mandatory=$true)][string]$QueryFile,[string]$OutputDirectory="sql-results")
$ErrorActionPreference = 'Stop'
if (-not (Test-Path $QueryFile)) { throw "Query file not found" }
$query = [IO.File]::ReadAllText((Resolve-Path $QueryFile))
# Allow a single SELECT or WITH ... SELECT. No batches, comments or mutation keywords.
$clean = [regex]::Replace($query, '(?s)/\*.*?\*/|--[^\r\n]*', '')
$clean = $clean.Trim().TrimEnd(';').Trim()
if ($clean -notmatch '^(?i:SELECT|WITH)\s' -or $clean -match '(?i)\b(INSERT|UPDATE|DELETE|MERGE|DROP|ALTER|CREATE|TRUNCATE|EXEC(?:UTE)?|GRANT|REVOKE|DENY|BACKUP|RESTORE|INTO|OPENROWSET|OPENDATASOURCE|xp_cmdshell)\b' -or $clean -match ';') {
    throw 'Query rejected: only one read-only SELECT statement is allowed'
}
$server = $env:ANCO1_SQL_SERVER; $database = $env:ANCO1_SQL_DATABASE
$user = $env:ANCO1_SQL_USER; $password = $env:ANCO1_SQL_PASSWORD
if (!$server -or !$database -or !$user -or !$password) { throw 'Missing ANCO1_SQL_* configuration' }
Add-Type -AssemblyName System.Data
$builder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$builder['Data Source']=$server; $builder['Initial Catalog']=$database
$builder['User ID']=$user; $builder['Password']=$password
$builder['Encrypt']=$true; $builder['Trust Server Certificate']=$false
$builder['Connect Timeout']=15; $builder['Application Name']='Anco1-ReadOnly-Actions'
$connection=New-Object System.Data.SqlClient.SqlConnection($builder.ConnectionString)
try {
    $connection.Open()
    $cmd=$connection.CreateCommand()
    $cmd.CommandText=$clean; $cmd.CommandTimeout=45
    $transaction=$connection.BeginTransaction([System.Data.IsolationLevel]::ReadCommitted)
    $cmd.Transaction=$transaction
    try {
        $reader=$cmd.ExecuteReader()
        $table=New-Object System.Data.DataTable
        $table.Load($reader)
        if ($table.Rows.Count -gt 500) { throw 'Result exceeds 500 rows; narrow the query' }
        New-Item -ItemType Directory -Force -Path $OutputDirectory | Out-Null
        $target=Join-Path $OutputDirectory 'result.csv'
        $headers=@($table.Columns | ForEach-Object { '"' + $_.ColumnName.Replace('"','""') + '"' })
        $lines=New-Object 'System.Collections.Generic.List[string]'
        $lines.Add(($headers -join ','))
        foreach ($row in $table.Rows) {
            $values=@(foreach ($col in $table.Columns) {
                $v=if ($row.IsNull($col)) { '' } else { [string]$row[$col] }
                '"' + $v.Replace('"','""') + '"'
            })
            $lines.Add(($values -join ','))
        }
        [IO.File]::WriteAllLines((Join-Path (Resolve-Path $OutputDirectory) 'result.csv'),$lines,[Text.UTF8Encoding]::new($true))
        Write-Host "Read-only query succeeded. Rows: $($table.Rows.Count)."
    } finally { $transaction.Rollback() }
} finally { $connection.Dispose() }
