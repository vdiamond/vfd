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
5. Configure hostnames for Default: `valuefromdigital.com` and `localhost` (during first prod setup on a temp URL, leave **RequestUrlHost** blank/catch-all until DNS/SSL works).
6. Enable **VFD Theme** (Design → Themes) and run the **VFD Branding** recipe (or paste `Vfd.Theme/Recipes/Snippets/landingpage.liquid` into Design → Templates → `Content__LandingPage`). See `Vfd.Theme/README.md`.

Local data uses **SQLite** under `App_Data/` (gitignored). Do not commit connection strings, admin passwords, or deployment secrets.

**Publish must include `wwwroot`** (tracked `Vfd.Web/wwwroot/.gitkeep`) so `WebRootPath` resolves — ImageSharp/Media cache fails with HTTP 500 if the folder is missing from the deploy package.

## Shared SQL later (guidance only)

When moving off per-tenant SQLite to a shared SQL database, use table prefixes so tenants do not collide. See `OrchardCore:OrchardCore_Tenants` in `Vfd.Web/appsettings.json` (`RequireTablePrefix` stays **false** until a second tenant shares the DB). Put real connection strings in environment variables or user secrets — never in the repo.

## CI

GitHub Actions CI (restore → build → test if present → publish → upload artifact on `windows-latest`; **no WebDeploy**) lives at `.github/workflows/ci.yml`.

## Solution layout

- `Vfd.slnx` — solution (`Vfd.Web` + `Vfd.Theme`)
- `Vfd.Web/` — Orchard Core CMS web app (`occms` template, Orchard 3.0.1)
- `Vfd.Theme/` — VFD branding theme (bases on TheAgencyTheme): logo, favicons, digital hero, Digital Workspace landing Liquid + branding recipe
- `.github/workflows/ci.yml` — CI build/publish

## Branding / theme (#9)

Live Agency leftovers are in the Liquid template `Content__LandingPage` (not CMS bags). After merge/deploy:

1. Activate **VFD Theme** on Default.
2. Run recipe **VFD Branding** (updates `Content__LandingPage` from `Vfd.Theme/Recipes/Snippets/landingpage.liquid`) **or** paste that snippet in Design → Templates.
3. Require Victor **APPROVE DEPLOY** before production.

Copy source of truth: Jess comment on issue #9 (Digital Workspace strings).
