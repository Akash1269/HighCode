---
description: Update the root README.md with current repo stats and structure
agent: agent
---

Scan the repository structure and update the root `README.md` to reflect the current state. Specifically:

1. **Repository Structure tree** — Regenerate the folder tree under "Repository Structure" to include any new top-level or `DataStructures/` subfolders. Keep the one-line description for each folder.

2. **Topics Covered table** — Recount:
   - For each folder under `DataStructures/`, count `.csx` files that are problems (top comment describes a challenge) vs implementations (top comment describes building a DS, or file lives in an `Implementation/` subfolder).
   - Update the Problems and Implementations columns.
   - Add rows for any new data structure folders not yet listed.
   - Remove rows for folders that no longer exist.

3. **Learning Docs list** — Check which `*.md` learning docs exist inside each `DataStructures/` subfolder. Add links for any new ones, remove links for any that no longer exist.

4. **Do NOT change** the Quick Start, Conventions, or any other section unless its content is factually outdated (e.g., a referenced file was deleted).

Keep formatting consistent with the existing style. Do not rewrite sections that are already correct — only update what changed.
