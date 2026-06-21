# HighCode

Data structures & algorithms interview prep — self-contained C# scripts runnable via [`dotnet script`](https://github.com/dotnet-script/dotnet-script).

## Quick Start

```powershell
# Run any problem file
dotnet script DataStructures/Arrays/ContainerWithMostWater.csx
```

## Repository Structure

```
DataStructures/          — Core DS implementations & problems
├── Arrays/              — Array manipulation, sliding window, two pointers
├── Strings/             — String processing, compression, GCD
├── LinkedList/          — Singly, doubly, circular + problems
├── Stack/               — Stack-based problems (collisions, decoding)
├── Queue/               — Queue-based problems (simulation, BFS)
├── Tree/                — BST, DFS, BFS, level-order problems
├── Graph/               — Graph traversal, connected components
├── PriorityQueue/       — Heap concepts & priority queue theory
└── README.md            — Full file index with tags

Algorithms/              — Algorithm implementations (planned)
Documents/               — Tag reference
Legacy/                  — Older C implementations (linked list, stack, queue, BST)
Misc/                    — Notes, books, miscellaneous scripts
```

## Conventions

- Every problem file starts with `// Question -` describing the problem
- Tags appear as comments: `// #tree #dfs #backtracking`
- PascalCase file names matching the problem (e.g., `MaxDepthToLeaf.csx`)
- Multiple approaches per file ordered from intuitive to optimal
- Each data structure folder has a learning doc (`FolderName.md`) summarizing patterns

## Topics Covered

| Data Structure | Problems | Implementations |
|---|---|---|
| Arrays | 16 | 1 |
| Strings | 5 | — |
| LinkedList | 4 | 4 (singly, doubly, circular, operations) |
| Stack | 3 | 2 (array, linked list) |
| Queue | 2 | 2 (array, linked list) |
| Tree | 20 | 1 (BST) |
| Graph | 3 | 2 (adjacency list, matrix) |
| PriorityQueue | — | — (theory docs) |

## Learning Docs

Each folder contains a pattern-focused learning document:

- [Arrays/Arrays.md](DataStructures/Arrays/Arrays.md) — Sliding window, two pointers, prefix sum, greedy
- [Strings/Strings.md](DataStructures/Strings/Strings.md) — Window on strings, reverse traversal, RLE, GCD
- [LinkedList/LinkedList.md](DataStructures/LinkedList/LinkedList.md) — Fast/slow pointers, reversal, partitioning
- [Stack/Stack.md](DataStructures/Stack/Stack.md) — Undo/cancel, nested processing, collision simulation
- [Queue/Queue.md](DataStructures/Queue/Queue.md) — Window filter, round-robin simulation
- [Tree/Tree.md](DataStructures/Tree/Tree.md) — DFS, BFS, level-order patterns
- [Graph/Graph.md](DataStructures/Graph/Graph.md) — DFS/BFS traversal, connected components
- [PriorityQueue/Heap.md](DataStructures/PriorityQueue/Heap.md) — Heap operations, HeapSort, common patterns
- [PriorityQueue/PriorityQueue.md](DataStructures/PriorityQueue/PriorityQueue.md) — PQ operations, C# API, interview patterns
