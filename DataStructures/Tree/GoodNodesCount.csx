// Question
// Get count of good nodes where value of good node is >= all nodes from this node to root (path)

// #tree #recursive #dfs

// Simple intuitive solution pass max value and check if current node is good node, keep adding count
public int GoodNodes(TreeNode root)
{
    if (root == null) return 0;

    return GoodNodeCount(root, 0);
}

// Should always compare with max until parent not including current
// check if good node first and then change max
public int GoodNodeCount(TreeNode root, int max)
{
    if (root == null) return 0;

    int IsGoodNode = max <= root.val ? 1 : 0;
    max = Math.Max(max, root.val);

    return GoodNodeCount(root.left, max) + GoodNodeCount(root.right, max) + IsGoodNode;
}