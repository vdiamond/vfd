# AGENTS.md

Development happens only through Victor and Cursor agents.

## What this repo is

**vfd** is the Orchard Core 3.0.1 CMS for [valuefromdigital.com](https://valuefromdigital.com) (Value From Digital). `Vfd.slnx` contains `Vfd.Web` and `Vfd.Theme`, both `net10.0`. The site theme is Liquid (`Vfd.Theme`, base theme `TheAgencyTheme`).

The site is live. Production publish is a manual GitHub Actions workflow (SmarterASP WebDeploy). Page content is also managed in the live CMS (Default tenant). `docs/content-drafts/` is an unpublished draft package.

## Build, run, and test

Prerequisite: .NET 10 SDK.

```bash
dotnet restore
dotnet build Vfd.slnx -c Release --no-restore
dotnet run --project Vfd.Web
```

`dotnet run --project Vfd.Web` uses `Vfd.Web/Properties/launchSettings.json` and listens on `https://localhost:5001` and `http://localhost:5000`. First-run setup is the Orchard setup UI; choose the Agency recipe for the Default tenant (see `README.md`). Local data is SQLite under `App_Data/` (gitignored).

CI (`.github/workflows/ci.yml`, `windows-latest`) runs:

```bash
dotnet restore Vfd.slnx
dotnet build Vfd.slnx -c Release --no-restore
dotnet publish Vfd.Web/Vfd.Web.csproj -c Release -o ./publish --no-build
```

There are no test projects. `dotnet test Vfd.slnx` exits 0 and executes no tests. CI skips `dotnet test` when no `*.Tests.csproj` files exist.

Restore and build print existing NuGet audit warnings (`NU1902` / `NU1903`) and still succeed.

## Layout

- `Vfd.slnx` — solution (`Vfd.Web` + `Vfd.Theme`)
- `Vfd.Web/` — Orchard Core CMS host (`OrchardCore.Application.Cms.Targets` 3.0.1, `OrchardCore.Logging.NLog` 3.0.1)
- `Vfd.Theme/` — branding theme: Liquid views and recipe snippets, `Recipes/vfd-branding.recipe.json`, CSS and static assets. See `Vfd.Theme/README.md`
- `docs/content-drafts/` — unpublished content drafts
- `ci/github-actions-ci.yml` — pointer to `.github/workflows/ci.yml` (GitHub does not run this file)
- `ci/deploy-smarterasp.md` — WebDeploy runbook (secret names only)
- `.github/workflows/ci.yml` — restore, build, conditional test, publish, upload artifact. No WebDeploy
- `.github/workflows/deploy-prod.yml` — manual `workflow_dispatch` SmarterASP WebDeploy. Secrets referenced by name only: `WEBSITE_NAME`, `SERVER_COMPUTER_NAME`, `SERVER_USERNAME`, `SERVER_PASSWORD`. Optional environment variable `SITE_URL`

## Dependencies on other vdiamond repos

None. There is no git submodule and no HTTP client or package aimed at another vdiamond repository. The only `ProjectReference` is inside this repo: `Vfd.Web` → `../Vfd.Theme/Vfd.Theme.csproj`. Everything else is NuGet (Orchard Core 3.0.1 and `TheAgencyTheme` 3.0.1). No other vdiamond repo needs to be cloned beside this one. No known dependents were named for this repo.

## Conventions

Governing standard: [`.cursor/rules/coding-standards.mdc`](.cursor/rules/coding-standards.mdc). Existing code may not yet comply. Bring it into compliance when you touch it.

Observed in this repo:

- `net10.0`, `<Nullable>enable</Nullable>`, and `<ImplicitUsings>enable</ImplicitUsings>` on both projects
- File-scoped namespaces; `sealed` theme types (`Startup`, `ResourceManagementOptionsConfiguration`)
- Orchard theme manifest in `Vfd.Theme/Manifest.cs` (`BaseTheme = TheAgencyTheme`) and Liquid under `Vfd.Theme/Views/` and `Vfd.Theme/Recipes/Snippets/`
- No root `.editorconfig`. Warnings are not treated as errors in the project files (Release build succeeds with NuGet audit warnings)
- The small C# surface does not use `#region` member ordering or XML docs on public types

## What not to touch

- Never commit secrets or connection strings. Real values belong in environment variables, user secrets, or GitHub Environment secrets. Do not put them in `appsettings.json`, workflow YAML, issues, or chat. `appsettings.json` only documents tenant table-prefix guidance (`RequireTablePrefix` is `false`).
- Do not run or trigger deploy workflows. `.github/workflows/deploy-prod.yml` is manual. Production needs Victor's `APPROVE DEPLOY` and GitHub Environment `prod` approval. Do not overwrite production `App_Data` or the content database.
- Content is also managed in the live CMS. Do not treat `docs/content-drafts/` or recipe snippets as the only source of live pages.
- Do not commit generated or local output: `bin/`, `obj/`, `publish/`, `App_Data/`, or the Orchard `.po` files the build copies into `Vfd.Web/Localization/`.
- `Vfd.Web/wwwroot/.gitkeep` is intentional so publish includes `wwwroot`. Leave it.
- Do not change public APIs, package versions, tenant or hostname setup, or production configuration without asking Victor.
