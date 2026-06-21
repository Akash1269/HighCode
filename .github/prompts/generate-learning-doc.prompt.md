---
description: Generate a learning doc for a data structure folder
agent: agent
---

Analyze all the code in the attached folder and in nested folders as well and create a learning document (`${input:folderName}.md`) in that folder with the following structure:

1. **Basic Concepts** — Define the data structure, key terminology, common operations, and the node/class structure used across the code files.

A pattern is a distinct algorithmic technique visible in at least one code file (e.g., two-pointer traversal, recursive decomposition). If fewer than two patterns are found in the code, note this explicitly and populate Section 4 (Not Yet Practiced) with at least three patterns to compensate.

2. **Pattern Summary (Bullet List)** — List ALL identified patterns as numbered bullets. Each pattern should have:
   - A one-line intuitive description in quotes (plain English)
   - "Use when:" — the trigger/signal that tells you this pattern fits a new problem
   - "Think:" — the question to ask yourself during revision/interview

Section 3 must contain one subsection for every pattern listed in Section 2, in the same order. Do not repeat the "Use when" or "Think" text from Section 2 in Section 3.

3. **Pattern Deep Dives** — For each pattern:
   - Concept (2-3 lines explaining the idea)
   - Template (generic reusable code skeleton in C#)
   - Key Insight (one sentence — the "aha" moment)
   - Applied in: table with (File, Problem, What's specific to this usage)

4. **Additional Interview Patterns (Not Yet Practiced)** — Based on your training knowledge, list up to 5 common LeetCode/interview patterns for this data structure that do not appear in the analyzed files. Clearly label this section as based on general knowledge, not the provided code. List them in the same bullet format (intuitive description, use when, think, example problems).

5. **Problem Difficulty Progression** — Table of all solved problems ordered Easy → Medium → Hard with their key pattern.

6. **Quick Reference: When to Use What** — A table mapping situations/signals to patterns.

Do NOT include full problem code in the doc — only generic templates. Link to actual files using relative Markdown links from the generated document's location, e.g. `[BinaryTree.csx](./BinaryTree.csx)`.
