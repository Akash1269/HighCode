// Question - If target sum is present from root to any leaf, return true if found

// #tree #dfs

// Simple intuitive solution
public bool HasPathSum(TreeNode root, int targetSum)
{
    return PathSumCount(root, targetSum);
}

public bool PathSumCount(TreeNode root, int targetSum)
{
    if (root == null) return false;

    targetSum -= root.val;

    if (root.left == null && root.right == null && 0 == targetSum)
    {
        return true;
    }

    return PathSumCount(root.left, targetSum) ||
            PathSumCount(root.right, targetSum);
}