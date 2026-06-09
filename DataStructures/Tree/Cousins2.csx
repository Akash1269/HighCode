// Question - Given the root of a binary tree, replace the value of each node in the tree with the sum of all its cousins' values.

// #tree #recursive #bfs

// Maintain prev sum and save sibling sum to substract on next run of dequeue
public TreeNode ReplaceValueInTree(TreeNode root) {
        if (root == null) return root;

        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, root.val));
        int prevLevelSum = root.val;

        while (queue.Count != 0)
        {
            int levelSize = queue.Count;
            int currentLevelSum = 0;

            for (int i = 0; i < levelSize; i++)
            {
                var (node, siblingSum) = queue.Dequeue();
                node.val = prevLevelSum - siblingSum;
                
                int currentSiblingSum = (node.left != null ? node.left.val : 0) + (node.right != null ? node.right.val : 0);

                if (node.left != null) {
                    queue.Enqueue((node.left, currentSiblingSum));
                }

                if (node.right != null) {
                    queue.Enqueue((node.right, currentSiblingSum));
                }

                currentLevelSum += currentSiblingSum;
            }

            prevLevelSum = currentLevelSum;

        }

        return root;
    }