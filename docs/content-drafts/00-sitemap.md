# Sitemap — Value From Digital

**Status:** unpublished  
**IA note:** Home is an Agency **LandingPage** with bag parts (Services, Portfolio, About, Team, Clients). Standalone **Page** items cover Approach and Contact. Individual **Service** items are bagged on Home and may also use Autoroute for deep links from LinkedIn.

## Tree

```
/ (home)                          LandingPage
├── #services                     LandingPage bag: Services
│   ├── /services/digital-readiness
│   ├── /services/strategic-plans
│   ├── /services/project-assessment
│   ├── /services/cost-savings
│   ├── /services/team-structures
│   └── /services/enterprise-architecture
├── #portfolio                    LandingPage bag: Portfolio (placeholder — unpublished)
├── #about                        LandingPage bag: About (Milestones + copy)
├── #team                         LandingPage bag: Team
├── #clients                      LandingPage bag: Clients (placeholder — unpublished)
├── /approach                     Page
└── /contact                      Page
```

## Path inventory

| Path | Content type | Purpose |
|------|--------------|---------|
| `/` | LandingPage | Primary conversion surface for LinkedIn traffic: pain → offer → services → approach cue → team → CTA |
| `/#services` | BagPart (Services) | Summaries of six Service items; anchors LinkedIn readers to concrete help |
| `/services/digital-readiness` | Service | Digital readiness assessments |
| `/services/strategic-plans` | Service | Co-creation of strategic plans with measurable value |
| `/services/project-assessment` | Service | Project assessments and remediation framing |
| `/services/cost-savings` | Service | IT cost-savings measures |
| `/services/team-structures` | Service | IT team structures and business interaction |
| `/services/enterprise-architecture` | Service | Positioning EA closer to the business |
| `/#portfolio` | BagPart (Portfolio) | **Structure only** — no Project items until Victor approves real ones |
| `/#about` | BagPart (About) + Milestone(s) | Who we are / how we work; optional timeline placeholders |
| `/#team` | BagPart (Team) | Victor Diamond as principal |
| `/#clients` | BagPart (Clients) | **Structure only** — no Client logos/names until approved |
| `/approach` | Page | Engagement models (per diem; pay per real results); pricing TBD |
| `/contact` | Page | Book a conversation / start a readiness conversation |

## Navigation recommendation

**Primary nav:** Home · Services · Approach · About · Contact  

- Services may scroll to `/#services` or open a soft index; deep links remain for each Service.  
- Portfolio and Clients stay out of primary nav until real content exists.  
- Team is reachable via About / home `#team` (no separate team index page required for v1).

## LinkedIn → site path

1. LinkedIn profile / post → `/`  
2. Optional deep link to a Service or `/approach`  
3. CTA → `/contact` or LinkedIn message to Victor  

Do not invent calendar booking URLs.
