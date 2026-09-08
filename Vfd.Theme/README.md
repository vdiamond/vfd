# VFD Theme

Orchard Core theme for [valuefromdigital.com](https://valuefromdigital.com). Bases on **TheAgencyTheme** (`BaseTheme = TheAgencyTheme`) and layers VFD branding.

## What it includes

- White logo in the dark navbar; color SVG/PNG under `wwwroot/img/`
- Favicons under `wwwroot/Favicons/`
- Hero background: `wwwroot/img/hero-digital-workspace.png` (via `css/vfd-branding.css`)
- `Recipes/Snippets/landingpage.liquid` — Jess #9 Digital Workspace strings; Send Message form replaced with mailto + LinkedIn CTA
- `Recipes/vfd-branding.recipe.json` — updates DB template `Content__LandingPage` and sets site theme to **VFD Theme**

## Post-deploy (Default tenant)

Live leftovers live in the **Templates** DB entry `Content__LandingPage` (Agency snippet), not CMS bags. After deploy:

1. **Design → Themes** — enable and activate **VFD Theme** for Default (or run the recipe below).
2. **Configuration → Recipes** — run **VFD Branding (LandingPage template)**, **or** paste `Recipes/Snippets/landingpage.liquid` into **Design → Templates → Content__LandingPage**.
3. Hard-refresh the home page; confirm navbar logo, hero image, and contact CTA (no Send Message form).

Do **not** merge/deploy without Victor `APPROVE DEPLOY`. No live CMS bag edits required for these Liquid strings.

## Nav

Expected main menu remains Home · Services · Approach · About · Contact. Portfolio/Clients stay gated by bag size (empty bags hide those sections).
