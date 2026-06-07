// Question -
// Find avg of each levels, and return in the list by each level

// #tree #bfs #queue

// Simply get avg at each level by sum and divid by level count
public IList<double> AverageOfLevels(TreeNode root)
{
    var list = new List<double>();
    if (root == null) return list;

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    while (queue.Count != 0)
    {
        int levelSize = queue.Count;
        double avg = 0;

        for (int i = 0; i < levelSize; i++)
        {
            var node = queue.Dequeue();
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);

            avg += node.val;
        }

        list.Add(avg / levelSize);
    }

    return list;
}