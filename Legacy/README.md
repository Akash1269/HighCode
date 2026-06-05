# Legacy — Data Structures in C

Classic data structure implementations written in C as part of a DSPD (Data Structures & Program Design) course. Each file is self-contained with its own `main()` and interactive menu.

## Files

| File | Data Structure | Description |
|---|---|---|
| [BinarySearchTree.c](BinarySearchTree.c) | Binary Search Tree | BST with traversals, search, insert, delete, mirror, copy, height |
| [LinkedList.c](LinkedList.c) | Singly Linked List | Full linked list operations: insert, delete, reverse, concatenate |
| [QueueUsingArray.c](QueueUsingArray.c) | Queue (Array) | Circular array-based queue with push/pop |
| [QueueUsingLinkedList.c](QueueUsingLinkedList.c) | Queue (Linked List) | Linked list-based queue with push/pop |
| [StackUsingArray.c](StackUsingArray.c) | Stack (Array) | Fixed-size array stack with push/pop |
| [StackUsingLinkedList.c](StackUsingLinkedList.c) | Stack (Linked List) | Linked list-based stack with push/pop |
| [LinkedListStudents/](LinkedListStudents/) | Linked List (Multi-file) | Student records database with set operations |
| [ArraryLibrary/](ArraryLibrary/) | Array (Multi-file) | Library management system with set operations |

## BinarySearchTree.c

**Types:** `key`, `data`, `tree` (BST node), `q` (queue for BFS)

| Function | Description |
|---|---|
| `createTree` | Constructs a hardcoded 3-node tree |
| `insert` | Inserts a node into the BST |
| `delete_node` | Deletes a node (handles leaf, one child, two children) |
| `search` | Searches for a node by key |
| `preOrder` / `inOrder` / `postOrder` | Recursive DFS traversals |
| `bredthFirst` | Level-order BFS traversal using a queue |
| `numNodes` / `numLeaves` / `height` | Tree property calculations |
| `copy` | Deep copy of the tree |
| `mirrorImg` | Converts tree to its mirror image in-place |

## LinkedList.c

**Types:** `node` (singly linked)

| Function | Description |
|---|---|
| `create_list` | Creates a list of `n` nodes |
| `print_list` | Prints all node values |
| `delete_list` | Frees all nodes |
| `insert_at_start` / `insert_at_end` | Insert operations |
| `delet_at_start` / `delet_at_end` | Delete operations |
| `concate` | Concatenates two lists |
| `reverse_list` | Reverses list in-place (3-pointer technique) |
| `insert_after` / `insert_before` / `insert_bet` | Positional inserts |
| `delete_after_node` | Deletes the node after a given node |

## QueueUsingArray.c

**Types:** `queue` (circular array with `front`, `rear`, `count`)

| Function | Description |
|---|---|
| `initialize` | Resets queue to empty |
| `push` | Enqueues with circular rear increment |
| `pop` | Dequeues from front |

## QueueUsingLinkedList.c

**Types:** `node`, `queue` (front/rear pointers)

| Function | Description |
|---|---|
| `initialize` | Sets front/rear to NULL |
| `push` | Appends new node at rear |
| `pop` | Removes front node |

## StackUsingArray.c

**Types:** `stack` (fixed-size array with `top` index)

| Function | Description |
|---|---|
| `initialize` | Sets top to 0 |
| `push` | Pushes element (checks overflow) |
| `pop` | Pops element (checks underflow) |

## StackUsingLinkedList.c

**Types:** `node`, `stack` (top pointer)

| Function | Description |
|---|---|
| `initialize` | Sets top to NULL |
| `push` | Prepends new node as top |
| `pop` | Removes top node |
