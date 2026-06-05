// question - Get max depth of tree from root to leaf

// #tree #recursive #dfs #bfs #stack #queue

// Simple recursive solution to increase depth on each return
public int MaxDepthLoop(TreeNode root)
{
    return GetMaxDepth(root, 0);
}

public int GetMaxDepth(TreeNode root, int depth)
{
    if (root == null) return depth;

    int left = GetMaxDepth(root.left, depth + 1);
    int right = GetMaxDepth(root.right, depth + 1);

    return Math.Max(left, right);
}

// Without using depth
public int MaxDepthRecursive(TreeNode root)
{
    if (root == null) return 0;

    int left = MaxDepthRecursive(root.left);
    int right = MaxDepthRecursive(root.right);

    return Math.Max(left, right) + 1;
}

// Non recursive solution using loops Using BFS and Queue
public int MaxDepthBFS(TreeNode root)
{
    if (root == null) return 0;

    int depth = 0;
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Count > 0)
    {
        int levelLength = queue.Count;

        for (int i = 0; i < levelLength; i++)
        {
            var current = queue.Dequeue();

            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);
        }

        depth++;
    }

    return depth;
}

// Non recursive using loops, DFS, Stack
public int MaxDepthDFS(TreeNode root)
{
    int max = 0;

    var stack = new Stack<(TreeNode, int)>();
    stack.Push((root, 1));


    while (stack.Count > 0)
    {
        var (current, count) = stack.Pop();

        if (current.left != null) stack.Push((current.left, count + 1));
        if (current.right != null) stack.Push((current.right, count + 1));

        max = Math.Max(count, max);
    }

    return max;
}

