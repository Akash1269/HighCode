// Question - Delete a node in BST with key, maintain BST order

// #bst

// Solution 1 : Recursive using common delete node internal function
public TreeNode DeleteNode(TreeNode root, int key)
{
    if (root == null) return null;

    if (key < root.val)
        root.left = DeleteNode(root.left, key);
    else if (key > root.val)
        root.right = DeleteNode(root.right, key);
    else
    {
        // If node is found key == root.val
        TreeNode node = DeleteNodeInternal(root);
        return node;
    }

    return root;
}

// Solution 2 : Iterative using common delete node internal function
public TreeNode DeleteNode2(TreeNode root, int key)
{
    TreeNode parent = null;
    TreeNode current = root;

    // Find key and save its parent and direction from parent
    while (current != null && key != current.val)
    {
        parent = current;
        if (key < current.val)
        {
            current = current.left;
        }
        else
        {
            current = current.right;
        }
    }

    // Current null which means reached end of tree and node is not present, return root with no changes
    if (current == null)
        return root;

    // All below cases are for key found, so go ahead and delete node
    var node = DeleteNodeInternal(current);

    // Found key at root, above function returns the node after deleting, maybe null as well.
    if (current == root)
    {
        return node;
    }

    // If not root, we need to change parent pointer to pont to this new node, and return old root only
    if (parent.left == current)
        parent.left = node;
    else
        parent.right = node;

    return root;
}

public TreeNode DeleteNodeInternal(TreeNode node)
{
    // Usually will not be the case, as this function wont be called if node is not found
    if (node == null) return null;

    // Found node has only one children left or right then we can assign other child directly to parent in place of deleting node
    // this skips or deletes node automatically
    if (node.left == null) return node.right;
    if (node.right == null) return node.left;

    // Found node has both children

    // Approach 1 - Find left most node on right subtree as thats next to this node
    // And swap the values and delete left most node, as that will have max one child on right.
    var current = node.right;
    var parent = node;

    // follow parent to delete the node and reassign right tree to parent of deleted node
    while (current.left != null)
    {
        parent = current;
        current = current.left;
    }

    // Assign value of this left most node to found node, as the found node value is not needed anymore
    node.val = current.val;

    // if current node had no left children, then attach right children to parent node
    // As that mean we deleted the right node and need to make that null
    if (parent == node)
    {
        parent.right = current.right;
    }
    else
    {
        parent.left = current.right;
    }

    return node;
}