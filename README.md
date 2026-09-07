# vfd

**Value From Digital** — Orchard Core CMS for [valuefromdigital.com](https://valuefromdigital.com).

## Architecture (Option C)

- **Default** tenant: Agency recipe + `OrchardCore.Tenants` (not the SaaS recipe).
- Hostnames: `valuefromdigital.com` and `localhost` map to Default.
- Admin: `/admin`.

Pins: **.NET 10** (`net10.0`), **Orchard Core 3.0.1**, meta-package `OrchardCore.Application.Cms.Targets`.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Local run

```bash
dotnet restore
dotnet run --project Vfd.Web
```

1. Open the setup UI in the browser (see launch profile URLs, typically `https://localhost:5001`).
2. For the **Default** tenant, choose the **Agency** recipe (not SaaS).
3. After setup, sign in at `/admin`.
4. Go to **Configuration → Features** and enable **OrchardCore.Tenants**.
5. Configure hostnames for Default: `valuefromdigital.com` and `localhost`.

Local data uses **SQLite** under `App_Data/` (gitignored). Do not commit connection strings, admin passwords, or deployment secrets.

## Shared SQL later (guidance only)

When moving off per-tenant SQLite to a shared SQL database, use table prefixes so tenants do not collide. See commented notes in `Vfd.Web/appsettings.json` / `appsettings.Development.json` for `OrchardCore_Tenants` (`RequireTablePrefix`, `TablePrefixPattern` with `{{ ShellSettings.Name }}`). Put real connection strings in environment variables or user secrets — never in the repo.

## CI

GitHub Actions (`.github/workflows/ci.yml`) on `windows-latest`: restore → build → test (if present) → publish → upload artifact. No WebDeploy.

## Solution layout

- `Vfd.slnx` — solution
- `Vfd.Web/` — Orchard Core CMS web app (`occms` template, Orchard 3.0.1)
