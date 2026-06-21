# Priority Queue

A **Priority Queue** is an abstract data type that maintains a set **S** of elements, each associated with a key (priority). Elements are served based on their priority rather than insertion order.

## Underlying Data Structure

- Implemented using a **Heap** (see [Heap.md](Heap.md) for details)
- The heap provides efficient access to the highest (or lowest) priority element

## Core Operations

| Operation | Description | Time Complexity |
|---|---|---|
| `Insert(S, x)` | Insert element `x` into the set `S` | O(log n) |
| `Max(S)` | Return the element with the **largest** key (peek) | O(1) |
| `ExtractMax(S)` | Return **and remove** the element with the largest key | O(log n) |
| `IncreaseKey(S, x, k)` | Increase the key of element `x` to a new value `k` (e.g., raise its priority) | O(log n) |

> For a **Min Priority Queue**, the analogous operations are `Min`, `ExtractMin`, and `DecreaseKey`.

## How Operations Work (Under the Hood)

### Insert
1. Add the new element at the **end** of the underlying heap array
2. **Sift-Up** — repeatedly swap with parent until the heap property is restored
3. The element "bubbles up" to its correct priority position

### ExtractMax / ExtractMin
1. Save the **root** (highest priority element) to return
2. Move the **last** element in the array to the root position
3. **Sift-Down** (MaxHeapify / MinHeapify) — swap downward with the larger (or smaller) child until restored
4. Return the saved element

### IncreaseKey / DecreaseKey
1. Update the key value at the target position
2. **Sift-Up** from that position (the increased key may now be larger than its parent)

---

## C# Built-in: `PriorityQueue<TElement, TPriority>`

.NET 6+ provides a **min-priority queue** out of the box (lowest priority value is dequeued first):

```csharp
// Create a min-priority queue
var pq = new PriorityQueue<string, int>();

// Enqueue with priority
pq.Enqueue("low", 5);
pq.Enqueue("high", 1);
pq.Enqueue("medium", 3);

// Dequeue returns lowest priority first
pq.Dequeue();       // "high"  (priority 1)
pq.Peek();          // "medium" (priority 3) — peek without removing
pq.TryDequeue(out var element, out var priority); // safe dequeue

// Count
pq.Count;           // number of elements
```

| Method | Description | Time |
|---|---|---|
| `Enqueue(element, priority)` | Add element with given priority | O(log n) |
| `Dequeue()` | Remove and return lowest-priority element | O(log n) |
| `Peek()` | Return lowest-priority element without removing | O(1) |
| `TryDequeue()` / `TryPeek()` | Safe versions that return `false` if empty | O(log n) / O(1) |
| `Count` | Number of elements | O(1) |

> **Note:** C#'s `PriorityQueue` is a **min-heap** by default. For a max-heap, use a custom comparer:
> ```csharp
> var maxPq = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));
> ```

---

## Common Interview Patterns

| Pattern | Problem Examples | Key Idea |
|---|---|---|
| **Top-K Elements** | Kth Largest Element, Top K Frequent Words | Use a min-heap of size K; push elements, pop when size > K. The root is the Kth largest. |
| **Merge K Sorted** | Merge K Sorted Lists, Smallest Range Covering K Lists | Min-heap holds one element from each list; pop smallest, push next from that list. |
| **Streaming Median** | Find Median from Data Stream | Two heaps: max-heap for lower half, min-heap for upper half. Median is from the roots. |
| **Greedy + Heap** | Task Scheduler, Reorganize String, Meeting Rooms II | Use heap to always pick the best/largest/smallest next option greedily. |
| **Shortest Path** | Dijkstra's, Network Delay Time, Cheapest Flights | Min-heap as frontier; always expand the node with smallest cumulative cost. |
| **K-way Selection** | Kth Smallest in Sorted Matrix, Ugly Number II | Min-heap tracks candidates; pop one, push its successors. |

## When to Use

- **Task scheduling** — process higher-priority tasks first
- **Dijkstra's shortest path** — always expand the nearest unvisited node
- **Huffman encoding** — repeatedly extract the two lowest-frequency nodes
- **Merge K sorted lists** — efficiently track the smallest head across lists
