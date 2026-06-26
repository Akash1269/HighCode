# Heap

A **Heap** is an array-based data structure visualized as a **complete binary tree** (every level is fully filled except possibly the last, which is filled left to right). It is the standard implementation behind a Priority Queue.

## Heap Property

| Type | Rule (applied recursively) |
|---|---|
| **Max Heap** | Key of every node ≥ keys of its children |
| **Min Heap** | Key of every node ≤ keys of its children |

**Example (Max Heap):** `16, 14, 10, 8, 7, 9, 3, 2, 4, 1`

```
              16(1)
            /      \
         14(2)     10(3)
        /    \     /    \
      8(4)  7(5) 9(6)  3(7)
     / \    /
   2(8) 4(9) 1(10)
```

> Node labels show `value(index)`. Notice: parent of index `i` is at `i/2`, left child at `2i`, right child at `2i+1`.

## Array-to-Tree Index Mapping

Since a heap is stored as an array, tree relationships are computed by index (1-based):

| Relationship | Formula |
|---|---|
| Root | `i = 1` |
| Parent of node `i` | `i / 2` |
| Left child of node `i` | `2i` |
| Right child of node `i` | `2i + 1` |

## Key Properties

- **Height** of a heap with `n` elements is always $\lfloor \log_2(n) \rfloor$
- Elements from index `n/2 + 1` to `n` are **always leaves**, regardless of `n`

---

## Heap Operations

### 1. MaxHeapify — O(log n)

Corrects a **single violation** of the max-heap property at a given node, assuming both subtrees are already valid max heaps.

**Algorithm:**
1. Compare node `i` with its left child `2i` and right child `2i + 1`
2. Swap `i` with the **larger** child if the child is greater
3. Recurse on the swapped child's subtree

> Works **top-down** from the violation point. Leaves are trivially valid max heaps, so heapify naturally operates bottom-up during build.

### 2. BuildMaxHeap — O(n)

Converts an **unordered array** into a valid max heap.

```
BuildMaxHeap(A):
    for i = n / 2 down to 1
        MaxHeapify(A, i)
```

**Why start at `n/2`?** Nodes from `n/2 + 1` to `n` are leaves — they already satisfy the heap property.

#### Complexity Analysis

The naive bound is $O(n \log n)$ (calling $O(\log n)$ heapify $n/2$ times), but a tighter analysis shows **O(n)**:

- Leaves (half the nodes) require **0** work
- Nodes one level above leaves require **1** swap
- The root requires at most $\log n$ swaps

Summing the work across all levels:

$$\sum_{k=0}^{\lfloor \log n \rfloor} \frac{n}{2^{k+1}} \cdot O(k) = O\!\left(n \sum_{k=0}^{\infty} \frac{k}{2^k}\right) = O(n)$$

The series $\sum \frac{k}{2^k}$ converges to 2, giving a total of **O(n)**.

### 3. Sift-Up (Bubble Up) — O(log n)

Moves a node **upward** to restore the heap property. Used when a node's key becomes larger than its parent (e.g., after Insert or IncreaseKey).

**Algorithm:**
1. Compare node `i` with its parent `i / 2`
2. If node `i` is **greater** than its parent, swap them
3. Repeat from the parent's position until the root is reached or no swap is needed

> Sift-Up is the **counterpart** to MaxHeapify (Sift-Down). MaxHeapify pushes violations downward; Sift-Up pushes them upward.

### 4. Insert — O(log n)

Adds a new element to the heap.

**Algorithm:**
1. Place the new element at the **end** of the array (next available leaf position)
2. Increment heap size
3. **Sift-Up** from the new element's position to restore the heap property

### 5. Delete Arbitrary Node — O(log n)

Removes any node from the heap (not just the root).

**Algorithm:**
1. Swap the target node with the **last** element in the heap
2. Shrink the heap size by 1
3. At the swapped position, **Sift-Up or Sift-Down** as needed — compare with parent and children to determine direction

### 6. HeapSize

Returns the current number of elements in the heap.

---

## Min Heap Operations

All max-heap operations have min-heap equivalents — just reverse the comparison:

| Max Heap Operation | Min Heap Equivalent | Difference |
|---|---|---|
| MaxHeapify (sift-down) | MinHeapify | Swap with the **smaller** child |
| Sift-Up | Sift-Up (min) | Swap if node is **less than** parent |
| BuildMaxHeap | BuildMinHeap | Uses MinHeapify instead |
| ExtractMax | ExtractMin | Removes the **root** (smallest element) |

> Min heaps are **more common in interviews** — Dijkstra's algorithm, finding the K smallest elements, and median-from-stream all use min heaps.

---

## Heap vs Binary Search Tree

| Aspect | Heap | BST |
|---|---|---|
| **Find min/max** | O(1) — root | O(log n) — leftmost/rightmost |
| **Search for key** | O(n) — no ordering between siblings | O(log n) — ordered |
| **Insert** | O(log n) | O(log n) |
| **Delete** | O(log n) | O(log n) |
| **In-order traversal** | Not meaningful | Gives sorted order |
| **Build from array** | O(n) | O(n log n) |
| **Use when** | Only need min/max access | Need search, range queries, sorted iteration |

---

## HeapSort — O(n log n)

Uses the max-heap structure to sort an array in ascending order.

**Algorithm:**
1. **Build** a max heap from the unordered array — O(n)
2. The maximum element is at `A[1]`
3. **Swap** `A[1]` with `A[n]` — the max is now at the end (sorted position)
4. **Shrink** the heap size by 1 (exclude the last element)
5. **Heapify** the new root to restore the max-heap property — O(log n)
6. Repeat steps 2–5 until the heap size is 1

