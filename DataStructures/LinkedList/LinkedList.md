# LinkedList — Learning Doc

## 1. Basic Concepts

**Linked List** — A linear data structure where elements (nodes) are stored in non-contiguous memory, connected via pointers. Unlike arrays, insertions/deletions don't require shifting elements.

### Node Structure (used across code files)

```csharp
// LeetCode-style (used in problem files)
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

// Implementation-style (used in Implementation/ folder)
class Node
{
    public int Data;
    public Node Next;       // Singly
    public Node Prev;       // Doubly (additional)
}
```

### Variants Implemented

| Type | Key Difference | File |
|---|---|---|
| Singly Linked List | Each node points to next only | [Implementation/LinkedList.csx](Implementation/LinkedList.csx) |
| Doubly Linked List | Each node points to next AND prev | [Implementation/DoublyLinkedList.csx](Implementation/DoublyLinkedList.csx) |
| Circular Linked List | Last node points back to first | [Implementation/CircularLinkedList.csx](Implementation/CircularLinkedList.csx) |

---

### Variant Deep Dives

#### Singly Linked List

```
[Data|Next] → [Data|Next] → [Data|Next] → null
     ^
    head
```

- **Structure:** Each node stores data + a single pointer to the next node
- **Traversal:** Forward only — no way to go backward
- **Delete a known node:** Need the *previous* node to unlink it (O(n) to find prev)
- **When to use:** Default choice for most problems; minimal memory overhead

**Key pattern — Prev pointer tracking:**
When deleting, always track `prev` as you traverse so you can do `prev.next = current.next`.

---

#### Doubly Linked List

```
null ← [Prev|Data|Next] ⇄ [Prev|Data|Next] ⇄ [Prev|Data|Next] → null
              ^
             head
```

- **Structure:** Each node stores data + pointer to next + pointer to prev
- **Traversal:** Both forward and backward
- **Delete a known node:** O(1) if you already have the node reference — just unlink via `node.prev.next = node.next`
- **Extra memory:** One additional pointer per node

**When to use over singly linked:**
- Need to traverse backward (e.g., browser history, undo/redo)
- Need O(1) deletion when you already have a reference to the node
- Implementing LRU Cache (doubly linked list + hashmap)
- Deque (double-ended queue) operations

**Key pattern — O(1) delete with known reference:**
```csharp
public void DeleteNode(Node node)
{
    if (node.Prev != null) node.Prev.Next = node.Next;
    else Head = node.Next; // deleting head

    if (node.Next != null) node.Next.Prev = node.Prev;
}
```

**Interview patterns using doubly linked list:**
| Pattern | Problem | Why Doubly? |
|---|---|---|
| LRU Cache | Design LRU Cache | O(1) move-to-front when a node is accessed via hashmap |
| LFU Cache | Design LFU Cache | O(1) removal from frequency bucket |
| Text Editor | Design Text Editor with cursor | Cursor can move left/right → needs prev pointer |
| Flatten Multi-level | Flatten Multilevel DLL | Child lists need prev/next reconnection |

---

#### Circular Linked List

```
┌─────────────────────────────────┐
│                                 ↓
[Data|Next] → [Data|Next] → [Data|Next]
                                  ^
                                 last
```

- **Structure:** The last node's `next` points back to the first node (no null)
- **Key pointer:** Often maintain a `last` pointer (not `head`) — because `last.next` gives you the head in O(1), and `last` gives you the tail in O(1)
- **Traversal:** Infinite loop unless you track the starting point
- **Termination condition:** `current != last` (or count-based)

**When to use:**
- Round-robin scheduling (tasks cycle endlessly)
- Circular buffers / queues
- Problems involving rotation (Josephus problem)
- When the "end" connects back to the "start" logically

**Key pattern — Traversal termination:**
```csharp
// Print all nodes in a circular list
public void Traverse(Node last)
{
    if (last == null) return;

    Node current = last.Next; // start at head
    do
    {
        Console.Write(current.Data + " → ");
        current = current.Next;
    } while (current != last.Next); // stop when we loop back
}
```

**Key pattern — Concatenation of two circular lists in O(1):**
```csharp
public void Concat(Node lastA, Node lastB)
{
    Node headA = lastA.Next;   // save head of first list
    lastA.Next = lastB.Next;   // first list's tail → second list's head
    lastB.Next = headA;        // second list's tail → first list's head
    // lastB is now the last of the merged circular list
}
```

