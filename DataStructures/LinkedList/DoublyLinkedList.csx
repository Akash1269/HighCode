class DoublyLL
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }

    public Node Head { get; set; }

    public void InsertAtStart(int data)
    {
        Node node = new Node() { Data = data, Next = null, Prev = null };
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }
    }
    public void DeleteAtStart()
    {
        if (Head == null || Head.Next == null)
        {
            Head = null;
        }
        else
        {
            Head = Head.Next;
            Head.Prev = null;
        }
    }
    public void InsertAtEnd(int data)
    {
        Node node = new Node() { Data = data, Next = null, Prev = null };
        if (Head == null)
        {
            Head = node;
        }
        else
        {
            Node temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = node;
            node.Prev = temp;
        }
    }
    public void DeleteAtEnd()
    {
        if (Head == null || Head.Next == null)
        {
            Head = null;
        }
        else
        {
            Node temp = Head;
            while (temp.Next.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = null;
        }
    }
    public bool DeleteNode(int data)
    {
        Node temp = Head;
        while (temp != null)
        {
            if (temp.Data == data)
            {
                Node prev = temp.Prev;
                Node next = temp.Next;
                if (prev != null)
                {
                    prev.Next = next;
                }
                else
                {
                    Head = next;
                }
                if (next != null)
                {
                    next.Prev = prev;
                }
                return true;
            }
            temp = temp.Next;
        }
        return false;
    }

    public void PrintAll()
    {
        Node temp = Head;
        Console.WriteLine();
        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        Console.WriteLine("null\n");
    }

    public void PrintReverse()
    {
        Node temp = Head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Prev;
        }
        Console.WriteLine("null\n");
    }

}

class Program
{

    static int GetData()
    {
        Console.WriteLine("Please enter the value of data for the selected oprations");
        return int.Parse(Console.ReadLine());
    }

    static void Main(string[] args)
    {
        DoublyLL list = new DoublyLL();
        Console.WriteLine("Welcome to Doubly lisnked list program\n");
        Console.WriteLine("Please enter the elements in the space seperated format\n");
        string[] temp = Console.ReadLine().Split(' ');
        int[] num = Array.ConvertAll(temp, int.Parse);
        foreach (int item in num)
        {
            list.InsertAtEnd(item);
        }
        int data = 0;
        int choice = 6;
        while (choice != 0)
        {
            Console.WriteLine("\n");
            list.PrintAll();
            Console.WriteLine("\n");

            Console.WriteLine("MENU");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Insert At Start");
            Console.WriteLine("2.Insert At End");
            Console.WriteLine("3.Delete At Start");
            Console.WriteLine("4.Delete At End");
            Console.WriteLine("5.Delete Item");
            Console.WriteLine("6.Print All");
            Console.WriteLine("7.Print Reverse");

            Console.WriteLine("Please Enter choice here: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    data = GetData();
                    list.InsertAtStart(data);
                    break;
                case 2:
                    data = GetData();
                    list.InsertAtEnd(data);
                    break;
                case 3:
                    list.DeleteAtStart();
                    break;
                case 4:
                    list.DeleteAtEnd();
                    break;
                case 5:
                    data = GetData();
                    list.DeleteNode(data);
                    break;
                case 6:
                    list.PrintAll();
                    break;
                case 7:
                    list.PrintReverse();
                    break;
                default:
                    break;
            }
        }
    }



}