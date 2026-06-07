// Question - Given a binary tree, find its minimum depth.
// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

//  #recursion #tree

// Not so direct, min is complicated since you have to ignore path which are not till leaf
// Always consider only path from root to leaf for min, ignore others
public int MinDepth(TreeNode root)
{
    if (root == null) return 0;

    if (root.left == null && root.right == null) return 1;

    int left = int.MaxValue, right = int.MaxValue;

    if (root.left != null)
    {
        left = MinDepth(root.left);
    }
    if (root.right != null)
    {
        right = MinDepth(root.right);
    }

    return Math.Min(left, right) + 1;
}

// Lil opposite logic, same performance, if right null then only need to go left, similarly if left null then only need to go right
public int MinDepth(TreeNode root)
{
    if (root == null) return 0;

    // This line can be removed since if right is null it will go to line 36, and return 0 since even left is null
    // but keeping it just to make it sense or easy to understand
    if (root.left == null && root.right == null) return 1;

    if (root.right == null) return MinDepth(root.left) + 1;
    if (root.left == null) return MinDepth(root.right) + 1;

    return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
}

// Using queue and BFS, we can early return as soon as nearest level of leaf is found when going by each level
// This has early return but same efficiency
public int MinDepth(TreeNode root)
{
    if (root == null) return 0;
    var queue = new Queue<TreeNode>();
    int depth = 0;
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        int levelSize = queue.Count;
        depth++;

        for (int i = 0; i < levelSize; i++)
        {
            var node = queue.Dequeue();

            if (node.left == null && node.right == null) return depth;

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);

            if (node.left == null && node.right == null) return depth;

        }
    }

    return 0;
}


// Another solution can be to save min globally and stop going right or left if we have already reached certain depth
// then there cant be any depth less than already seen min, same complexity but saves time