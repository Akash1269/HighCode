---
description: Update an existing learning doc for perticular data strucutre with newly added files
agent: agent
---

Compare the attached folder contents against the existing learning doc. The learning doc is the `.md` file whose name matches the folder name (e.g., `Tree.md` in `Tree/`). If multiple `.md` files exist, ask the user to clarify which is the learning doc before proceeding. If no `.md` file is found in the folder, stop and inform the user: "No learning doc found in this folder. Please create one before running this prompt."

Treat only files with extensions `.csx`, `.cs`, `.py`, `.js`, `.ts`, `.java`, `.cpp`, `.go`, or `.rb` as code files. Ignore all other file types (e.g., images, data files, additional `.md` files).

If all code files in the folder are already referenced in the learning doc, respond with: "No new files found. The learning doc is already up to date." and make no edits.

For any new code files not already referenced in the doc:

1. Read and analyze each new file.
2. Identify which existing pattern(s) it uses — or if it introduces a new pattern. If a file matches multiple existing patterns, add it to the "Applied in" table of every matching pattern. In the Difficulty Progression table, note all matched patterns in the pattern column, separated by commas.
3. Update the doc (complete all sub-steps for one file before moving to the next):
   3a. Add the file to the relevant pattern's "Applied in" table.
   3b. If this is a new pattern: (i) add a bullet to the Pattern Summary list, then (ii) create a new Pattern Deep Dive section.
   3c. Insert the problem into the Difficulty Progression table in ascending order of difficulty (Easy → Medium → Hard). Within the same difficulty level, append it at the bottom of that group.
   3d. Check whether the file introduces a problem-recognition cue (e.g., a specific input structure, constraint keyword, or output requirement) not already represented by any existing row in the Quick Reference table; if yes, add a row.
   3e. If the pattern was listed under "Additional Interview Patterns (Not Yet Practiced)", remove it from that section and into the main patterns.

Do NOT rewrite unchanged sections. Only add/update what's needed for the new files.
