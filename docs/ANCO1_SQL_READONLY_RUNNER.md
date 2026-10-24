# VPS SQL Server read-only inspection

This workflow is **not yet runnable** until the VPS self-hosted runner and GitHub environment secrets are configured.

## VPS setup

1. On the **Windows VPS hosting SQL Server**, create a dedicated non-admin Windows account for the GitHub Actions runner, and register a GitHub self-hosted runner with labels `self-hosted`, `windows`, `anco1-sql`. Install and run it as a Windows service under the dedicated account. Restrict the runner to this repository; use it only with trusted workflows. Prefer an isolated runner if other untrusted workflows can be edited or triggered.
2. Create a SQL login with only `CONNECT` and `SELECT` on the required database objects (or preferably dedicated inspection views). **Do not assign `db_owner`, `db_datawriter`, `sysadmin` or other elevated roles**. Limit the login to read-only operations. Server-side SQL permissions, not the PowerShell keyword filter, are the security boundary.
3. Configure a trusted SQL Server TLS certificate (the script requires `Encrypt=True;TrustServerCertificate=False`).
4. In GitHub Settings > Environments, create `anco1-sql-readonly` with **required reviewers** and add environment secrets: `ANCO1_SQL_SERVER`, `ANCO1_SQL_DATABASE`, `ANCO1_SQL_USER`, `ANCO1_SQL_PASSWORD`. Never put credentials in source, logs or chat.
5. Open Actions > **Anco1 - VPS SQL read-only inspection**, choose the approved query, and start. The job will wait for an available runner and environment approval. Download the artifact `anco1-sql-inspection` (retained one day) for review.
6. The SQL Server does **not** need a public port 1433: the runner is installed on the VPS and makes outbound connections to GitHub.

## Security notes

- Workflow permits only committed, predefined query files. No arbitrary SQL input from the workflow form.
- Query results may contain sensitive data. Use schema-only inspection by default, redact data, keep short artifact retention and limit GitHub repository/artifact access.
- Only one read-only SELECT is allowed by the client script, with a 500-row result limit and a 45-second command timeout; the server login must independently enforce read-only rights.
- Self-hosted runners execute repository code. Restrict workflow modification rights and runner access, and do not use this runner for pull requests from untrusted forks.
- The VPS operator must perform runner registration and configure secrets; GitHub's APIs do not grant access to a private VPS automatically.
- The workflow is deliberately **manual** and never runs on push, schedule or pull request.
