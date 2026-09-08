# Binary assets pending MCP upload

These binaries are prepared on the agent box at `/workspace/vfd-work/Vfd.Theme/wwwroot/` but GitHub MCP `create_or_update_file` / `push_files` only accept text content (UTF-8). No `GH_TOKEN` is available in the shell for `gh api` binary blob upload.

## Required binaries (copy from box or emblem pack)

| Repo path | Source on box |
| --- | --- |
| `Vfd.Theme/wwwroot/img/hero-digital-workspace.png` | `/workspace/vfd-emblem/vfd-hero-digital-workspace.png` |
| `Vfd.Theme/wwwroot/img/logo-color.png` | `.../For Web/png/Color logo - no background.png` |
| `Vfd.Theme/wwwroot/img/logo-white.png` | `.../For Web/png/White logo - no background.png` |
| `Vfd.Theme/wwwroot/Favicons/browser.png` | `.../For Web/Favicons/browser.png` |
| `Vfd.Theme/wwwroot/Favicons/android.png` | `.../For Web/Favicons/Android.png` |
| `Vfd.Theme/wwwroot/Favicons/iphone.png` | `.../For Web/Favicons/iPhone.png` |
| `Vfd.Theme/wwwroot/favicon.png` | same as browser.png |

SVGs (`logo-color.svg`, `logo-white.svg`) are text and should be in this PR via MCP.

After cloning the branch locally: `cp` the files above into place and `git add` / commit / push to the feature branch.
