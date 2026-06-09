// Question - Given the root of a binary tree and an integer targetSum, 
// return the number of paths where the sum of the values along the path equals targetSum.
// The path does not need to start or end at the root or a leaf

// #tree #dfs

// Solution 1 : More intuitive and simple using list to find out if any sum of list to root on all elements match target sum
// Take more time complexity to everytime check sum from element to root
public int PathSum(TreeNode root, int targetSum)
{
    var list = new List<int>();
    return PathSumCount(root, targetSum, list);
}

public int PathSumCount(TreeNode root, int targetSum, IList<int> list)
{
    if (root == null) return 0;

    list.Add(root.val);
    long sum = 0;
    int count = 0;
    for (int i = list.Count - 1; i >= 0; i--)
    {
        sum += list[i];
        if (sum == targetSum) count++;
    }

    count += PathSumCount(root.left, targetSum, list);
    count += PathSumCount(root.right, targetSum, list);

    list.RemoveAt(list.Count - 1);
    return count;
}

// Solution 2 : Optimized using stored map of prefix sum to see if we can remove any prefix to match
public int PathSum(TreeNode root, int targetSum)
{
    // 0 is added to check for matching target sum from root to this node as simplicity purpose
    var map = new Dictionary<long, int>() { { 0, 1 } };

    return PathSumCount(root, 0, targetSum, map);
}

public int PathSumCount(TreeNode root, long currentSum, int targetSum, Dictionary<long, int> map)
{
    if (root == null) return 0;

    currentSum += root.val;

    // Get total count of possible sum found
    int count = 0;
    count += map.GetValueOrDefault(currentSum - targetSum);

    // Add current element to map after checking if any prefix sum exist for the current sum
    map[currentSum] = map.GetValueOrDefault(currentSum) + 1;

    // Get Count from children
    count += PathSumCount(root.left, currentSum, targetSum, map);
    count += PathSumCount(root.right, currentSum, targetSum, map);

    // Backtrack - Remove from map or reduce count
    if (--map[currentSum] == 0) map.Remove(currentSum);

    return count;
}