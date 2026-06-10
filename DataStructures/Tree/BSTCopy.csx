// Question - Create copy of a binary tree or tree

// #bst #tree

// Simply with recursion create same nodes and add as child in same way
Node DuplicateTree(Node root)
{
    if (root == null) return null;

    return new Node()
    {
        Data = node.Data,
        Left = DuplicateTree(node.Left),
        Right = DuplicateTree(node.Right)
    };
}