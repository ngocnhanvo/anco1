# Anco1 — SQL Server read-only via GitHub-hosted Actions

**Chosen setup (2026-10-24): GitHub-hosted Windows runner**, no software installation on the VPS. The VPS hosts the Anco1 SQL Server database.

## Minimum configuration

1. GitHub `ngocnhanvo/anco1` > **Settings > Secrets and variables > Actions > New repository secret**. Create:
   - `ANCO1_SQL_SERVER`: a *publicly reachable* DNS name or IP, including TCP port if non-default, e.g. `tcp:db.example.com,1433` (example only).
   - `ANCO1_SQL_DATABASE`: database name.
   - `ANCO1_SQL_USER`: dedicated SQL Authentication login with SELECT permissions only.
   - `ANCO1_SQL_PASSWORD`: that login's password.
2. On SQL Server, verify TCP/IP is enabled and the configured port is reachable **from a GitHub-hosted runner**. An IP alone is NOT a network tunnel: if the SQL Server is firewalled/private, the connection will fail.
3. Restrict firewall access to trusted source addresses wherever possible. **Do not open port 1433 unrestricted to the public internet as the default solution**. GitHub-hosted runner outbound IP addresses vary; GitHub does not recommend trying to maintain its large dynamic IP list manually. If this VPS currently has SQL private-only, prefer the **self-hosted runner or an outbound-only private tunnel** rather than weakening its firewall.
4. Current temporary setting approved by owner: `Encrypt=True;TrustServerCertificate=True` for the VPS's certificate. The connection is encrypted, but the server certificate is not validated. Install a trusted SQL Server certificate and restore `TrustServerCertificate=False` when possible.
5. Go to **Actions > Anco1 - remote SQL read-only inspection > Run workflow**. Choose `sql/inspect-packaging-schema.sql`. On success download `anco1-sql-inspection` artifact (`result.csv`, one-day retention).

## Protections / caveats

- The query runs on `windows-latest` using the secrets only; no runner registration / Windows VPS service needed.
- Trigger: manual `workflow_dispatch` only, one approved source-controlled query file, no arbitrary text query input.
- Client rejects multiple statements and obvious mutation keywords, limits result rows to 500, and command execution to 45s. **Client-side text filtering is not a SQL security boundary**. Enforce actual SELECT-only rights on the SQL login (prefer access to specific inspection views, not db_owner, db_datawriter or sysadmin).
- For SQL Server logins, grant only the required database SELECT / metadata permissions. Some schema catalog metadata may need `VIEW DEFINITION` on selected objects; add only if needed.
- SQL inspection output can contain sensitive data. Keep queries limited to schema/necessary test rows, tightly control GitHub Actions/artifact access, do not log connection strings, and rotate credentials if compromised.
- **SQL SELECT succeeded** in run [40075792074](https://github.com/ngocnhanvo/anco1/actions/runs/40075792074): authenticated and returned 50 rows; CSV artifact uploaded.
- If the database should remain internal-only or allowlisting cannot be maintained, the earlier self-hosted arrangement is still the safer operational choice; this document describes the simpler remote-access path the project owner requested.

## Actual smoke-test result (2026-10-24)

- The user configured all four `ANCO1_SQL_*` GitHub Actions secrets.
- A temporary, narrowly scoped push trigger was used for the initial test and **removed afterward**; the final workflow is manual `workflow_dispatch` only.
- Run [40075559282](https://github.com/ngocnhanvo/anco1/actions/runs/40075559282) confirmed **TCP connectivity to the remote SQL Server**: `A connection was successfully established with the server`.
- SQL login did **not** finish because the server TLS certificate chain was not trusted by the GitHub-hosted runner: `The certificate chain was issued by an authority that is not trusted.`
- This is **not** evidence of a wrong user/password; no SQL SELECT has executed yet.
- Preferred fix: configure a SQL Server TLS certificate with a trusted chain whose subject/SAN matches the hostname in `ANCO1_SQL_SERVER`, including any necessary intermediate certificate chain, and ensure the server sends that chain. Run the manual workflow again afterward.
- Avoid setting `TrustServerCertificate=True` by default: doing so skips server identity verification and is risky with database TCP accessible from the internet.
- During test, fixed PowerShell 7 / System.Data.SqlClient connection-string keywords in `scripts/anco1_sql_readonly.ps1` (`Data Source` and `TrustServerCertificate`).

## Successful test

- Run 40075792074 successfully read 50 rows of packaging schema metadata.
- Temporary push trigger was removed; manual dispatch remains.
- Current certificate bypass is temporary and should be retired after the VPS certificate is fixed.

## Implementation

- `.github/workflows/anco1-sql-readonly.yml`
- `scripts/anco1_sql_readonly.ps1`
- `sql/inspect-packaging-schema.sql`

This diagnostic workflow does not run application build/deployment and does not sync Azure DevOps.
