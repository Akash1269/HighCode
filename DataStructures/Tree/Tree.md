# Tree - Learning Guide

## Basic Concepts

### What is a Tree?
A tree is a hierarchical, non-linear data structure consisting of **nodes** connected by **edges**. Each tree has a **root node** and every node can have zero or more **child nodes**.

### Key Terminology
| Term | Definition |
|------|-----------|
| **Root** | The topmost node with no parent |
| **Node** | An element containing data and references to children |
| **Edge** | Connection between a parent and child node |
| **Leaf** | A node with no children (`left == null && right == null`) |
| **Height** | Longest path (edges) from root to a leaf |
| **Depth** | Number of edges from root to a given node |
| **Subtree** | A node and all its descendants |

### Binary Tree
Each node has at most **two children** — `left` and `right`.

### Binary Search Tree (BST)
A binary tree where for every node:
- All values in the **left subtree** are **less** than the node's value
- All values in the **right subtree** are **greater** than the node's value

### Node Structure (used across problems)
```csharp
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
}
```

---

## Tree Traversals (Fundamental Operations)

All traversal types are implemented in `BinarySearchTree.csx`:

| Traversal | Order | Use Case |
|-----------|-------|----------|
| **DFS (Pre-Order)** | Root → Left → Right | Copy tree, serialize |
| **DFS (In-Order)** | Left → Root → Right | BST sorted output |
| **DFS (Post-Order)** | Left → Right → Root | Delete tree, evaluate expression |
| **BFS (Level-Order)** | Level by level using Queue | Find depth, breadth |

---

## Patterns & Strategies

1. **Bottom-Up DFS (Return Value Aggregation)**
   - "Ask both children, combine their answers, return result to parent"
   - Use when: the answer at a node **depends on answers from its subtrees** (e.g., height, count, exists?)
   - Think: "What can my left and right children tell me?"

2. **Top-Down DFS (State Passing)**
   - "Carry information FROM root TO leaves as a parameter"
   - Use when: you need **context about ancestors** to make decisions at the current node (e.g., max so far, remaining sum, depth)
   - Think: "What do I need to know about the path above me?"

3. **Backtracking on Trees**
   - "Add current node to path → explore children → remove current node when done"
   - Use when: you need to **track/collect full paths** or explore all possibilities without duplicating data structures
   - Think: "I need to try all paths and undo my choices when I come back up"

4. **Prefix Sum on Trees**
   - "Store cumulative sums in a map; check if (currentSum - target) exists to find valid subpaths"
   - Use when: you need to find **subpaths (any start, any end) that sum to a target** — essentially the subarray sum problem on a tree
   - Think: "Can I remove a prefix of this path to get my target?"

5. **BFS Level-Order (Queue)**
   - "Process all nodes at depth D before any node at depth D+1"
   - Use when: you need **level-by-level** information, shortest depth to something, or breadth of tree
   - Think: "Do I care about levels/layers rather than full root-to-leaf paths?"

6. **Iterative DFS (Stack)**
   - "Same as recursive DFS but using an explicit stack with (node, state) tuples"
   - Use when: recursion may overflow the call stack, or you need **fine-grained control** over traversal order
   - Think: "Can I simulate what recursion does with my own stack?"

7. **Dual Recursion (Direction/State Branching)**
   - "At each node, recurse in multiple directions with different state — reset when a pattern breaks"
   - Use when: the problem involves **alternating patterns** (zigzag, flip direction) or tracking multiple independent paths from every node
   - Think: "I need to track two competing states at every node"

---

### Pattern 1: Recursive DFS with Return Value Aggregation

**Concept:** Recursively traverse left and right subtrees, combine results from both sides, and return an aggregated value up the call stack.

**Template:**
```csharp
int Solve(TreeNode root) {
    if (root == null) return baseCase;
    int left = Solve(root.left);
    int right = Solve(root.right);
    return combine(left, right) + currentNodeContribution;
}
```

**Key Insight:** The answer at each node depends on answers from its children. Each recursive call returns useful information to the parent.

**Applied in:**
| File | Problem | What's Aggregated |
|------|---------|-------------------|
| `MaxDepth.csx` | Max depth of tree | `Math.Max(left, right) + 1` |
| `GoodNodes.csx` | Count good nodes | `left_count + right_count + IsGoodNode` |
| `LCAOfTwoNodes.csx` | Lowest common ancestor | `(foundP, foundQ)` tuples bubbled up |
| `LeafSimilarTrees.csx` | Collect leaf values | Leaves appended to list via DFS |
| `BinarySearchTree.csx` | NumOfNodes, Height, NumLeaves | Count/height aggregated from subtrees |

---

### Pattern 2: DFS with State Passing (Top-Down)

**Concept:** Pass accumulated state **downward** from parent to children as a parameter. The state tracks context from root to the current node (e.g., running sum, max seen so far, current path).

**Template:**
```csharp
void Solve(TreeNode root, int state) {
    if (root == null) return;
    // update state with current node
    state = updateState(state, root.val);
    // check condition at leaf or any node
    if (condition) { /* record answer */ }
    Solve(root.left, state);
    Solve(root.right, state);
}
```

