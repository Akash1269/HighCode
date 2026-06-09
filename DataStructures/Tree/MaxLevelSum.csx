// Question - Given the root of a binary tree, Return the smallest level x such that the sum of all the values of nodes at level x is maximal.

// #bfs #tree #queue

// Use simple level order traversal to track sum at each level and store max level
public int MaxLevelSum(TreeNode root)
{
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    // level has to be min level if same max is present at multiple level
    int maxSum = int.MinValue, maxLevel = 0;
    int depth = 1;

    while (queue.Count != 0)
    {
        int levelSize = queue.Count;
        int levelSum = 0;

        for (int i = 0; i < levelSize; i++)
        {
            var node = queue.Dequeue();
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);

            levelSum += node.val;
        }

        if (levelSum > maxSum)
        {
            maxSum = levelSum;
            maxLevel = depth;
        }

        depth++;
    }

    return maxLevel;
}