// Question
// If list of all leaf nodes of both trees are same return true else return false

// #tree #recusive

// Most efficient intuitive solution
public bool LeafSimilar(TreeNode root1, TreeNode root2)
{
    var list1 = new List<int>();
    var list2 = new List<int>();

    addLeavesToList(root1, list1);
    addLeavesToList(root2, list2);

    if (list1.Count != list2.Count)
    {
        return false;
    }

    for (int i = 0; i < list1.Count; i++)
    {
        if (list1[i] != list2[i]) return false;
    }
    return true;
}

public void addLeavesToList(TreeNode root, List<int> list)
{
    if (root == null) return;

    addLeavesToList(root.left, list);
    addLeavesToList(root.right, list);

    if (root.left == null && root.right == null)
    {
        list.Add(root.val);
        return;
    }
}