**Interview patterns using circular linked list:**
| Pattern | Problem | Why Circular? |
|---|---|---|
| Josephus Problem | Find the winner in circular elimination | People sit in a circle; after last, it wraps to first |
| Circular Queue | Design Circular Queue | Reuse slots by wrapping index around |
| Rotation | Rotate List by K | Circular connection makes rotation a single pointer move |

---

### Variant Comparison Summary

| Aspect | Singly | Doubly | Circular |
|---|---|---|---|
| Memory per node | 1 pointer | 2 pointers | 1 pointer (singly circular) |
| Traverse backward | No | Yes | No (wraps forward) |
| Delete with node ref | O(n) — need prev | O(1) — has prev | O(n) — need prev |
| Insert at head | O(1) | O(1) | O(1) via last.next |
| Insert at tail | O(n) or O(1)* | O(n) or O(1)* | O(1) via last pointer |
| Detect end | `node.next == null` | `node.next == null` | `node.next == head` |
| Best for | General problems, minimal memory | LRU/LFU cache, bidirectional | Round-robin, rotation, Josephus |

---

### Common Operations & Complexities

| Operation | Singly | Doubly | Notes |
|---|---|---|---|
| Access by index | O(n) | O(n) | Must traverse from head |
| Insert at head | O(1) | O(1) | Reassign head pointer |
| Insert at tail | O(n) / O(1)* | O(n) / O(1)* | *O(1) if tail pointer maintained |
| Insert at index | O(n) | O(n) | Traverse to position first |
| Delete head | O(1) | O(1) | Reassign head |
| Delete by value | O(n) | O(n) | Find node, unlink |
| Search | O(n) | O(n) | Linear scan |
| Reverse | O(n) | O(n) | Pointer manipulation |

### Key Terminology

| Term | Meaning |
|---|---|
| Head | First node in the list |
| Tail | Last node (next = null in singly) |
| Sentinel / Dummy | A fake head node to simplify edge cases (no null-check for head) |
| Runner / Fast pointer | A pointer that moves 2 steps per iteration |
| Slow pointer | A pointer that moves 1 step per iteration |
| In-place | Modifying pointers without creating new nodes |

---

## 2. Pattern Summary

1. **"Use two speeds to find the middle or detect cycles"** — Slow & Fast Pointers (Tortoise & Hare)
   - Use when: Finding the middle node, detecting cycles, or finding the start of a cycle.
   - Think: "Do I need to find a position relative to the list's length without knowing it?"

2. **"Flip each pointer backward as you traverse forward"** — Iterative Reversal
   - Use when: Reversing all or part of a linked list.
   - Think: "Do I need to reverse pointer direction while keeping track of prev, current, and next?"

3. **"Split nodes into separate chains by some rule, then reconnect"** — Pointer Rearrangement / Partitioning
   - Use when: Separating nodes by position (odd/even), value, or condition while maintaining order.
   - Think: "Can I maintain two separate chains and stitch them together at the end?"

4. **"Recurse to the end, then pair with nodes from the front on the way back"** — Recursion as Reverse Traversal
   - Use when: You need to compare or combine nodes from both ends without actually reversing.
   - Think: "Can I use the call stack to visit nodes in reverse while a pointer tracks the forward direction?"

5. **"Use a dummy node to avoid special-casing the head"** — Sentinel Node
   - Use when: The head might change (deletion of first node, insertion before head).
   - Think: "Am I writing special-case code for head == null or head removal?"

---

## 3. Pattern Deep Dives

### Pattern 1: Slow & Fast Pointers (Tortoise & Hare)

**Concept:** Move one pointer at 1× speed and another at 2× speed. When fast reaches the end, slow is at the midpoint. If there's a cycle, they'll eventually meet. This eliminates the need to compute length first.

**Template:**
```csharp
public ListNode FindMiddle(ListNode head)
{
    ListNode slow = head, fast = head;
    ListNode prev = null; // track node before slow (useful for deletion)

    while (fast != null && fast.next != null)
    {
        prev = slow;
        slow = slow.next;
        fast = fast.next.next;
    }

    // slow is now at the middle
    // prev is the node just before middle
    return slow;
}
```

**Key Insight:** Fast travels 2n steps total while slow travels n — when fast hits the end, slow is exactly at the midpoint, no length calculation needed.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [DeleteMiddleNode.csx](DeleteMiddleNode.csx) | Delete the middle node | Use `prev` to unlink slow (the middle node) |
| [TwinListSum.csx](TwinListSum.csx) | Max twin sum (i + n-1-i) | Find middle to split list into two halves for reversal |

