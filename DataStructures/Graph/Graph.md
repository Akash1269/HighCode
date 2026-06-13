# Graph - Learning Guide

## Basic Concepts

### What is a Graph?
A graph is a non-linear data structure consisting of **vertices (nodes)** connected by **edges**. Unlike trees, graphs can have cycles, multiple paths between nodes, and no single root.

### Key Terminology
| Term | Definition |
|------|-----------|
| **Vertex (Node)** | A fundamental unit containing data |
| **Edge** | A connection between two vertices |
| **Adjacent** | Two vertices connected by an edge |
| **Degree** | Number of edges connected to a vertex |
| **Path** | A sequence of vertices connected by edges |
| **Cycle** | A path that starts and ends at the same vertex |
| **Connected** | A path exists between every pair of vertices |
| **Component** | A maximal connected subgraph |

### Types of Graphs
| Type | Description |
|------|-------------|
| **Undirected** | Edges have no direction (A—B means B—A) |
| **Directed (Digraph)** | Edges have direction (A→B does not imply B→A) |
| **Weighted** | Edges carry a cost/distance value |
| **Unweighted** | All edges are equal |
| **Cyclic** | Contains at least one cycle |
| **Acyclic** | No cycles (a tree is a connected acyclic graph) |
| **DAG** | Directed Acyclic Graph — used in topological sorting |

---

## Graph Representations

### 1. Adjacency List (most common in interviews)
Each node stores a list of its neighbors. Space-efficient for sparse graphs.

```csharp
// Using Dictionary
Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

// Using List of Lists (when nodes are 0-indexed)
List<List<int>> graph = new List<List<int>>();

// Using array of Lists (fixed size)
List<int>[] graph = new List<int>[n];
```

### 2. Adjacency Matrix
A 2D array where `matrix[i][j] = 1` means there's an edge from i to j. Good for dense graphs or when you need O(1) edge lookup.

```csharp
int[][] matrix = new int[n][];
// matrix[i][j] == 1 means edge exists between i and j
```

### 3. Node Class with Adjacency List
```csharp
class Node {
    public int data;
    public List<Node> adjacents;
}
```

### When to Use Which?
| Representation | Best For | Space | Edge Lookup |
|---------------|----------|-------|-------------|
| Adjacency List | Sparse graphs, most interview problems | O(V + E) | O(degree) |
| Adjacency Matrix | Dense graphs, quick edge checks | O(V²) | O(1) |
| Edge List | Kruskal's, simple storage | O(E) | O(E) |

---

## Graph Traversals (Fundamental Operations)

### DFS (Depth-First Search)
Go as deep as possible before backtracking. Uses a **stack** (or recursion).

```csharp
void DFS(Dictionary<int, List<int>> graph, int node, bool[] visited) {
    visited[node] = true;
    // process node
    foreach (int neighbor in graph[node]) {
        if (!visited[neighbor])
            DFS(graph, neighbor, visited);
    }
}
```

**Use when:** Finding connected components, cycle detection, path finding, topological sort.

### BFS (Breadth-First Search)
Explore all neighbors at current depth before going deeper. Uses a **queue**.

```csharp
void BFS(Dictionary<int, List<int>> graph, int start, bool[] visited) {
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = true;

    while (queue.Count > 0) {
        int node = queue.Dequeue();
        // process node
        foreach (int neighbor in graph[node]) {
            if (!visited[neighbor]) {
                queue.Enqueue(neighbor);
                visited[neighbor] = true;
            }
        }
    }
}
```

**Use when:** Shortest path (unweighted), level-order traversal, nearest neighbor.

### DFS vs BFS
| | DFS | BFS |
|--|-----|-----|
| **Data Structure** | Stack / Recursion | Queue |
| **Space** | O(H) height of deepest path | O(W) width of widest level |
| **Shortest Path?** | No (unweighted) | Yes (unweighted) |
| **Best For** | Explore all paths, cycles, components | Shortest distance, levels |

---

## Patterns & Strategies

### Pattern 1: Connected Components (DFS/BFS from every unvisited node)

**Concept:** Iterate through all nodes. For each unvisited node, run DFS/BFS to mark its entire component as visited. Count how many times you start a new traversal.

**Template:**
```csharp
int CountComponents(int n, int[][] edges) {
    var graph = BuildAdjacencyList(edges);
    bool[] visited = new bool[n];
    int count = 0;

    for (int i = 0; i < n; i++) {
        if (!visited[i]) {
            DFS(graph, i, visited);
            count++;
        }
    }
    return count;
}
```

**Key Insight:** Each DFS/BFS call "floods" an entire component. The number of flood-fills = number of components.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `ConnectedProvinces.csx` | Count provinces (connected components) | Adjacency matrix, DFS + BFS approaches |

---

### Pattern 2: Reachability / Traversal (Can you reach all nodes?)

**Concept:** Start from a source node, traverse using DFS/BFS, and check if all required nodes were visited.

**Template:**
```csharp
bool CanReachAll(List<List<int>> graph, int start) {
    bool[] visited = new bool[graph.Count];
    DFS(graph, start, visited);
    return visited.All(v => v);
}
```

**Key Insight:** The graph may not be given explicitly — sometimes you build it from the problem description (e.g., rooms with keys = adjacency list).

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `VisitRoomsWithKeys.csx` | Can visit all rooms? | Rooms as adjacency list, DFS reachability |