| Step | Complexity |
|---|---|
| Build max heap | O(n) |
| Extract max × (n − 1) | O(n log n) |
| **Total** | **O(n log n)** |

> HeapSort is **in-place** (no extra array needed) but **not stable** (equal elements may be reordered).

---

## Common Patterns Where Heap is Used

### 1. Maintain a Running Max/Min

When you need to repeatedly access the largest or smallest element as data changes.

- **Signal:** "Find the maximum/minimum after each insertion/deletion"
- **Why heap:** O(1) peek, O(log n) insert/remove — faster than re-sorting every time
- **Example:** Sliding Window Maximum (use a max-heap with lazy deletion)

### 2. Top-K / Kth Element

Find the K largest or Kth largest element in a stream or array.

- **Signal:** "Kth largest", "K most frequent", "K closest points"
- **Why heap:** Keep a min-heap of size K. Every element larger than the root replaces it. Root is always the Kth largest.
- **Complexity:** O(n log K) — better than sorting O(n log n) when K << n

### 3. Merge K Sorted Sequences

Combine K sorted arrays/lists/streams into one sorted output.

- **Signal:** "Merge K sorted lists", "smallest range covering elements from K lists"
- **Why heap:** Min-heap of size K holds one candidate from each list. Pop the smallest, push its successor.
- **Complexity:** O(N log K) where N = total elements

### 4. Greedy Scheduling / Resource Allocation

Repeatedly pick the "best" next choice based on some priority.

- **Signal:** "Schedule tasks", "minimize cost", "reorganize string", "meeting rooms"
- **Why heap:** Greedy requires picking the optimal element each step; heap gives that in O(log n)
- **Example:** Task Scheduler — always pick the task with the highest remaining count

### 5. Two-Heap Technique (Median Maintenance)

Maintain two heaps to track a running median.

- **Signal:** "Find median from data stream", "balance two halves"
- **How:** Max-heap for lower half, min-heap for upper half. Balance sizes after each insert. Median is at one or both roots.
- **Complexity:** O(log n) per insert, O(1) median query

### 6. Shortest Path / Minimum Cost Expansion

Expand from the cheapest node at each step.

- **Signal:** "Shortest path", "minimum spanning tree", "network delay"
- **Why heap:** Dijkstra's and Prim's algorithms use a min-heap to always process the lowest-cost frontier node
- **Complexity:** O((V + E) log V) with a binary heap

### 7. Heap as a Sorting Tool

When you need partial sorting (not full) or in-place sort.

- **Signal:** "Sort a nearly sorted array" (K-sorted), "sort in-place without extra space"
- **Why heap:** A K-sorted array can be fully sorted with a min-heap of size K in O(n log K)
- **HeapSort:** Full in-place sort in O(n log n) with no extra memory

---

### Quick Decision: Do I Need a Heap?

Ask yourself:
1. Do I need the **min or max** element repeatedly? → **Yes, use heap**
2. Do I need to **search** for arbitrary elements? → **No, use BST or HashMap**
3. Do I need **sorted order** of all elements? → **Sort the array or use BST**
4. Is the data **streaming** (elements arrive one by one)? → **Heap handles this naturally**

---

## Applied In

### Pattern 1 — Maintain a Running Max/Min

| File | Notes |
|---|---|
| [SmallestInfiniteSet.csx](SmallestInfiniteSet.csx) | Min-heap + HashSet to track smallest available number; optimized by tracking a `smallest` boundary |

### Pattern 2 — Top-K / Kth Element

| File | Notes |
|---|---|
| [KthLargest.csx](KthLargest.csx) | Min-heap of size k — root is the kth largest element |
| [KthLargestStream.csx](KthLargestStream.csx) | Same min-heap-of-size-k technique applied to a stream with repeated `add()` calls |

### Pattern 4 — Greedy Scheduling / Resource Allocation

| File | Notes |
|---|---|
| [CostOfHiringKWorkers.csx](CostOfHiringKWorkers.csx) | Two min-heaps (left/right candidates) — greedily pick cheapest worker each round |
| [MaxSubsequenceScore.csx](MaxSubsequenceScore.csx) | Sort by one dimension, then use min-heap of size k to maintain best sum while iterating |

---

## Difficulty Progression

| File | Difficulty | Pattern(s) |
|---|---|---|
| [KthLargest.csx](KthLargest.csx) | Medium | Top-K |
| [KthLargestStream.csx](KthLargestStream.csx) | Easy | Top-K |
| [SmallestInfiniteSet.csx](SmallestInfiniteSet.csx) | Medium | Maintain Running Min |
| [CostOfHiringKWorkers.csx](CostOfHiringKWorkers.csx) | Medium | Greedy Scheduling |
| [MaxSubsequenceScore.csx](MaxSubsequenceScore.csx) | Hard | Greedy Scheduling, Top-K |

---

## Quick Reference

| Cue / Signal | Pattern | Example File |
|---|---|---|
| "Kth largest/smallest element" | Top-K | KthLargest.csx |
| "Stream of data + return kth element on each add" | Top-K (streaming) | KthLargestStream.csx |
| "Choose k items to minimize cost / maximize score" | Greedy Scheduling | CostOfHiringKWorkers.csx |
| "Maximize product of sum × minimum" | Greedy + Sort + Heap | MaxSubsequenceScore.csx |
| "Pop smallest / add back with duplicates" | Running Min + HashSet | SmallestInfiniteSet.csx |
