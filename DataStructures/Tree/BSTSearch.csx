// You are given the root of a binary search tree (BST) and an integer val.
// Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.

// #bst #recursive #dfs

// Simiple and intuitive solution, only go to side which is possible search area O(log(n))
public TreeNode SearchBST2(TreeNode root, int val)
{
    if (root == null) return null;

    if (root.val == val) return root;

    if (val < root.val)
        return SearchBST(root.left, val);
    else
        return SearchBST(root.right, val);
}

// Using loop more simpler 
public TreeNode SearchBST(TreeNode root, int val)
{
    while (root != null)
    {
        if (root.val == val) return root;

        if (val < root.val)
            root = root.left;
        else
            root = root.right;
    }
    return null;
}