---

### Pattern 2: Iterative Reversal

**Concept:** Traverse the list once, at each node: save next, point current.next backward to prev, advance prev and current forward. After the loop, prev is the new head.

**Template:**
```csharp
public ListNode Reverse(ListNode head)
{
    ListNode prev = null;
    ListNode current = head;

    while (current != null)
    {
        ListNode next = current.next;  // save next
        current.next = prev;           // reverse pointer
        prev = current;                // advance prev
        current = next;                // advance current
    }

    return prev; // new head
}
```

**Key Insight:** You only need three pointers (prev, current, next) — each node is visited exactly once and its pointer is flipped in O(1).

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [LinkedListReverse.csx](LinkedListReverse.csx) | Reverse entire linked list | Direct application of the template |
| [TwinListSum.csx](TwinListSum.csx) | Reverse second half for twin sum | Reverse only from middle onward, then walk both halves |

---

### Pattern 3: Pointer Rearrangement / Partitioning

**Concept:** Maintain two (or more) separate chains using extra pointers. Traverse the original list, routing each node to the appropriate chain based on a condition. Finally, stitch the chains together.

**Template:**
```csharp
public ListNode Partition(ListNode head)
{
    ListNode groupAHead = new ListNode(); // dummy
    ListNode groupBHead = new ListNode(); // dummy
    ListNode tailA = groupAHead, tailB = groupBHead;
    ListNode current = head;

    while (current != null)
    {
        if (BelongsToGroupA(current))
        {
            tailA.next = current;
            tailA = tailA.next;
        }
        else
        {
            tailB.next = current;
            tailB = tailB.next;
        }
        current = current.next;
    }

    tailB.next = null;              // terminate group B
    tailA.next = groupBHead.next;   // stitch A → B

    return groupAHead.next;
}
```

**Key Insight:** By building separate chains you avoid complex pointer swapping — just route nodes and connect at the end.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [OddEvenSeperated.csx](OddEvenSeperated.csx) | Separate odd-indexed and even-indexed nodes | Route even-index nodes to a second chain; connect after last odd node |

---

### Pattern 4: Recursion as Reverse Traversal

**Concept:** Recurse all the way to the end of the list. On the way back (as the stack unwinds), each recursive call processes nodes from the tail toward the head. Pair this with a forward-moving pointer to compare or sum nodes from both ends simultaneously.

**Template:**
```csharp
public ListNode RecurseFromEnd(ListNode forwardPtr, ListNode current, ref int result)
{
    if (current == null) return forwardPtr; // base case: start forward ptr

    ListNode paired = RecurseFromEnd(forwardPtr, current.next, ref result);

    // 'current' is from the end, 'paired' is from the start
    result = Math.Max(result, paired.val + current.val);

    return paired.next; // advance forward pointer
}
```

**Key Insight:** The call stack implicitly reverses traversal — you get O(n) space "reversal" without modifying any pointers.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [TwinListSum.csx](TwinListSum.csx) | Max twin pair sum (recursive approach) | Recurse to end; pair with head advancing forward via return value |

---

### Pattern 5: Sentinel (Dummy) Node

**Concept:** Create a dummy node that points to head. All operations work on `sentinel.next` instead of `head` directly. This eliminates edge cases where the head itself is deleted or a new node is inserted before head.

**Template:**
```csharp
public ListNode OperationWithSentinel(ListNode head)
{
    ListNode sentinel = new ListNode(0);
    sentinel.next = head;
    ListNode current = sentinel;

    while (current.next != null)
    {
        if (ShouldRemove(current.next))
        {
            current.next = current.next.next; // skip node
        }
        else
        {
            current = current.next;
        }
    }

    return sentinel.next; // new head (might differ from original)
}
```

**Key Insight:** With a sentinel, `head` is never a special case — the code for deleting the first node is identical to deleting any other node.

**Applied in:**

| File | Problem | What's Specific |
|---|---|---|
| [Implementation/LinkedList.csx](Implementation/LinkedList.csx) | InsertAtUsingSentinel | Sentinel avoids index==0 special case for insertion |
| [OddEvenSeperated.csx](OddEvenSeperated.csx) | Even list uses dummy head | `evenHead = new ListNode()` as accumulator for even-indexed nodes |

