# Queue — Learning Doc

## 1. Basic Concepts

**Queue** — A linear data structure following **FIFO** (First In, First Out). The first element added is the first one removed. Think of it as a line at a counter — first person in line gets served first.

### Structure (used across code files)

```csharp
// C# built-in (used in problem files)
var queue = new Queue<T>();

// Array-based implementation (circular)
class Queue
{
    int[] list;
    int front; // index of first element
    int rear;  // index of last element
    int size;  // current element count
}

// LinkedList-based implementation
class Queue
{
    Node Front; // dequeue from here
    Node Rear;  // enqueue here
    class Node { int Data; Node Next; }
}
```

### Implementations

| Type | Pros | Cons | File |
|---|---|---|---|
| Array-based (circular) | Cache-friendly, fixed memory | Fixed capacity, wrap-around logic | [Implementation/QueueUsingArray.csx](./Implementation/QueueUsingArray.csx) |
| LinkedList-based | Dynamic size, simple enqueue/dequeue | Extra pointer memory per element | [Implementation/QueueUsingList.csx](./Implementation/QueueUsingList.csx) |
| C# `Queue<T>` | Dynamic, built-in, optimized | — | Used in all problem files |

### Core Operations & Complexities

| Operation | Description | Time |
|---|---|---|
| `Enqueue(x)` | Add element to the rear | O(1) |
| `Dequeue()` | Remove and return front element | O(1) |
| `Peek()` | Return front element without removing | O(1) |
| `Count` | Number of elements | O(1) |

### Key Terminology

| Term | Meaning |
|---|---|
| Front | The oldest element (first to be dequeued) |
| Rear | The newest element (last enqueued) |
| FIFO | First In, First Out — the core principle |
| Circular Queue | Array-based queue where rear wraps around to index 0 when it reaches the end |
| BFS Queue | Queue used as the frontier in Breadth-First Search (level by level) |

### Circular Queue — Why?

In a naive array queue, `front` advances on dequeue leaving wasted space at the start. A circular queue wraps indices using modulo:
```csharp
rear = (rear + 1) % MAX_SIZE;
front = (front + 1) % MAX_SIZE;
```
This reuses vacated slots without shifting elements.

---

## 2. Pattern Summary

1. **"Discard old elements that fall outside a sliding time/index window"** — Queue as Sliding Window Filter
   - Use when: You need to count or process only elements within a recent time range or index distance.
   - Think: "Can I dequeue from the front everything that's too old, and enqueue new arrivals at the back?"

2. **"Simulate rounds where participants cycle back until eliminated"** — Round-Robin Simulation with Re-enqueue
   - Use when: A process repeats in rounds — elements get processed, and survivors re-enter the queue for the next round.
   - Think: "Do participants loop through multiple rounds, with some being eliminated each cycle?"

---

## 3. Pattern Deep Dives

### Pattern 1: Queue as Sliding Window Filter

**Concept:** Enqueue every new event/timestamp. Before answering a query, dequeue all front elements that have "expired" (fallen outside the valid window). The queue always holds exactly the valid elements, so `Count` gives the answer instantly.

**Template:**
```csharp
public class WindowCounter
{
    Queue<int> queue = new Queue<int>();
    int windowSize;

    public WindowCounter(int windowSize)
    {
        this.windowSize = windowSize;
    }

    public int Add(int timestamp)
    {
        queue.Enqueue(timestamp);

        // Remove expired elements from front
        while (queue.Count > 0 && queue.Peek() < timestamp - windowSize)
            queue.Dequeue();

        return queue.Count;
    }
}
```

**Key Insight:** Because timestamps arrive in order, expired elements are always at the front — FIFO order guarantees a single `while` loop cleans them up without scanning the whole structure.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [RecentCall.csx](./RecentCall.csx) | Count requests in last 3000ms | Enqueue each ping time; dequeue anything < t - 3000; return Count |

---

### Pattern 2: Round-Robin Simulation with Re-enqueue

**Concept:** Use separate queues (or one queue with tagging) to model participants in repeating rounds. Each round, dequeue from both sides, the winner re-enters the queue (with an incremented index to represent the next round), and the loser is eliminated. Repeat until one side is empty.

**Template:**
```csharp
public string SimulateRounds(string participants)
{
    var queueA = new Queue<int>();
    var queueB = new Queue<int>();
    int n = participants.Length;

    // Initialize: enqueue indices by team
    for (int i = 0; i < n; i++)
    {
        if (participants[i] == 'A') queueA.Enqueue(i);
        else queueB.Enqueue(i);
    }

    // Simulate rounds
    while (queueA.Count > 0 && queueB.Count > 0)
    {
        int posA = queueA.Dequeue();
        int posB = queueB.Dequeue();

        // Lower index acts first (earlier in the round)
        if (posA < posB)
            queueA.Enqueue(posA + n); // winner re-enters next round
        else
            queueB.Enqueue(posB + n);
    }

    return queueA.Count == 0 ? "B wins" : "A wins";
}
```

