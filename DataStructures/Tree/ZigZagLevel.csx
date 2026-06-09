// Question - Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
// (i.e., from left to right, then right to left for the next level and alternate between).

// #zigzag #bfs #queue #tree

// Simple BFS with queue and reverse the order for alternate levels to get zigzag
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var lists = new List<IList<int>>();
        if (root == null) return lists;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int depth = 0;

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

                // if (depth % 2  == 0) {
                //     levelList.Add(node.val);
                // } else {
                //     levelList.Insert(0, node.val);
                // }
            }

            if (depth % 2  == 1) 
                levelList.Reverse();
            lists.Add(levelList);
            depth++;
        }

        return lists;
    }
}