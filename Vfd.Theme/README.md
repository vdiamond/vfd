# VFD Theme

Orchard Core theme for [valuefromdigital.com](https://valuefromdigital.com). Bases on **TheAgencyTheme** (`BaseTheme = TheAgencyTheme`) and layers VFD branding.

## What it includes

- White logo in the dark navbar; color SVG/PNG under `wwwroot/img/`
- Favicons under `wwwroot/Favicons/`
- Hero background: `wwwroot/img/hero-digital-workspace.png` (via `css/vfd-branding.css`, also linked directly from Layout)
- `Recipes/Snippets/landingpage.liquid` — Jess #9 Digital Workspace strings; Send Message form replaced with mailto + LinkedIn CTA; #12 LinkedIn href fix + Victor theme avatar
- `Recipes/Snippets/Layout.liquid` — logo `<img>` + branding CSS + static VFD footer (#12; Privacy `/privacy`, Terms `/terms`)
- `Recipes/vfd-branding.recipe.json` — sets site theme to **Vfd.Theme** and updates DB templates `Layout` + `Content__LandingPage`
- `wwwroot/img/team-victor-diamond.jpg` — center-cropped headshot for team circle (#12)
- Brand orange `#FF774A` overrides Agency yellow `#ffc800` in `vfd-branding.css` (#12)

## Why Layout goes through Templates

`Content__LandingPage` already applied via the Templates recipe. Theme `Views/Layout.liquid` alone did not win over Agency BaseTheme Layout on live (assets at `/Vfd.Theme/...` can 200 even when Agency Layout still renders). Installing `Layout` as an Admin Liquid template matches the path that worked for the landing page.

## Post-deploy (Default tenant)

After deploy of this PR:

1. **Design → Themes** — **VFD Theme** Current for Default (recipe also sets `Site: Vfd.Theme`).
2. **Configuration → Recipes** — re-run **VFD Branding (Layout + LandingPage templates)** (v1.2.0).
3. Hard-refresh home. Confirm: larger navbar logo, orange primary (`#FF774A`), Victor team photo + LinkedIn, static footer copyright `2026 Value From Digital Inc.`, Privacy/Terms links.
4. Optional check: **Design → Templates** should list `Layout` and `Content__LandingPage`.
5. Jess: create CMS pages at `/privacy` and `/terms` (footer already links there).

Do **not** merge/deploy without Victor `APPROVE DEPLOY`.

## Nav

Expected main menu remains Home · Services · Approach · About · Contact. Portfolio/Clients stay gated by bag size (empty bags hide those sections).

## Homepage polish (#12)

- Logo height doubled (4rem / 5rem lg); max-width raised
- Primary yellow → `#FF774A`
- Team LinkedIn: use full URL as-is when CMS stores `http…`; else prefix `https://www.linkedin.com/in/`
- Footer LinkedIn + copyright; Privacy `/privacy`, Terms `/terms`
- Team avatar theme asset + `.team-member img` circular `object-fit: cover`
