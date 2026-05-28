# LinkedList

A singly linked list implementation in C# script (`.csx`).

## Structure

```
Node
 ├── Data  (int)
 └── Next  (Node?)

LinkedList
 └── _head (Node?)  — private, points to first node
 └── Count (int)    — public property, tracks node count
```

Each `Node` holds a value and a pointer to the next node. `Node` is a private nested class — only `LinkedList` can access or manipulate nodes directly.

---

## Running

```powershell
dotnet script LinkedList.csx
```

---

## API Reference

### Insert

| Method | Returns | Description |
|---|---|---|
| `InsertAtStart(value)` | `void` | Prepends node to head |
| `InsertAtEnd(value)` | `void` | Appends node to tail |
| `InsertAt(index, value)` | `void` | Inserts at given index, throws if out of bounds |
| `InsertAtUsingSentinel(index, value)` | `void` | Same as `InsertAt` using sentinel pattern (no index==0 special case) |

### Remove

| Method | Returns | Description |
|---|---|---|
| `Remove(value)` | `bool` | Removes first node matching value, `false` if not found |
| `RemoveAt(index)` | `bool` | Removes node at index, `false` if out of bounds |
| `RemoveFromStart()` | `void` | Removes head node |
| `RemoveFromEnd()` | `void` | Removes tail node |

### Search / Traverse

| Method | Returns | Description |
|---|---|---|
| `FindNode(value)` | `Node?` | Returns node with matching value, `null` if not found |
| `FindPrevNode(value)` | `Node?` | Returns node before matching value, `null` if not found |
| `GetLastNode()` | `Node?` | Returns tail node, `null` if empty |

### Utility

| Method | Returns | Description |
|---|---|---|
| `Print()` | `void` | Prints list as `1 -> 2 -> 3 ->` with count |
| `IsEmpty()` | `bool` | `true` if list has no nodes |
| `Clear()` | `void` | Removes all nodes, resets count |
| `Count` | `int` | Number of nodes (property) |

---

## Key Concepts Used

### 1. Sentinel Node
A temporary dummy node placed before `_head` to eliminate the `index == 0` special case in insert/remove operations. The loop can traverse uniformly without branching for head.

```
sentinel → [head] → [node1] → [node2] → null
```

```csharp
var sentinel = new Node(0) { Next = _head };
var current = sentinel;
for (int i = 0; i < index; i++) current = current.Next;
current.Next = new Node(value) { Next = current.Next };
_head = sentinel.Next;  // restore real head
```

### 2. Prev Pointer
To delete or insert before a node, keep a trailing `prev` reference one step behind `current` during traversal.

```
prev → current → next
         ↑ target to delete
prev.Next = current.Next  → removes current
```

---

## Complexity

> 🟢 O(1) — constant time &nbsp;&nbsp; 🟠 O(n) — linear time

| Operation | Time | Space |
|---|---|---|
| InsertAtStart | 🟢 O(1) | 🟢 O(1) |
| InsertAtEnd | 🟠 O(n) | 🟢 O(1) |
| InsertAt(index) | 🟠 O(n) | 🟢 O(1) |
| InsertAtUsingSentinel(index) | 🟠 O(n) | 🟢 O(1) |
| Remove(value) | 🟠 O(n) | 🟢 O(1) |
| RemoveAt(index) | 🟠 O(n) | 🟢 O(1) |
| RemoveFromStart | 🟢 O(1) | 🟢 O(1) |
| RemoveFromEnd | 🟠 O(n) | 🟢 O(1) |
| FindNode | 🟠 O(n) | 🟢 O(1) |
| FindPrevNode | 🟠 O(n) | 🟢 O(1) |
| GetLastNode | 🟠 O(n) | 🟢 O(1) |
| IsEmpty | 🟢 O(1) | 🟢 O(1) |
| Clear | 🟢 O(1) | 🟢 O(1) |
| Count (property) | 🟢 O(1) | 🟢 O(1) |
