# Binary Search Tree — Learning Guide

## Basic Concepts

### What is a BST?

A Binary Search Tree is a binary tree where every node satisfies the **BST invariant**:

> For any node: ALL left descendants < node < ALL right descendants

This gives O(log n) search/insert/delete on average by eliminating half the tree at each step.

### Node Structure
```csharp
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
}
```

### Key Properties
| Property | Implication |
|----------|-------------|
| InOrder traversal = sorted order | Use this for validation, kth element, range queries |
| Left subtree max < root < right subtree min | Use this for insert/delete/search |
| Height = O(log n) balanced, O(n) worst | Skewed trees degrade to linked lists |

### Core Operations (in `Implementation/BinarySearchTree.csx`)
| Operation | Time (avg) | Approach |
|-----------|-----------|----------|
| Search | O(log n) | Compare → go left or right |
| Insert | O(log n) | Search for null spot, place node |
| Delete | O(log n) | Find node, handle 3 cases (leaf / one child / two children) |
| InOrder | O(n) | Left → Root → Right gives sorted output |

---

## Patterns & Strategies

1. **BST Binary Search (Directed Traversal)**
   - "Compare value with current node → go left or right, eliminating half the tree each step"
   - Use when: searching, inserting, or finding a specific value/position in a BST
   - Think: "Can I use the BST ordering to skip half the tree?"

2. **InOrder Traversal = Sorted Array**
   - "Treat InOrder traversal as iterating through a sorted array"
   - Use when: you need kth smallest/largest, validation, converting BST to sorted structure, or finding successor/predecessor
   - Think: "If I had a sorted array of these values, how would I solve it?"

3. **BST Validation (Range Propagation)**
   - "Each node must be within a valid range (min, max) inherited from ancestors"
   - Use when: validating if a tree is a valid BST
   - Think: "What range of values is this node allowed to have?"

4. **BST Construction / Modification**
   - "Use BST property to find the right position, then restructure pointers"
   - Use when: inserting, deleting, trimming, or splitting a BST
   - Think: "Where does this value belong? What pointers need to change?"

5. **Iterative InOrder with Stack (Morris Traversal)**
   - "Simulate inorder traversal without recursion using a stack or thread pointers"
   - Use when: O(1) space traversal, or processing BST nodes in sorted order iteratively
   - Think: "Can I visit nodes in sorted order without recursion?"

---

### Pattern 1: BST Binary Search (Directed Traversal)

**Concept:** Exploit the BST invariant to discard half the tree at each comparison. If target < current, it must be in the left subtree. If target > current, it must be in the right subtree.

**Template:**
```csharp
TreeNode Search(TreeNode root, int target) {
    while (root != null) {
        if (target == root.val) return root;
        root = target < root.val ? root.left : root.right;
    }
    return null;
}
```

**Key Insight:** Every comparison eliminates an entire subtree — this is binary search on a tree structure.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `BSTSearch.csx` | Find node and return subtree | Recursive + iterative approaches |
| `Implementation/BinarySearchTree.csx` | Insert, FindNode, Delete | All use directed traversal to find position |

---

### Pattern 2: InOrder Traversal = Sorted Array

**Concept:** InOrder traversal of a BST visits nodes in ascending sorted order. Many BST problems reduce to "sorted array" problems when you think in terms of inorder.

**Template:**
```csharp
// Kth smallest: do inorder, count down k
TreeNode KthSmallest(TreeNode root, ref int k) {
    if (root == null) return null;
    var left = KthSmallest(root.left, ref k);
    if (left != null) return left;
    if (--k == 0) return root;
    return KthSmallest(root.right, ref k);
}
```

**Key Insight:** Instead of collecting all values and sorting, just do InOrder — it's already sorted.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `Implementation/BinarySearchTree.csx` | InOrder traversal | Prints values in sorted order |

---

### Pattern 3: BST Validation (Range Propagation)

**Concept:** Pass a valid (min, max) range down the tree. Each left child narrows max to parent's value. Each right child narrows min to parent's value.

**Template:**
```csharp
bool IsValidBST(TreeNode root, long min = long.MinValue, long max = long.MaxValue) {
    if (root == null) return true;
    if (root.val <= min || root.val >= max) return false;
    return IsValidBST(root.left, min, root.val) &&
           IsValidBST(root.right, root.val, max);
}
```

