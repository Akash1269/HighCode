---
description: Update the main DataStructures README with newly added files
mode: agent
---

Compare all folders inside `DataStructures/` against the existing `DataStructures/README.md`. For any new `.csx` files not already listed in the README:

1. Read the new file, extract:
   - The question/problem description (from comments at the top)
   - Tags (from `#tag` comments)
   - Whether it's an implementation or a problem

2. Add the file as a new row in the correct section's table:
   - Place under the right data structure heading (Arrays, Strings, LinkedList, Stack, Queue, Tree, etc.)
   - Put implementations under "### Implementation" and problems under "### Problems"
   - Follow existing format: `| [FileName.csx](Folder/FileName.csx) | Description | Tags |`

3. Update the Tag Index at the bottom:
   - Add the new file name to every tag it uses
   - If it introduces a new tag not in the index, create a new row for that tag

4. If the new file belongs to a data structure folder that doesn't have a section yet, create a new section following the existing convention (heading, Implementation/Problems subsections, table).

Do NOT rewrite unchanged rows or sections. Only add what's new.