**Key Insight:** You carry context from the root down to leaves. Often used when you need to evaluate conditions that depend on the **path from root to current node**.

**Applied in:**
| File | Problem | State Passed Down |
|------|---------|-------------------|
| `GoodNodes.csx` | Count good nodes | `max` value seen on path from root |
| `PathSum1.csx` | Has path sum (root to leaf) | `targetSum` decremented at each node |
| `PathSum2.csx` | All paths with target sum | `targetSum` + current path list |
| `MaxDepth.csx` | Max depth (loop variant) | `depth` counter incremented |
| `ZigZagMaxLength.csx` | Longest ZigZag path | `left` and `right` zigzag lengths |

---

### Pattern 3: Backtracking on Trees

**Concept:** Explore a path, make a choice (add to list/map), recurse into children, then **undo the choice** when returning. This allows reusing the same data structure across all branches.

**Template:**
```csharp
void Solve(TreeNode root, List<int> path) {
    if (root == null) return;
    path.Add(root.val);           // CHOOSE
    // check / process
    Solve(root.left, path);       // EXPLORE
    Solve(root.right, path);      // EXPLORE
    path.RemoveAt(path.Count - 1); // UN-CHOOSE (backtrack)
}
```

**Key Insight:** Instead of creating new lists for every path (expensive), reuse one list and remove the last element when backtracking. This is an optimization over naive DFS path collection.

**Applied in:**
| File | Problem | What's Backtracked |
|------|---------|-------------------|
| `PathSum2.csx` | All root-to-leaf paths matching sum | `list.RemoveAt(list.Count - 1)` |
| `PathSum3.csx` (list approach) | Count paths from any node | `list.RemoveAt(list.Count - 1)` |
| `PathSum3.csx` (prefix sum approach) | Count paths using prefix map | `map[currentSum]` decremented/removed |

---

### Pattern 4: Prefix Sum on Trees

**Concept:** Maintain a running cumulative sum from root to current node. Use a HashMap to store how many times each prefix sum has occurred. To find if a subpath sums to target: check if `currentSum - targetSum` exists in the map.

**Template:**
```csharp
int Solve(TreeNode root, long currentSum, int target, Dictionary<long, int> map) {
    if (root == null) return 0;
    currentSum += root.val;
    int count = map.GetValueOrDefault(currentSum - target);
    map[currentSum] = map.GetValueOrDefault(currentSum) + 1;
    count += Solve(root.left, currentSum, target, map);
    count += Solve(root.right, currentSum, target, map);
    if (--map[currentSum] == 0) map.Remove(currentSum); // backtrack
    return count;
}
```

**Key Insight:** This converts "find subarray with target sum" (a classic array problem) to work on tree paths. The map stores prefix sums on the current root-to-node path only (cleaned up via backtracking).

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `PathSum3.csx` | Count all paths with target sum (any start/end) | `Dictionary<long, int>` with `{0, 1}` seed |

---

### Pattern 5: BFS Level-Order Processing

**Concept:** Use a queue to process nodes level by level. At each level, process all nodes currently in the queue before moving to the next level. Useful for depth-related problems.

**Template:**
```csharp
int depth = 0;
Queue<TreeNode> queue = new Queue<TreeNode>();
queue.Enqueue(root);
while (queue.Count > 0) {
    int levelSize = queue.Count;  // snapshot current level size
    for (int i = 0; i < levelSize; i++) {
        var node = queue.Dequeue();
        if (node.left != null) queue.Enqueue(node.left);
        if (node.right != null) queue.Enqueue(node.right);
    }
    depth++;
}
```

**Key Insight:** The `levelSize` snapshot is critical — it tells you exactly how many nodes belong to the current level before children get added.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `MaxDepth.csx` | Max depth using BFS | Count levels until queue is empty |
| `BinarySearchTree.csx` | BFS traversal, Breadth of tree | Level-order print, max queue size = breadth |

---

### Pattern 6: Iterative DFS with Stack

**Concept:** Replace recursion with an explicit stack. Push nodes with associated state (depth, count, etc.) onto the stack and process them iteratively.

**Key Insight:** Avoids stack overflow for deep trees and gives explicit control over traversal order.

**Applied in:**
| File | Problem | Stack Stores |
|------|---------|-------------|
| `MaxDepth.csx` | Max depth using DFS | `(TreeNode, int depth)` tuples |
| `BinarySearchTree.csx` | FindNode (iterative BST search) | Implicit via while loop |

---

### Pattern 7: Dual/Multiple Recursion Paths (Direction Tracking)

**Concept:** At each node, branch into multiple recursive directions while tracking which direction was taken. Reset counters when direction changes break the pattern.

**Template:**
```csharp
void Solve(TreeNode root, int leftCount, int rightCount) {
    if (root == null) return;
    maxPath = Math.Max(maxPath, Math.Max(leftCount, rightCount));
    Solve(root.right, 0, leftCount + 1);  // came from left, continue zigzag
    Solve(root.left, rightCount + 1, 0);  // came from right, continue zigzag
}
```

