// Question - 
// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

// #tree #dfs #lca

// Simple intuitive solution, check if one exist, when both exists its the first lowest common parent
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
    TreeNode LCA = null;
    DFS(root, p, q, ref LCA);

    return LCA;
}

public (bool foundP, bool foundQ) DFS(TreeNode root, TreeNode p, TreeNode q, ref TreeNode LCA)
{
    if (root == null || LCA != null) return (false, false);

    // Console.WriteLine ("root - {0}", root.val);

    var (foundP1, foundQ1) = DFS(root.left, p, q, ref LCA);
    var (foundP2, foundQ2) = DFS(root.right, p, q, ref LCA);

    bool foundP = foundP1 || foundP2 || root == p;
    bool foundQ = foundQ1 || foundQ2 || root == q;

    if (foundP && foundQ)
    {
        LCA = root;
        return (false, false);
    }

    return (foundP, foundQ);
}

// Little tricky, relies on fact that it must exists, and even if one exist it returns value and check
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
    return DFS(root, p, q);
}

public TreeNode DFS(TreeNode root, TreeNode p, TreeNode q)
{
    if (root == null) return null;

    if (root == p || root == q) return root;

    // Console.WriteLine("val - " + root.val);

    var node1 = DFS(root.left, p, q);
    var node2 = DFS(root.right, p, q);

    if (node1 != null && node2 != null)
    {
        // Console.WriteLine("one - {0}, two - {1}", node1.val, node2.val);
        return root;
    }

    return node1 != null ? node1 : node2;
}