**Key Insight:** It's not enough to check left < root < right locally — you must check against ALL ancestors. The range approach handles this naturally.

**Applied in:**
- Not yet practiced — see Additional Patterns below.

---

### Pattern 4: BST Construction / Modification

**Concept:** Use the BST property to find where a value belongs, then manipulate pointers. For deletion, find the in-order predecessor or successor to replace the removed node.

**Template (Delete):**
```csharp
TreeNode Delete(TreeNode root, int key) {
    if (root == null) return null;
    if (key < root.val) root.left = Delete(root.left, key);
    else if (key > root.val) root.right = Delete(root.right, key);
    else {
        if (root.left == null) return root.right;
        if (root.right == null) return root.left;
        // Find inorder successor (leftmost of right subtree)
        TreeNode successor = root.right;
        while (successor.left != null) successor = successor.left;
        root.val = successor.val;
        root.right = Delete(root.right, successor.val);
    }
    return root;
}
```

**Key Insight:** Recursive delete is cleaner than iterative — the return value naturally reconnects parent pointers.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `Implementation/BinarySearchTree.csx` | Delete operation | Iterative approach with 3 cases |

---

## Problem Difficulty Progression

| Level | Problem | Key Pattern |
|-------|---------|-------------|
| Easy | BSTSearch | BST Binary Search |
| Easy | BinarySearchTree (Insert/Find) | BST Directed Traversal |
| Medium | BinarySearchTree (Delete) | BST Construction/Modification |

---

## Quick Reference: When to Use What

| Situation | Pattern |
|-----------|---------|
| Find/search for a value | BST Binary Search |
| Need sorted order or kth element | InOrder = Sorted Array |
| Check if tree is valid BST | Range Propagation |
| Insert / delete / restructure | BST Construction |
| Need O(1) space sorted traversal | Iterative InOrder / Morris |

---

## Additional Interview Patterns (Not Yet Practiced)

6. **Validate BST**
   - "Pass (min, max) range down; every node must fall within its inherited range"
   - Use when: Asked to verify BST property
   - Think: "Is checking just parent enough? No — need full ancestor range"
   - Problems: Validate Binary Search Tree (LC 98)

7. **Kth Smallest/Largest in BST**
   - "InOrder traversal, count nodes until you reach kth"
   - Use when: Finding rank-based element in BST
   - Think: "InOrder gives me sorted order — just count"
   - Problems: Kth Smallest Element in BST (LC 230)

8. **Convert BST to Greater/Sorted List**
   - "Reverse inorder (Right → Root → Left) accumulates running sum from largest to smallest"
   - Use when: Converting BST values based on relative position
   - Think: "Can I use reverse inorder to process from largest first?"
   - Problems: Convert BST to Greater Tree (LC 538), BST to Sorted Doubly Linked List

9. **Trim BST to Range**
   - "If root < low, only right subtree can have valid nodes. If root > high, only left"
   - Use when: Removing nodes outside a given range
   - Think: "Can I recursively discard entire subtrees that are out of range?"
   - Problems: Trim a BST (LC 669)

10. **Lowest Common Ancestor in BST**
    - "If both values < root, LCA is in left. If both > root, LCA is in right. Otherwise root IS the LCA"
    - Use when: Finding LCA specifically in a BST (simpler than general binary tree LCA)
    - Think: "The split point where p and q go to different sides — that's the LCA"
    - Problems: LCA of a BST (LC 235)

11. **Construct BST from Preorder**
    - "First element is root. Use upper bound to determine which elements go left vs right"
    - Use when: Building BST from traversal output
    - Think: "Preorder gives root first — where does left subtree end?"
    - Problems: Construct BST from Preorder Traversal (LC 1008)

12. **Inorder Successor / Predecessor**
    - "If node has right child, successor = leftmost of right subtree. Otherwise walk up from root tracking last left turn"
    - Use when: Finding next/prev element in BST sorted order
    - Think: "Where would the next value in sorted order be located?"
    - Problems: Inorder Successor in BST (LC 285), Delete Node in BST (LC 450)
