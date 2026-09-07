# Content types — Agency-native mapping

**Status:** unpublished  
**Source of truth for types:** official `agency.recipe.json` (Agency recipe / TheAgencyTheme)

## Agency-native types (use these)

| Type | Key fields / parts | Use for VFD |
|------|--------------------|-------------|
| **LandingPage** | Title, Autoroute; BagParts: Services, Portfolio, About, Team, Clients | Home (`/`) |
| **Service** | Title, HtmlBody (or Markdown if enabled), **Icon Class**, Autoroute | Six service offerings |
| **Project** | Title, HtmlBody, **Image**, **Category**, Autoroute | Portfolio items — **none until Victor approves** |
| **Milestone** | Title, HtmlBody, **Date**, **Image** | About timeline entries (optional; TBD dates OK as unpublished) |
| **TeamMember** | Title, HtmlBody, **Occupation**, **Picture**, Twitter, Facebook, **LinkedIn** | Victor Diamond |
| **Client** | Title, **Logo**, **Url** | Logo strip — **none until Victor approves** |
| **Page** | Title, Autoroute, flow/Html body | `/approach`, `/contact` (and optional services soft-index if needed) |

## Flow / widget parts (body composition)

Use Agency flow parts as needed inside Page / LandingPage sections:

- **Html** — rich body blocks  
- **Paragraph** — short text  
- **Blockquote** — sparingly; only for brand statements (not fake testimonials)  
- **Container** — layout grouping  
- **Image** — media + caption when real assets exist  

## Optional custom (not required for v1)

Stay Agency-native for launch. Revisit only if Victor requests:

| Optional | Rationale | Recommendation |
|----------|-----------|----------------|
| Custom `EngagementModel` type | Formalize per-diem vs outcomes pricing | Prefer a **Page** (`/approach`) with clear sections — no custom type yet |
| Taxonomy for Service categories | Group services | Unnecessary at six items; use Icon Class + order in bag |
| Form / Workflow contact | On-site form | Out of scope for this content package; Contact page can point to LinkedIn / email TBD |
| SEO Meta fields | Per-page title/description | Use Orchard SEO/meta modules if already enabled; drafts include SEO notes only |

## Page → type mapping

| Path / item | Type | Bag / placement | Notes |
|-------------|------|-----------------|-------|
| Home | LandingPage | — | Autoroute `/` or HomeRoute |
| Services section | BagPart → Service | LandingPage.Services | Order: readiness → strategy → project → cost → teams → EA |
| Digital readiness | Service | bag + Autoroute | Icon Class TBD (e.g. `fa-clipboard-check` style — confirm theme icons) |
| Strategic plans | Service | bag + Autoroute | |
| Project assessment | Service | bag + Autoroute | Covers assessment + remediation framing |
| Cost savings | Service | bag + Autoroute | |
| Team structures | Service | bag + Autoroute | |
| Enterprise architecture | Service | bag + Autoroute | |
| Portfolio section | BagPart → Project | LandingPage.Portfolio | Empty / hidden until approved Projects |
| About section | BagPart → Milestone (+ Html) | LandingPage.About | Copy also in drafts/about.md for Page reuse if needed |
| Team section | BagPart → TeamMember | LandingPage.Team | Victor only for v1 |
| Clients section | BagPart → Client | LandingPage.Clients | Empty / hidden until approved |
| Approach | Page | — | Engagement models; pricing TBD |
| Contact | Page | — | Conversation CTA |
| Services index (optional) | Page **or** home bag only | — | Draft provided as `services-index.md` for bag intro + soft index |

## Field fill guidance

- **Icon Class (Service):** Choose from TheAgencyTheme / Font Awesome classes available in theme; leave TBD in CMS until design pass.  
- **Picture (TeamMember):** Real photo of Victor when available; placeholder path only in CMS, not fake imagery claims.  
- **LinkedIn (TeamMember):** `https://www.linkedin.com/in/victor-diamond-0a5b81/`  
- **Twitter / Facebook:** Leave blank unless Victor supplies.  
- **Project Image / Client Logo:** Do not upload stock “fake client” assets.  
- **Pricing:** Never store invented rates; Approach page states TBD / unpublished.