**Key Insight:** Adding `+ n` to the re-enqueued index ensures the winner is placed *after* all current-round participants — simulating "goes to the back of the line for the next cycle" without tracking explicit round numbers.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [Dota2Senator.csx](./Dota2Senator.csx) | Radiant vs Dire senator banning | Two queues of indices; lower index senator bans the other; winner re-enters with `+ n` for the next round |

---

## 4. Additional Interview Patterns (Not Yet Practiced)

*Based on general knowledge of common LeetCode/interview patterns for queues, not found in the analyzed code.*

1. **"Explore all neighbors at distance 1, then distance 2, then distance 3..."** — BFS Level-Order Traversal
   - Use when: Shortest path in unweighted graph, level-order tree traversal, or exploring states layer by layer.
   - Think: "Do I need to process all nodes at the current depth before moving deeper?"
   - Example problems: Binary Tree Level Order Traversal, Shortest Path in Binary Matrix, Rotting Oranges, Word Ladder

2. **"Process the front item, generate new items, and enqueue them for later"** — BFS State Expansion
   - Use when: You need to explore all reachable states from a start state (puzzle solving, grid BFS, multi-source BFS).
   - Think: "Can I model this as a graph where each state generates successor states?"
   - Example problems: Open the Lock, Minimum Knight Moves, Sliding Puzzle, Walls and Gates

3. **"Keep only useful candidates in the window by discarding weaker ones from the back"** — Monotonic Deque (Sliding Window Max/Min)
   - Use when: Finding the max or min in every sliding window of size K in O(n).
   - Think: "Can I maintain a deque where front is always the best, and I discard from the back anything the new element dominates?"
   - Example problems: Sliding Window Maximum, Shortest Subarray with Sum at Least K, Constrained Subsequence Sum

4. **"Interleave or reorganize elements so no two adjacent are the same"** — Queue-Based Rearrangement
   - Use when: Rearranging elements with spacing constraints (no two same tasks within K distance).
   - Think: "Can I use a queue as a cooldown buffer — re-enqueue after K steps?"
   - Example problems: Task Scheduler, Reorganize String, Rearrange String K Distance Apart

5. **"Implement one ADT using another as the only building block"** — Stack Using Queues / Queue Using Stacks
   - Use when: Interview asks you to implement a stack with only queue operations or vice versa.
   - Think: "Can I use two queues and move elements around to simulate LIFO?"
   - Example problems: Implement Stack using Queues, Implement Queue using Stacks

---

## 5. Problem Difficulty Progression

| # | Problem | File | Difficulty | Key Pattern |
|---|---|---|---|---|
| 1 | Recent Counter (Ping) | [RecentCall.csx](./RecentCall.csx) | Easy | Queue as Sliding Window Filter |
| 2 | Dota2 Senate | [Dota2Senator.csx](./Dota2Senator.csx) | Medium | Round-Robin Simulation with Re-enqueue |

---

## 6. Quick Reference: When to Use What

| Signal / Situation | Pattern | Why |
|---|---|---|
| "Count/track events in the last N time units" | Sliding Window Filter | Expired events are always at front; dequeue to trim |
| "Participants take turns in cycles; losers are eliminated" | Round-Robin Simulation | Queue models circular turn order; re-enqueue survivors |
| "Shortest path in unweighted graph" | BFS (level order) | Queue processes all nodes at distance d before d+1 |
| "Explore all states reachable from start" | BFS State Expansion | Queue = frontier of unexplored states |
| "Max/min in every window of size K" | Monotonic Deque | Deque front = window's optimal; back is pruned |
| "Space tasks K apart" | Queue as Cooldown Buffer | Dequeue back into ready pool after K time steps |
| "Implement stack with queues (or vice versa)" | ADT Simulation | Transfer between two queues to flip order |

---

## 7. The Queue Intuition

**When to reach for a queue:**

Ask yourself: *"Does the problem need to process things in the order they arrived?"*

If the answer to any of these is yes, a queue likely helps:
- Do I need **first-come, first-served** processing?
- Am I exploring **level by level** (BFS)?
- Do elements **cycle back** for future rounds?
- Do I need to **expire/discard the oldest** items first?
- Am I simulating a **real-world line** (task scheduling, printer queue, CPU scheduling)?

The queue's power is that it always gives you the **oldest unprocessed item** in O(1) — the natural opposite of a stack.