---

## 4. Additional Interview Patterns (Not Yet Practiced)

1. **"Detect if the train track loops back on itself"** — Cycle Detection (Floyd's Algorithm)
   - Use when: Determine if a linked list has a cycle, or find where the cycle begins.
   - Think: "If I run two pointers at different speeds, will they ever meet?"
   - Example problems: Linked List Cycle, Linked List Cycle II, Find the Duplicate Number

2. **"Merge two sorted lines into one sorted line without extra space"** — Merge Two Sorted Lists
   - Use when: Combining two sorted linked lists into one sorted result.
   - Think: "Can I compare heads and always pick the smaller, advancing that pointer?"
   - Example problems: Merge Two Sorted Lists, Merge K Sorted Lists, Sort List

3. **"Reverse only a section of the chain"** — Reverse Sublist (Between positions)
   - Use when: Reversing nodes between index `m` and `n` without reversing the whole list.
   - Think: "Can I isolate the sublist, reverse it, and reconnect the boundaries?"
   - Example problems: Reverse Linked List II, Reverse Nodes in K-Group, Swap Nodes in Pairs

4. **"Two lists walk to each other's starting point to meet at the junction"** — Intersection of Two Lists
   - Use when: Finding the node where two linked lists converge.
   - Think: "If I redirect each pointer to the other list's head when it finishes, will they meet at the intersection?"
   - Example problems: Intersection of Two Linked Lists

5. **"Remove the Nth node by giving the fast pointer an N-step head start"** — N-th From End
   - Use when: Deleting or finding the Nth node from the end in a single pass.
   - Think: "If fast starts N ahead, when fast hits null, slow is at the target."
   - Example problems: Remove Nth Node From End, Middle of the Linked List

6. **"Rearrange nodes to form a palindrome-checkable sequence"** — Palindrome Linked List
   - Use when: Checking if a linked list reads the same forward and backward.
   - Think: "Find middle → reverse second half → compare both halves."
   - Example problems: Palindrome Linked List

7. **"Flatten or copy a list with random pointers using interleaving"** — Deep Copy / Flatten
   - Use when: Copying a list where nodes have random pointers, or flattening multi-level lists.
   - Think: "Can I interleave copies with originals to map random pointers without a hash map?"
   - Example problems: Copy List with Random Pointer, Flatten a Multilevel Doubly Linked List

8. **"Carry digits through nodes like manual addition"** — Add Two Numbers
   - Use when: Numbers are represented as linked lists (each node = one digit).
   - Think: "Traverse both lists simultaneously, sum digits + carry, create result nodes."
   - Example problems: Add Two Numbers, Add Two Numbers II

---

## 5. Problem Difficulty Progression

| # | Problem | File | Difficulty | Key Pattern |
|---|---|---|---|---|
| 1 | Reverse Linked List | [LinkedListReverse.csx](LinkedListReverse.csx) | Easy | Iterative Reversal |
| 2 | Delete Middle Node | [DeleteMiddleNode.csx](DeleteMiddleNode.csx) | Medium | Slow & Fast Pointers |
| 3 | Odd-Even Separated | [OddEvenSeperated.csx](OddEvenSeperated.csx) | Medium | Pointer Rearrangement |
| 4 | Max Twin Sum | [TwinListSum.csx](TwinListSum.csx) | Medium | Fast/Slow + Reversal + Recursion |

---

## 6. Quick Reference: When to Use What

| Signal / Situation | Pattern | Why |
|---|---|---|
| "Find the middle node" | Slow & Fast Pointers | Fast hits end → slow at middle |
| "Detect a cycle" | Slow & Fast Pointers | Different speeds guarantee meeting in a loop |
| "Reverse the list" | Iterative Reversal (prev/curr/next) | O(1) space, single pass |
| "Compare from both ends" | Find middle + Reverse second half | Creates two forward-traversable halves |
| "Compare from both ends (no modification)" | Recursion as reverse traversal | Call stack gives reverse access |
| "Separate by position/condition" | Pointer Rearrangement | Route into chains, stitch together |
| "Head might be deleted/changed" | Sentinel Node | Eliminates head special case |
| "Nth from end in one pass" | Two pointers with N-gap | Fast starts N ahead of slow |
| "Merge two sorted lists" | Two-pointer merge | Compare heads, pick smaller |
| "Add digit-by-digit" | Simultaneous traversal + carry | Walk both lists, sum + carry forward |
