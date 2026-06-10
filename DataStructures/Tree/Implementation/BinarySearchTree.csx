// Binary Search Tree — Full Implementation
// A BST where left < node < right. Supports CRUD, traversals, and tree properties.
//
// #tree #bst #implementation
//
// Basics:
//   Insert(int data)      → Insert node maintaining BST property. Returns false if duplicate.
//   Delete(int data)      → Remove node and restructure tree. Returns false if not found.
//   FindNode(int data)    → Iterative search. Returns true if value exists.
//
// Traversals:
//   PreOrder()            → Root → Left → Right (useful for serialization/copy)
//   InOrder()             → Left → Root → Right (gives sorted order for BST)
//   PostOrder()           → Left → Right → Root (useful for deletion/evaluation)
//   BFS()                 → Level-order traversal using Queue
//
// Tree Properties:
//   Height()              → Longest path (edges) from root to leaf. Empty tree = -1.
//   NumOfNodes()          → Total node count
//   NumLeaves()           → Count of leaf nodes (no children)
//   Breadth()             → Max number of nodes at any single level

class Tree
{
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public Node Root { get; set; }

    public bool Insert(int data)
    {
        Node node = new Node() { Data = data };

        if (Root == null)
        {
            Root = node;
            return true;
        }

        bool inserted = false;
        Node temp = Root;
        while (!inserted)
        {
            if (data < temp.Data)
            {
                if (temp.Left == null)
                {
                    temp.Left = node;
                    inserted = true;
                }
                else
                {
                    temp = temp.Left;
                }
            }
            else if (data > temp.Data)
            {
                if (temp.Right == null)
                {
                    temp.Right = node;
                    inserted = true;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    private void Visit(Node node)
    {
        Console.Write(node.Data + " ");
    }

    public void PreOrder()
    {
        _PreOrder(Root);
    }

    void _PreOrder(Node node)
    {
        if (node != null)
        {
            Visit(node);
            _PreOrder(node.Left);
            _PreOrder(node.Right);
        }
    }

    public void InOrder()
    {
        _InOrder(Root);
    }


    void _InOrder(Node node)
    {
        if (node != null)
        {
            _InOrder(node.Left);
            Visit(node);
            _InOrder(node.Right);
        }
    }

    public void PostOrder()
    {
        _PostOrder(Root);
    }

    void _PostOrder(Node node)
    {
        if (node != null)
        {
            _PostOrder(node.Left);
            _PostOrder(node.Right);
            Visit(node);
        }
    }

    public int NumOfNodes()
    {
        return _NumOfNodes(Root);
    }

    int _NumOfNodes(Node node)
    {
        if (node == null) return 0;
        return _NumOfNodes(node.Left) + _NumOfNodes(node.Right) + 1;
    }

    public int Height()
    {
        return _Height(Root);
    }

    int _Height(Node node)
    {
        if (node == null) return 0;

        int leftHeight = _Height(node.Left);
        int rightHeight = _Height(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public int NumLeaves()
    {
        return _NumLeaves(Root);
    }

    int _NumLeaves(Node node)
    {
        if (node == null) return 0;

        if (node.Left == null && node.Right == null) return 1;

        return _NumLeaves(node.Left) + _NumLeaves(node.Right);
    }

    public bool FindNode(int data)
    {
        bool found = false;
        Node node = Root;
        while (node != null && !found)
        {
            if (data > node.Data)
            {
                node = node.Right;
            }
            else if (data < node.Data)
            {
                node = node.Left;
            }
            else
            {
                found = true;
            }
        }
        return found;
    }

    public void BFS()
    {
        if (Root == null) return;
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(Root);

        while (q.Count > 0)
        {
            Node node = q.Dequeue();
            Visit(node);
            if (node.Left != null)
            {
                q.Enqueue(node.Left);
            }
            if (node.Right != null)
            {
                q.Enqueue(node.Right);
            }
        }
    }

    public int Breadth()
    {
        if (Root == null) return 0;
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(Root);
        int max = 0;

        while (q.Count > 0)
        {
            if (max < q.Count)
                max = q.Count;
            Node node = q.Dequeue();
            if (node.Left != null)
            {
                q.Enqueue(node.Left);
            }
            if (node.Right != null)
            {
                q.Enqueue(node.Right);
            }
        }
        return max;
    }

    public bool Delete(int data)
    {
        if (Root == null)
            return false;

        Node node = Root;
        Node prev = null;
        bool deleted = false;
        Node newNode = null;

        while (node != null && !deleted)
        {
            if (data > node.Data)
            {
                prev = node;
                node = node.Right;
            }
            else if (data < node.Data)
            {
                prev = node;
                node = node.Left;
            }
            else
            {
                DeleteNode(ref newNode, node);
                deleted = true;
                if (prev == null)
                {
                    Root = newNode;
                }
                else if (prev.Right != null && prev.Right.Data == node.Data)
                {
                    prev.Right = newNode;
                }
                else
                {
                    prev.Left = newNode;
                }
            }
        }

        return deleted;
    }

    void DeleteNode(ref Node newNode, Node node)
    {
        if (node.Left == null)
        {
            newNode = node.Right;
        }
        else if (node.Right == null)
        {
            newNode = node.Left;
        }

        // Case A: Where we pull out the right most node of left subtree of the node to be deleted as
        //  its the highest node just before current ndoe then point right tree to the right of that node
        else
        {
            Node temp = node.Left;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            temp.Right = node.Right;
            newNode = node.Left;
        }+ +

        

        //Case B: pull out the left most node of the right subtree of node to be deleted and point left subtree to the left
        // of that node, this element just next to current element
        //else
        //{
        //    Node temp = node.Right;
        //    while (temp.Left != null)
        //    {
        //        temp = temp.Left;
        //    }
        //    temp.Left = node.Left;
        //    newNode = node.Right;
        //}
        //if (Root.Data == node.Data)
        //{
        //    Root = node.Right;
        //}

        //Case C: find the right most element of left subtree of node to be deleted and then swap the values of
        // right most ndoe and node to be deleted, as we have found the replacement and then join left of that right most node
        // to right of its parent
    }
}

class Program
{
    static void Main(string[] args)
    {
        Tree tree = new Tree();
        Console.WriteLine("\nWelcome to BST Data strucutre\n");
        Console.WriteLine("\nPlease enter the elements in the space seperated format\n");
        int[] dataArr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        foreach (int item in dataArr)
        {
            tree.Insert(item);
        }

        int choice = -1;
        int data = 0;
        while (choice != 0)
        {
            Console.WriteLine("\n\n1.Insert\n2.Pre Order\n3.In Order\n4.Post Order\n5.Number of Nodes\n" +
                "6.Height of the tree\n7.No of leaves\n8.Mirror image tree\n9.Copy Tree\n10.Find Node\n11.BFS" +
                "\n12.Bredth Of the tree\n13.Delete\n");
            Console.WriteLine("\nPlease enter the choice\n");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nPlease enter the element to be inserted in the tree\n");
                    data = int.Parse(Console.ReadLine());
                    tree.Insert(data);
                    break;
                case 2:
                    Console.WriteLine("\nPre-order of the tree\n");
                    tree.PreOrder();
                    break;
                case 3:
                    Console.WriteLine("\nIn-order of the tree\n");
                    tree.InOrder();
                    break;
                case 4:
                    Console.WriteLine("\nPost-order of the tree\n");
                    tree.PostOrder();
                    break;
                case 5:
                    Console.WriteLine(tree.NumOfNodes());
                    break;
                case 6:
                    Console.WriteLine(tree.Height());
                    break;
                case 7:
                    Console.WriteLine(tree.NumLeaves());
                    break;
                case 8:
                    tree.MirrorImage();
                    break;
                case 9:
                    Console.WriteLine("\nCopy of the tree\n");
                    tree.TreeCopy();
                    break;
                case 10:
                    Console.WriteLine("\nPlease enter the element to be searched in the tree\n");
                    data = int.Parse(Console.ReadLine());
                    if (tree.FindNode(data)) { Console.WriteLine("Found"); } else { Console.WriteLine("Not Found"); }
                    break;
                case 11:
                    Console.WriteLine("\nBFS of the tree\n");
                    tree.BFS();
                    break;
                case 12:
                    Console.WriteLine("\nBreadth of the tree\n");
                    Console.WriteLine(tree.Breadth());
                    break;
                case 13:
                    Console.WriteLine("\nPlease enter the element to be deleted in the tree\n");
                    data = int.Parse(Console.ReadLine());
                    if (tree.Delete(data)) { Console.WriteLine("Deleted"); } else { Console.WriteLine("Not Found To be Deleted"); }
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nIn-order of the tree\n");
            tree.InOrder();
        }
        Console.ReadLine();
    }
}