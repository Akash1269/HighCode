// Question - Add each level elements new list and make lists of list and return

// #bfs #tree #queue

// Simple by storing levels with node in queue
public IList<IList<int>> LevelOrder(TreeNode root)
{
    var lists = new List<IList<int>>();
    if (root == null) return lists;

    var queue = new Queue<(TreeNode, int)>();
    queue.Enqueue((root, 0));

    while (queue.Count != 0)
    {
        var (node, level) = queue.Dequeue();
        if (node.left != null) queue.Enqueue((node.left, level + 1));
        if (node.right != null) queue.Enqueue((node.right, level + 1));

        if (lists.Count == level)
        {
            lists.Add(new List<int>());
        }

        lists[level].Add(node.val);
    }

    return lists;
}

// Traverse by level as certain point only one level of nodes, and reset level size to run on that loop
// More efficient saves space and operations.
public IList<IList<int>> LevelOrder2(TreeNode root)
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

        lists.Add(levelList);
    }

    return lists;
}