// Question - Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y, 
// return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.
// Two nodes of a binary tree are cousins if they have the same depth with different parents.

// #tree #recursive #dfs #bfs

// Consider getting depth compare and check if does not have same parent
public bool IsCousins2(TreeNode root, int x, int y)
{
    var (xDepth, yDepth) = GetCousinDepth(root, x, y, 0);

    if (xDepth == yDepth && xDepth != 0) return true;
    return false;
}

// Be careful to cross out same parent issue. To be cousion they should not have same parent
public (int, int) GetCousinDepth(TreeNode root, int x, int y, int depth)
{
    if (root == null || hasSameParent(root, x, y)) return (0, 0);

    if (root.val == x) return (depth, 0);
    if (root.val == y) return (0, depth);

    var (x1, y1) = GetCousinDepth(root.left, x, y, depth + 1);
    var (x2, y2) = GetCousinDepth(root.right, x, y, depth + 1);

    return (Math.Max(x1, x2), Math.Max(y1, y2));
}

public bool hasSameParent(TreeNode root, int x, int y)
{
    if (root.left == null || root.right == null) return false;

    if (root.left.val == x && root.right.val == y) return true;
    if (root.left.val == y && root.right.val == x) return true;

    return false;
}


// Simple BFS solution, maintain depths and check if any node has both x and y as children then its false
public bool IsCousins(TreeNode root, int x, int y)
{
    if (root == null) return false;

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Count != 0)
    {
        int levelSize = queue.Count;
        bool foundX = false, foundY = false;

        for (int i = 0; i < levelSize; i++)
        {
            var node = queue.Dequeue();

            if (hasSameParent(node, x, y)) return false;

            if (node.val == x) foundX = true;
            if (node.val == y) foundY = true;

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }

        if (foundX && foundY) return true;
        if (foundX || foundY) return false;
    }

    return false;
}