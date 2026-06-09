// Question - Given the root of a binary tree, return its maximum depth.
// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

//  #recursion #tree #stack #queue

// Most intuitive and simple, go till leaf and return adding 1 after each call to know depth, and chose max among left and right
public int MaxDepth(TreeNode root)
{
    if (root == null) return 0;

    int left = MaxDepth(root.left);
    int right = MaxDepth(root.right);

    return Math.Max(left, right) + 1;
}

// Using stock we can do DFS, but save depth var along with element to track what depth we went. 
// Same depth tracking can be done in queue also
public int MaxDepthUsingStack(TreeNode root)
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

// Using queue we can do BFS, and track depth by doing outer loop count on how many level we went deep
public int MaxDepthUsingQueue(TreeNode root)
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


