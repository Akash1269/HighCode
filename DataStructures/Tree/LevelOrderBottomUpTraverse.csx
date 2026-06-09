// Question - Add each level elements new list and make lists of list and return, add bottom level first and move towards top.

// #bfs #tree #queue

// Traverse by level as certain point only one level of nodes, and reset level size to run on that loop
// More efficient saves space and operations. Insert start or 0 to reverse order of levels
public IList<IList<int>> LevelOrderBottom(TreeNode root)
{
    var lists = new List<IList<int>>();
    if (root == null) return lists;

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Count != 0)
    {

        int levelSize = queue.Count;
        var levelList = new List<int>();

        for (int i = 0; i < levelSize; i++)
        {
            var node = queue.Dequeue();
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);

            levelList.Add(node.val);
        }

        lists.Insert(0, levelList);
    }

    return lists;
}