**Key Insight:** The "reset to 0" when direction breaks ensures only valid zigzag paths are counted. Both directions are explored from every node.

**Applied in:**
| File | Problem | Details |
|------|---------|---------|
| `ZigZagMaxLength.csx` | Longest ZigZag path | Three approaches: brute force, direction tracking, dual-counter |

---

## Problem Difficulty Progression

| Level | Problem | Key Pattern |
|-------|---------|-------------|
| Easy | MaxDepth | Recursive DFS aggregation |
| Easy | LeafSimilarTrees | DFS leaf collection |
| Easy | PathSum1 | DFS with state (target sum) |
| Medium | GoodNodes | DFS with state (max tracking) |
| Medium | PathSum2 | DFS + Backtracking |
| Medium | LCAOfTwoNodes | DFS with boolean return aggregation |
| Medium | ZigZagMaxLength | Dual recursion with direction tracking |
| Hard | PathSum3 | Prefix Sum + Backtracking on tree |

---

## Quick Reference: When to Use What

| Situation | Pattern |
|-----------|---------|
| Need info from subtrees to answer at current node | Return Value Aggregation |
| Need info from root/ancestors at current node | State Passing (Top-Down) |
| Need to collect/track full paths | Backtracking |
| Need subpath sums from any node to any descendant | Prefix Sum |
| Need level-by-level processing or shortest depth | BFS with Queue |
| Need to avoid recursion / control traversal explicitly | Iterative DFS with Stack |
| Need alternating direction logic | Dual Recursion with Direction Tracking |

---

## Additional Interview Patterns (Not Yet Practiced)

These are commonly asked in interviews and LeetCode. Listed here for awareness and future practice.

8. **Two-Tree Comparison (Structural Matching)**
   - "Recurse both trees in parallel, compare node by node"
   - Use when: Same tree, symmetric tree, subtree check, merge two trees
   - Think: "Am I comparing structure/values of two trees simultaneously?"
   - Problems: Same Tree, Symmetric Tree, Subtree of Another Tree

9. **BST Property Exploitation (Inorder = Sorted)**
   - "Inorder traversal of a BST gives sorted order — use this to validate, find kth, or range query"
   - Use when: Validate BST, find kth smallest/largest, convert BST to sorted list, range sum
   - Think: "Can I use the sorted property of BST inorder?"
   - Problems: Validate BST, Kth Smallest in BST, Convert BST to Greater Tree

10. **Diameter / Longest Path Between Any Two Nodes**
    - "At each node, the longest path THROUGH it = leftHeight + rightHeight. Track global max"
    - Use when: Finding the longest path in the tree (not necessarily through root)
    - Think: "The answer might pass through any node as the turning point"
    - Problems: Diameter of Binary Tree, Binary Tree Maximum Path Sum

11. **Tree Views (Left/Right/Top/Bottom Side)**
    - "BFS level-by-level: first node = left view, last node = right view. Use horizontal distance for top/bottom"
    - Use when: You need to see the tree from a particular side/angle
    - Think: "Which node is visible from outside at each level or column?"
    - Problems: Right Side View, Left Side View, Top View, Bottom View

12. **Serialize / Deserialize (Tree ↔ String)**
    - "Use pre-order + null markers to encode tree. Decode by reading tokens in same order"
    - Use when: Convert tree to string for storage/transmission and reconstruct it
    - Think: "How do I flatten this tree and rebuild it uniquely?"
    - Problems: Serialize and Deserialize Binary Tree, Serialize BST

13. **Tree Construction from Traversals**
    - "Preorder gives root first. Use inorder to split left/right subtrees. Recurse on subarrays"
    - Use when: Build tree from preorder+inorder, postorder+inorder, or preorder alone (BST)
    - Think: "Which element is the root? What's left vs right of it?"
    - Problems: Construct from Preorder+Inorder, Construct from Postorder+Inorder, Construct BST from Preorder

14. **Boundary Traversal**
    - "Left boundary (top-down) + all leaves (left-right) + right boundary (bottom-up)"
    - Use when: Print/collect the outer edge of the tree anticlockwise
    - Think: "Can I split this into three separate DFS passes?"
    - Problems: Boundary of Binary Tree

15. **DP on Trees**
    - "Each node returns optimal value considering include/exclude itself. Parent decides based on children's answers"
    - Use when: Optimization problems where choosing a node affects its neighbors (parent/children)
    - Think: "Does selecting this node prevent me from selecting its children?"
    - Problems: House Robber III, Binary Tree Cameras, Longest Path

16. **Distance / Ancestor Queries**
    - "Find LCA first, then distance = depth(a) + depth(b) - 2*depth(LCA). Or BFS from target node"
    - Use when: Finding distance between nodes, all nodes at distance K
    - Think: "Do I need LCA as an intermediate step? Can I treat the tree as a graph?"
    - Problems: All Nodes Distance K, Sum of Distances in Tree
