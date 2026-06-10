// Create mirro image of tree

// #bst #tree

// Solution : Swap left and right children recursively
void MirrorImage(Node root)
{
    if (root != null)
    {
        Node temp = root.Left;
        root.Left = root.Right;
        root.Right = temp;

        MirrorImage(node.Left);
        MirrorImage(node.Right);
    }
}