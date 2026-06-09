// Question - Given the root of a binary tree, return its maximum depth.
// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

// #tree #recursive #dfs #bfs #stack #queue

// Solution 1 : Most intuitive and simple, go till leaf and return adding 1 after each call to know depth
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

// Solution 2 : Without using depth
public int MaxDepthRecursive(TreeNode root)
{
    if (root == null) return 0;

    int left = MaxDepthRecursive(root.left);
    int right = MaxDepthRecursive(root.right);

    return Math.Max(left, right) + 1;
}

// Solution 3 : Using queue we can do BFS, and track depth by doing outer loop count on how many level we went deep
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

// Solution 4 : Using stock we can do DFS, but save depth var along with element to track what depth we went.
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