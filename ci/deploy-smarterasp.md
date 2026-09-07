# SmarterASP WebDeploy (prod)

Owner: **Rex (Release)**. Implements [#3](https://github.com/vdiamond/vfd/issues/3).

**Do not merge or run a deploy until Victor types `APPROVE DEPLOY`.**  
Technical gate: GitHub Environment **`prod`** with required reviewers = Victor.

Never put passwords in chat, YAML, issues, or share links. Secrets live in GitHub Environment secrets / SmarterASP only.

## Host inventory (non-secrets)

| Item | Value |
| --- | --- |
| Site / tenant | `valuefromdigital.com` → Default |
| Admin | `/admin` |
| WebDeploy site name | `vdiamond-002-site1` |
| WebDeploy endpoint | `https://win8178.site4now.net:8172/MsDeploy.axd?site=vdiamond-002-site1` |
| SQL host / catalog | `sql8012.site4now.net` / `db_acde65_vfd` |
| Runtime | .NET 10 ASP.NET Core, 1 GB app pool |

## Workflow

- File: `.github/workflows/deploy-prod.yml`
- Trigger: **`workflow_dispatch` only** (manual). No auto-deploy on push yet.
- Job `deploy` uses `environment: prod` → Victor must approve in GitHub before WebDeploy runs.
- Build/publish mirrors CI (`.github/workflows/ci.yml`): `windows-latest`, .NET `10.0.x`, `Vfd.Web` → `./publish`.
- MSDeploy sync with `-enableRule:AppOffline`, `-enableRule:DoNotDeleteRule`, and **skip `App_Data`** (does not overwrite production App_Data / content DB files).

## Secrets checklist (names only)

Create these as **Environment secrets** on `prod` (Settings → Environments → `prod` → Environment secrets). Values never belong in this repo.

| Secret name | Purpose | Example shape (not a real value) |
| --- | --- | --- |
| `WEBSITE_NAME` | WebDeploy site name | same as inventory site name |
| `SERVER_COMPUTER_NAME` | Full MsDeploy.axd URL including `?site=` | same as inventory endpoint |
| `SERVER_USERNAME` | WebDeploy username from SmarterASP | panel publish credentials user |
| `SERVER_PASSWORD` | WebDeploy password | panel only — never paste here |

Optional (not required for sync):

| Secret / var | Purpose |
| --- | --- |
| Connection string / DB password | Keep in SmarterASP appsettings / host config; do not put in workflow YAML |
| `SITE_URL` (**Environment variable**, not secret) | Public base URL for smoke job; default `https://valuefromdigital.com` if unset |

Also ensure Environment **`prod`** exists with **Required reviewers** = Victor before the first run.

## App pool / .NET match (Victor checklist)

Confirm in SmarterASP (Victor only — agents must not open the panel via browser):

- [ ] App pool / site targets **ASP.NET Core / .NET 10** (not Framework-only)
- [ ] Pool memory / plan matches **1 GB** expectation
- [ ] Site binding covers `valuefromdigital.com` (and any www/tenant hostnames)
- [ ] SSL certificate valid for those hostnames
- [ ] SQL catalog `db_acde65_vfd` reachable from the site; password only in host secrets

## Post-deploy smoke list

Automated (job `smoke` after successful deploy):

- [ ] `GET {SITE_URL}/` → HTTP **200**
- [ ] `GET {SITE_URL}/admin` → HTTP **200** or **302** (login redirect)

Manual / follow-up:

- [ ] `/admin` login page renders (Orchard admin UI)
- [ ] Static files (CSS/JS under `_content` / theme) load with 200
- [ ] Tenant hostname(s) for Default resolve and show expected site
- [ ] No accidental wipe of `App_Data` (media, OpenId, data protection keys intact)

## Never without Victor approval

- Trigger deploy (chat: `APPROVE DEPLOY` + GitHub `prod` approval)
- Change DNS, SSL, or app pool
- Overwrite production `App_Data` or database
- Spend money on the host
