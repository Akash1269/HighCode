
class CircularLL
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }

    Node last;
    public CircularLL()
    {
        Console.WriteLine("Please enter the elements in the space separated format");
        string[] s = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(s, int.Parse);
        for (int i = 0; i < arr.Length; i++)
        {
            this.InsertAtEnd(arr[i]);
        }
    }

    public void InsertAtStart(int data)
    {
        Node node = new Node() { Data = data, Next = null };
        if (last == null)
        {
            last = node;
            last.Next = last;
        }
        node.Next = last.Next;
        last.Next = node;
    }

    public void InsertAtEnd(int data)
    {
        Node node = new Node() { Data = data, Next = null };
        if (last == null)
        {
            node.Next = node;
        }
        else
        {
            node.Next = last.Next;
            last.Next = node;
        }
        last = node;
    }

    public void DeleteAtStart()
    {
        if (last != null && last.Next != last)
        {
            last.Next = last.Next.Next;
        }
        else
        {
            last = null;
        }
    }
    public void DeleteAtEnd()
    {
        Node itr = last.Next;
        if (last != null && last.Next != last)
        {
            while (itr.Next != last)
            {
                itr = itr.Next;
            }
            itr.Next = last.Next;
            last = itr;
        }
        else
        {
            last = null;
        }
    }

    public void PrintAll()
    {
        if (last != null)
        {
            Node itr = last.Next;
            while (itr != last)
            {
                Console.Write(itr.Data + " -> ");
                itr = itr.Next;
            }
            Console.Write(itr.Data + " -> null");
        }
        else
        {
            Console.WriteLine("list is empty");
        }
    }

    public void Concat(CircularLL anotherList)
    {


        if (last == null)
        {
            last = anotherList.last;
        }
        else if (anotherList.last == null) { }
        else
        {
            Node start1 = last.Next;
            Node start2 = anotherList.last.Next;
            last.Next = start2;
            anotherList.last.Next = start1;
            last = anotherList.last;
        }
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
        CircularLL list = new CircularLL();
        CircularLL AnotherList;

        Console.WriteLine("\nPlease find below the list of elements");
        list.PrintAll();

        int choice = 5;
        int data = 0;

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
            Console.WriteLine("5.Print All");
            Console.WriteLine("6.Create Second List Concat with First List");
            //Console.WriteLine("7.Exit");
            //Console.WriteLine("8.Exit");

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
                    list.PrintAll();
                    break;
                case 6:
                    AnotherList = new CircularLL();
                    list.Concat(AnotherList);
                    list.PrintAll();
                    break;
                default:
                    break;
            }

        }
    }
}