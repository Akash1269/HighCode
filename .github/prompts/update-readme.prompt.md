---
description: Update the main DataStructures README with newly added files
agent: agent
---

Compare all folders inside `DataStructures/` and `Algorithms/` against the existing `DataStructures/README.md`. For any new `.csx` files not already listed in the README, and for any files listed under a different section than the folder they belong to:

- If a file is already listed in the README but under a different section than its folder, treat it as a new entry in the correct section and do not remove the old row (flag it with a comment for manual review instead).

1. Read the new file, extract:
   - The question/problem description: Extract the first contiguous block of comments at the top of the file. Use all lines in that block as the description. If no top comments exist, use the file name (without extension) as the description.
   - Tags (from `#tag` comments). If no #tag comments are found in the file, leave the Tags column empty (use an empty string, not a placeholder like N/A).
   - Whether it's an implementation or a problem. A file is an implementation if its top comment describes building or defining a data structure or algorithm (e.g. a linked list class, sorting algorithm). A file is a problem if its top comment describes a challenge or question to solve. If both apply, classify as problem.

2. Add the file as a new row in the correct section's table:
   - The heading name must exactly match the folder name (e.g., a file in `DataStructures/Heap/` goes under heading `## Heaps`, a file in `Algorithms/BinarySearch/` goes under `## Binary Search`). Do not infer or rename headings.
   - Put implementations under "### Implementation" and problems under "### Problems"
   - For DataStructures files use: `| [FileName.csx](Folder/FileName.csx) | Description | Tags |`
   - For Algorithms files use: `| [FileName.csx](../Algorithms/Folder/FileName.csx) | Description | Tags |`

3. Update the Tag Index at the bottom:
   - Add the new file name (without extension or path) to every tag it uses. Match tags case-insensitively against the existing Tag Index. If a match is found regardless of case, reuse the existing tag row's exact spelling. Only create a new row if no case-insensitive match exists.
   - Append to the existing tag row using plain names (no links), e.g. `| #tag | FileA, FileB, NewFile |`
   - If it introduces a new tag not in the index, create a new row for that tag

4. If the new file belongs to a folder that doesn't have a section yet, create a new section following the existing convention (heading, Implementation/Problems subsections, table).

Do NOT rewrite unchanged rows or sections. Only add what's new.
