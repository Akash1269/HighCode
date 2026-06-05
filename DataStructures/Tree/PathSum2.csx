// Question - If target sum is present from root to any leaf, return list of all such paths

// #tree #dfs

// Simple intuitive solution, store lists
// Use backtracking to use same list across to save space, remove from list once branch is done
public IList<IList<int>> PathSum(TreeNode root, int targetSum)
{
    var paths = new List<IList<int>>();
    var list = new List<int>();

    PathSumCount(root, targetSum, paths, list);

    return paths;
}

public void PathSumCount(TreeNode root, int targetSum, IList<IList<int>> paths, IList<int> list)
{
    if (root == null) return;

    list.Add(root.val);
    targetSum -= root.val;

    if (root.left == null && root.right == null && targetSum == 0)
    {
        paths.Add(new List<int>(list));
    }

    PathSumCount(root.left, targetSum, paths, list);
    PathSumCount(root.right, targetSum, paths, list);

    list.RemoveAt(list.Count - 1);
}