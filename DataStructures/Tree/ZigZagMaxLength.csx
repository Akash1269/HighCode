// Question - 
// Find the longest path in a binary tree where each move alternates between left and right child (L→R→L... or R→L→R...).
// You may start from any node, and the answer is the maximum number of edges in such a ZigZag path.

// #dfs #tree

// Short and crisp, but hard to come up with solution
// Call from root to at any point know what is zig zag length case from left and right
// On next step move left -> right + 1 to continue zig zag and right -> left + 1
int maxPath;
public int LongestZigZag3(TreeNode root)
{
    GoZigZag3(root, 0, 0);
    return maxPath;
}

public void GoZigZag3(TreeNode root, int left, int right)
{
    if (root == null) return;

    maxPath = Math.Max(maxPath, Math.Max(left, right));

    GoZigZag3(root.right, 0, left + 1);
    GoZigZag3(root.left, right + 1, 0);
}

// Not so intuitive solution, to keep tracking current continuous zigzag length and max length
// Go left if prev right and go right if prev left. still go to other direction for new paths by resetting length
public int LongestZigZag(TreeNode root)
{
    if (root == null) return 0;
    int maxLength = 0;

    GoZigZag(root.left, true, 1, ref maxLength);
    GoZigZag(root.right, false, 1, ref maxLength);

    return maxLength;
}

public void GoZigZag(TreeNode root, bool goRight, int length, ref int maxLength)
{
    if (root == null) return;

    maxLength = Math.Max(length, maxLength);

    if (goRight)
    {
        GoZigZag(root.right, false, 1 + length, ref maxLength);
        GoZigZag(root.left, true, 1, ref maxLength);
    }
    else
    {
        GoZigZag(root.right, false, 1, ref maxLength);
        GoZigZag(root.left, true, 1 + length, ref maxLength);
    }
}

// Brute force solution
// For each node traverse subtree to find longest zigzag path
public int LongestZigZag3(TreeNode root)
{
    if (root == null) return 0;

    int currentLeft = GoZigZag3(root, false);
    int currentRight = GoZigZag3(root, true);

    int left = LongestZigZag3(root.left);
    int right = LongestZigZag3(root.right);

    return Math.Max(Math.Max(left, right), Math.Max(currentLeft, currentRight));
}

public int GoZigZag3(TreeNode root, bool goRight)
{
    TreeNode current = root;
    int length = 0;

    while (current != null)
    {
        Console.WriteLine(current.val);
        goRight = !goRight;

        if (goRight)
            current = current.right;
        else
            current = current.left;

        length++;
    }

    Console.WriteLine("length- " + length);

    return length - 1;
}