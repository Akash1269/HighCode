# Copilot Instructions — HighCode Repo

## Project Context
- This is a data structures & algorithms interview prep repository
- Files are C# scripts (.csx) runnable via `dotnet script`
- Each file is self-contained — no cross-file dependencies for problem files

## File Conventions
- Every problem file must start with `// Question -` comment describing the problem
- Add tags as comments on a separate line: `// #tree #dfs #backtracking`
- Use descriptive PascalCase file names matching the problem (e.g., `PathSum3.csx`, `MaxDepth.csx`)

## Code Style
- Use TreeNode/ListNode class conventions matching LeetCode signatures
- Include multiple approaches when possible (brute force → optimized), ordered from most intuitive to most optimal
- Add a short comment above each approach explaining the strategy and trade-off
- Keep variable names meaningful — no single-letter names except loop counters (`i`, `j`) and standard conventions (`p`, `q` for tree nodes in LCA)

## Organization
- Files are grouped by data structure folder: `Arrays/`, `LinkedList/`, `Stack/`, `Queue/`, `Tree/`, `Strings/`
- Implementation files (building the DS from scratch) are separate from problem files
- Each data structure folder may have a learning doc (`[FolderName].md`) summarizing patterns

## When Adding a New Problem
- Place the file in the correct data structure folder
- Follow the existing tag convention from similar files
- If it introduces a pattern not yet documented, note it for the learning doc update