---

### Pattern 3: Cycle Detection

**Concept (Undirected):** During DFS, if you visit a neighbor that's already visited AND it's not the parent → cycle found.

**Concept (Directed):** Use three states: unvisited, in-progress, completed. If you reach an in-progress node → cycle (back edge).

**Template (Directed):**
```csharp
// 0 = unvisited, 1 = in-progress, 2 = completed
bool HasCycle(int node, List<List<int>> graph, int[] state) {
    state[node] = 1;
    foreach (int neighbor in graph[node]) {
        if (state[neighbor] == 1) return true; // back edge = cycle
        if (state[neighbor] == 0 && HasCycle(neighbor, graph, state))
            return true;
    }
    state[node] = 2;
    return false;
}
```

---

### Pattern 4: Topological Sort (DAG ordering)

**Concept:** Order vertices such that for every directed edge u→v, u comes before v. Only possible in DAGs.

**Approach 1 — DFS + Post-order (reverse):**
```csharp
void TopSort(int node, List<List<int>> graph, bool[] visited, Stack<int> stack) {
    visited[node] = true;
    foreach (int neighbor in graph[node]) {
        if (!visited[neighbor])
            TopSort(neighbor, graph, visited, stack);
    }
    stack.Push(node); // add AFTER all descendants
}
```

**Approach 2 — Kahn's Algorithm (BFS with in-degree):**
```csharp
List<int> TopSort(int n, List<List<int>> graph) {
    int[] inDegree = new int[n];
    // calculate in-degrees
    Queue<int> queue = new Queue<int>();
    // enqueue all nodes with in-degree 0
    List<int> order = new List<int>();

    while (queue.Count > 0) {
        int node = queue.Dequeue();
        order.Add(node);
        foreach (int neighbor in graph[node]) {
            if (--inDegree[neighbor] == 0)
                queue.Enqueue(neighbor);
        }
    }
    return order; // if order.Count < n, cycle exists
}
```

**Use when:** Task scheduling, course prerequisites, build dependencies.

---

### Pattern 5: Shortest Path (BFS for unweighted)

**Concept:** BFS naturally finds the shortest path in unweighted graphs because it explores nodes level by level (distance 1, then 2, then 3...).

**Template:**
```csharp
int ShortestPath(List<List<int>> graph, int start, int end) {
    Queue<int> queue = new Queue<int>();
    bool[] visited = new bool[graph.Count];
    queue.Enqueue(start);
    visited[start] = true;
    int distance = 0;

    while (queue.Count > 0) {
        int size = queue.Count;
        for (int i = 0; i < size; i++) {
            int node = queue.Dequeue();
            if (node == end) return distance;
            foreach (int neighbor in graph[node]) {
                if (!visited[neighbor]) {
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
        }
        distance++;
    }
    return -1; // unreachable
}
```

---

### Pattern 6: Union-Find (Disjoint Set Union)

**Concept:** Efficiently track which nodes belong to the same component. Supports two operations: `Find` (which component?) and `Union` (merge two components).

**Template:**
```csharp
int[] parent;
int[] rank;

int Find(int x) {
    if (parent[x] != x)
        parent[x] = Find(parent[x]); // path compression
    return parent[x];
}

void Union(int x, int y) {
    int px = Find(x), py = Find(y);
    if (px == py) return;
    if (rank[px] < rank[py]) parent[px] = py;      // union by rank
    else if (rank[px] > rank[py]) parent[py] = px;
    else { parent[py] = px; rank[px]++; }
}
```

**Use when:** Dynamic connectivity, Kruskal's MST, redundant connections, accounts merge.

---

## Common Pitfalls

1. **Forgetting the visited array** → infinite loops in cyclic graphs
2. **Marking visited too late (BFS)** → node gets enqueued multiple times; mark visited when enqueuing, not when dequeuing
3. **Directed vs Undirected confusion** → undirected edge = two directed edges
4. **0-indexed vs 1-indexed nodes** → off-by-one errors in visited arrays
5. **Disconnected graphs** → always loop through ALL nodes, not just start from node 0

---

## Complexity Reference

| Algorithm | Time | Space |
|-----------|------|-------|
| DFS / BFS | O(V + E) | O(V) |
| Topological Sort | O(V + E) | O(V) |
| Union-Find (with optimizations) | O(α(n)) per operation ≈ O(1) | O(V) |
| Dijkstra (min-heap) | O((V + E) log V) | O(V) |
| Bellman-Ford | O(V × E) | O(V) |

---

## Interview Tips

- **Build the graph first.** Many problems don't give you an explicit graph — extract nodes and edges from the input (matrix, list of pairs, etc.)
- **Choose representation wisely.** If given an adjacency matrix, you can use it directly. Otherwise, build an adjacency list.
- **Start simple.** DFS/BFS solve the majority of graph interview problems. Only reach for Dijkstra, topo sort, or Union-Find when needed.
- **Think about what "visited" means.** Sometimes you need multiple states (unvisited, in-progress, done) instead of just boolean.
- **Grid problems are graph problems.** A 2D grid where you move up/down/left/right is an implicit graph — each cell is a node, and 4-directional movement defines edges.
