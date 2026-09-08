# VFD Theme

Orchard Core theme for [valuefromdigital.com](https://valuefromdigital.com). Bases on **TheAgencyTheme** (`BaseTheme = TheAgencyTheme`) and layers VFD branding.

## What it includes

- White logo in the dark navbar; color SVG/PNG under `wwwroot/img/`
- Favicons under `wwwroot/Favicons/`
- Hero background: `wwwroot/img/hero-digital-workspace.png` (via `css/vfd-branding.css`, also linked directly from Layout)
- `Recipes/Snippets/landingpage.liquid` — Jess #9 Digital Workspace strings; Send Message form replaced with mailto + LinkedIn CTA
- `Recipes/Snippets/Layout.liquid` — logo `<img>` + branding CSS (Admin Templates override BaseTheme Layout)
- `Recipes/vfd-branding.recipe.json` — sets site theme to **Vfd.Theme** and updates DB templates `Layout` + `Content__LandingPage`

## Why Layout goes through Templates

`Content__LandingPage` already applied via the Templates recipe. Theme `Views/Layout.liquid` alone did not win over Agency BaseTheme Layout on live (assets at `/Vfd.Theme/...` can 200 even when Agency Layout still renders). Installing `Layout` as an Admin Liquid template matches the path that worked for the landing page.

## Post-deploy (Default tenant)

After deploy of this PR:

1. **Design → Themes** — **VFD Theme** Current for Default (recipe also sets `Site: Vfd.Theme`).
2. **Configuration → Recipes** — re-run **VFD Branding (Layout + LandingPage templates)** (v1.1.0).
3. Hard-refresh home. Confirm: navbar logo image (not text), `vfd-branding.css` linked, hero background, Jess strings, mailto contact (no Send Message form).
4. Optional check: **Design → Templates** should list `Layout` and `Content__LandingPage`.

Do **not** merge/deploy without Victor `APPROVE DEPLOY`.

## Nav

Expected main menu remains Home · Services · Approach · About · Contact. Portfolio/Clients stay gated by bag size (empty bags hide those sections).
