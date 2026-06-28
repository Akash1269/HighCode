# Legacy — Data Structures in C & Java

Classic data structure implementations and CTCI (Cracking the Coding Interview) problems.

## C Files

Each file is self-contained with its own `main()` and interactive menu.

| File | Data Structure | Description |
|---|---|---|
| [BinarySearchTree.c](BinarySearchTree.c) | Binary Search Tree | BST with traversals, search, insert, delete, mirror, copy, height |
| [LinkedList.c](LinkedList.c) | Singly Linked List | Full linked list operations: insert, delete, reverse, concatenate |
| [QueueUsingArray.c](QueueUsingArray.c) | Queue (Array) | Circular array-based queue with push/pop |
| [QueueUsingLinkedList.c](QueueUsingLinkedList.c) | Queue (Linked List) | Linked list-based queue with push/pop |
| [StackUsingArray.c](StackUsingArray.c) | Stack (Array) | Fixed-size array stack with push/pop |
| [StackUsingLinkedList.c](StackUsingLinkedList.c) | Stack (Linked List) | Linked list-based stack with push/pop |
| [LinkedListStudents/](LinkedListStudents/) | Linked List (Multi-file) | Student records database with set operations |

## Java — CTCI Problems

Self-contained Java files runnable with `java FileName.java` (Java 11+). Each file starts with `// Question -` and includes tags.

### Arrays & Strings

| File | Problem | Tags |
|---|---|---|
| [IsUniqueChars.java](DataStructuresInJava/ArraysAndStrings/IsUniqueChars.java) | All unique characters check | #string #hashset |
| [IsPermutation.java](DataStructuresInJava/ArraysAndStrings/IsPermutation.java) | Check if one string is permutation of another | #string #hashmap |
| [URLify.java](DataStructuresInJava/ArraysAndStrings/URLify.java) | Replace spaces with %20 in-place | #string #two-pointer |
| [PalindromePermutation.java](DataStructuresInJava/ArraysAndStrings/PalindromePermutation.java) | Check if string is permutation of a palindrome | #string #hashmap |
| [OneEditAway.java](DataStructuresInJava/ArraysAndStrings/OneEditAway.java) | Check if strings differ by one edit | #string #two-pointer |
| [StringCompression.java](DataStructuresInJava/ArraysAndStrings/StringCompression.java) | Run-length compression | #string |
| [RotateMatrix.java](DataStructuresInJava/ArraysAndStrings/RotateMatrix.java) | Rotate NxN matrix 90° in-place | #matrix #array |
| [ZeroMatrix.java](DataStructuresInJava/ArraysAndStrings/ZeroMatrix.java) | Zero out row/column on zero element | #matrix #array |
| [StringRotation.java](DataStructuresInJava/ArraysAndStrings/StringRotation.java) | Check if string is rotation of another | #string |

### Linked Lists

| File | Problem | Tags |
|---|---|---|
| [RemoveDuplicates.java](DataStructuresInJava/LinkedLists/RemoveDuplicates.java) | Remove duplicates from unsorted list | #linked-list #hashset |
| [KthToLastNode.java](DataStructuresInJava/LinkedLists/KthToLastNode.java) | Return kth to last element | #linked-list #two-pointer |
| [DeleteMiddleNode.java](DataStructuresInJava/LinkedLists/DeleteMiddleNode.java) | Delete node given only access to it | #linked-list #in-place |
| [PartitionList.java](DataStructuresInJava/LinkedLists/PartitionList.java) | Partition list around a value | #linked-list #partition |
| [AddTwoNumbers.java](DataStructuresInJava/LinkedLists/AddTwoNumbers.java) | Add numbers as linked lists | #linked-list #recursion |
| [LinkedListPalindrome.java](DataStructuresInJava/LinkedLists/LinkedListPalindrome.java) | Check if list is palindrome | #linked-list #stack |
| [ListIntersection.java](DataStructuresInJava/LinkedLists/ListIntersection.java) | Find intersection of two lists | #linked-list #two-pointer |
| [DetectLoop.java](DataStructuresInJava/LinkedLists/DetectLoop.java) | Find start of loop (Floyd's) | #linked-list #cycle-detection |
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
