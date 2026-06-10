# Binary Search Tree (BST) — Implementation Guide

## What is a BST?

A Binary Search Tree is a binary tree where every node follows one rule:

> **Left child < Parent < Right child**

This property holds for the entire subtree — not just direct children, but ALL descendants.

```
        8
       / \
      3   10
     / \    \
    1   6    14
       / \   /
      4   7 13
```

**Why it matters:** This ordering gives us O(log n) search, insert, and delete on average — same as binary search on a sorted array, but with dynamic insertion.

**Worst case:** If you insert sorted data (1, 2, 3, 4...) the tree becomes a linked list → O(n). Balanced BSTs (AVL, Red-Black) solve this.

---

## Node Structure

```csharp
class Node {
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}
```

---

## Operations

### Insert — `Insert(int data)` → O(log n) avg

**Approach:** Start at root. If data < current, go left. If data > current, go right. When you hit a null spot, place the new node there.

**Key detail:** Duplicates are rejected (returns false).

**Why iterative:** No recursion stack overhead. Simple while loop following BST property downward.

---

### Find — `FindNode(int data)` → O(log n) avg

**Approach:** Same traversal as insert — compare and go left/right. Stop when found or hit null.

**Key insight:** BST property eliminates half the tree at each step (like binary search).

---

### Delete — `Delete(int data)` → O(log n) avg

**The hardest BST operation.** Three cases after finding the node:

| Case | Condition | Action |
|------|-----------|--------|
| **Leaf** | No children | Simply remove (set parent's pointer to null) |
| **One child** | Left or right is null | Replace node with its only child |
| **Two children** | Both children exist | Find **in-order predecessor** (rightmost node of left subtree), attach right subtree to it |

**Approach used (Case A):** Find the rightmost node in the left subtree (the largest value smaller than current). Attach the right subtree as this node's right child. Replace deleted node with its left child.

**Alternative approaches (commented in code):**
- **Case B:** Find leftmost node of right subtree (in-order successor), attach left subtree to it
- **Case C:** Swap values with in-order predecessor, then delete the predecessor node

---

## Traversals

All traversals visit every node exactly once → O(n).

### PreOrder — `PreOrder()` → Root → Left → Right

**Use for:** Copying/serializing a tree (root first lets you rebuild it).

```
Visit(node) → Recurse(left) → Recurse(right)
```

### InOrder — `InOrder()` → Left → Root → Right

**Use for:** Getting sorted output from a BST. Left subtree (smaller) → current → right subtree (larger).

```
Recurse(left) → Visit(node) → Recurse(right)
```

**Key insight:** InOrder traversal of a BST always produces sorted output.

### PostOrder — `PostOrder()` → Left → Right → Root

**Use for:** Deleting a tree (children first, then parent), evaluating expression trees.

```
Recurse(left) → Recurse(right) → Visit(node)
```

### BFS — `BFS()` → Level by level

**Approach:** Use a Queue. Enqueue root, then repeatedly dequeue a node, visit it, and enqueue its children.

**Use for:** Level-order problems, finding breadth, shortest path in unweighted trees.

---

## Tree Properties

### Height — `Height()` → O(n)

**What it means:** Longest path (in edges) from root to any leaf. Empty tree returns -1, single node returns 0.

**Approach:** Recursively get left and right heights, return `max(left, right) + 1`.

---

### NumOfNodes — `NumOfNodes()` → O(n)

**Approach:** `left_count + right_count + 1` (count self + all descendants).

---

### NumLeaves — `NumLeaves()` → O(n)

**What's a leaf:** A node where `left == null && right == null`.

**Approach:** If leaf, return 1. Otherwise sum leaves from left and right subtrees.

---

### Breadth — `Breadth()` → O(n)

**What it means:** Maximum number of nodes at any single level (widest point of the tree).

**Approach:** BFS with a queue. Track max queue size at any point during traversal.

---

## Complexity Summary

| Operation | Average | Worst (skewed) |
|-----------|---------|----------------|
| Insert | O(log n) | O(n) |
| Search | O(log n) | O(n) |
| Delete | O(log n) | O(n) |
| Traversal | O(n) | O(n) |
| Height | O(n) | O(n) |
| Space | O(n) | O(n) |
