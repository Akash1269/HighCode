
// See LinkedList.md for full API reference and key concepts.
// TODO: Functions - InsertInSortedList, RemoveDuplicates, Reverse, Sort

class Node
{
    public int Data;
    public Node Next;

    public Node(int value)
    {
        Data = value;
        Next = null;
    }
}

class LinkedList
{
    private Node _head;

    public int Count { get; private set; }

    public LinkedList()
    {
        _head = null;
    }

    public void InsertAtStart(int value)
    {
        var newNode = new Node(value);

        newNode.Next = _head;
        _head = newNode;
        Count++;
    }

    public void InsertAtEnd(int value)
    {
        if (_head == null) InsertAtStart(value);
        else
        {
            var newNode = new Node(value);
            var lastNode = GetLastNode();
            lastNode.Next = newNode;
            Count++;
        }
    }

    public void InsertAt(int index, int value)
    {

        if (index == Count) InsertAtEnd(value);
        if (index == 0) InsertAtStart(value);

        if (IsIndexOutOfBound(index))
        {
            return;
            // Throw Exception
        }

        else
        {
            var prevNodeOfInsert = GetPrevNodeOfIndex(index);

            var newNode = new Node(value);
            newNode.Next = prevNodeOfInsert.Next;
            prevNodeOfInsert.Next = newNode;

            Count++;
        }
    }

    public void InsertAtUsingSentinel(int index, int value)
    {
        if (IsIndexOutOfBound(index) && index != Count)
        {
            return;
            // Throw Exception
        }

        var newNode = new Node(value);

        var sentinel = new Node(0) { Next = _head };
        var current = sentinel;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
        _head = sentinel.Next;
        Count++;
    }

    public bool Remove(int value)
    {
        if (_head == null) return false;

        if (value == _head.Data)
        {
            RemoveFromStart();
            return true;
        }

        var prevNode = FindPrevNode(value);
        if (prevNode == null)
        {

            return false;
        }

        var nodeToBeDeleted = prevNode.Next;
        prevNode.Next = nodeToBeDeleted.Next;
        Count--;

        return true;
    }

    public bool RemoveAt(int index)
    {
        if (index == 0)
        {
            RemoveFromStart();
            return true;
        }

        var prevNode = GetPrevNodeOfIndex(index);
        if (prevNode == null) return false;

        prevNode.Next = prevNode.Next.Next;
        Count--;
        return true;
    }



    public bool RemoveFromStart()
    {
        if (_head == null) return false;

        _head = _head.Next;
        Count--;
        return true;
    }

    public bool RemoveFromEnd()
    {
        if (_head == null) return false;

        if (_head.Next == null)
        {
            _head = null;
            Count = 0;
            return true;
        }

        var currentNode = _head;
        var prevNode = _head;
        while (currentNode.Next != null)
        {
            prevNode = currentNode;
            currentNode = currentNode.Next;
        }

        prevNode.Next = null;
        Count--;
        return true;
    }

    public Node FindNode(int value)
    {
        var currentNode = _head;
        while (currentNode != null)
        {
            if (value == currentNode.Data)
            {
                return currentNode;
            }
            currentNode = currentNode.Next;
        }

        return null;
    }

    public Node GetLastNode()
    {
        if (_head == null) return null;

        var currentNode = _head;
        while (currentNode.Next != null)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    public Node FindPrevNode(int value)
    {
        var currentNode = _head;
        Node prevNode = null;

        while (currentNode != null)
        {
            if (value == currentNode.Data)
            {
                return prevNode;
            }

            prevNode = currentNode;
            currentNode = currentNode.Next;
        }

        return null;
    }

    public void Print()
    {
        Node currentNode = _head;
        while (currentNode != null)
        {
            Console.Write(currentNode.Data + " -> ");
            currentNode = currentNode.Next;
        }
        Console.WriteLine(" -------- Count : " + Count);
    }

    private Node GetPrevNodeOfIndex(int index)
    {
        if (index == 0 || IsIndexOutOfBound(index)) return null;

        Node currentNode = _head;
        for (int i = 0; i < index - 1; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    private bool IsIndexOutOfBound(int index)
    {
        return index < 0 || index >= Count;
    }

    public bool IsEmpty() => _head == null;

    public void Clear() { _head = null; Count = 0; }
}


// Execution and test
Console.WriteLine("Welcome to LinkedList");

var ll = new LinkedList();
ll.InsertAtEnd(1);
ll.InsertAtEnd(5);
ll.InsertAtStart(4);
ll.InsertAtEnd(3);
ll.InsertAtStart(6);
ll.Print();

ll.InsertAt(4, 8);
ll.InsertAtUsingSentinel(6, 9);
ll.Print();

ll.RemoveFromStart();
ll.RemoveFromEnd();
ll.Print();

ll.InsertAtStart(2);
ll.InsertAtEnd(7);
ll.Print();

ll.RemoveAt(0);
ll.RemoveAt(3);
ll.Print();

ll.InsertAtStart(3);
ll.Remove(5);
ll.Remove(4);
ll.Print();

Console.WriteLine();
Console.WriteLine("Length : " + ll.Count);

var prev = ll.FindPrevNode(7);
Console.WriteLine("Previous node : " + prev?.Data);
prev = ll.FindPrevNode(1);
Console.WriteLine("Previous node : " + prev?.Data);

var current = ll.FindNode(7);
Console.WriteLine("Current node : " + current?.Data);

var last = ll.GetLastNode();
Console.WriteLine("Last node : " + last?.Data);
ll.Print();
Console.WriteLine("Is List Empty : " + ll.IsEmpty());
ll.Clear();
Console.WriteLine("Is List Empty : " + ll.IsEmpty());
ll.Print();


// Master Program to run and simulate any action 
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Linked Program");
        Console.WriteLine("\nPlease enter numbers to be inserted into the list in space separated format");

        string[] temp = Console.ReadLine().Split(' ');
        int[] values = Array.ConvertAll(temp, int.Parse);

        LinkedList list = new LinkedList();

        foreach (int item in values)
        {
            list.InsertAtStart(item);
        }
        int option = 1;
        int d;
        while (option != 0)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Exiting!!!");
                    break;
                case 1:
                    list.PrintList();
                    break;
                case 2:
                    Console.WriteLine(list.GetSize());
                    break;
                case 3:
                    list.EmptyList();
                    Console.WriteLine("List deleted successfully");
                    break;
                case 4:
                    Console.WriteLine("Please enter the intger value for the element to be inserted : ");
                    d = int.Parse(Console.ReadLine());
                    list.InsertAtStart(d);
                    break;
                case 5:
                    list.DeleteAtStart();
                    Console.WriteLine("Element at the start of the list deleted successfully");
                    break;
                case 6:
                    Console.WriteLine("Please enter the intger value for the element to be inserted : ");
                    d = int.Parse(Console.ReadLine());
                    list.InsertAtEnd(d);
                    break;
                case 7:
                    list.DeleteAtEnd();
                    Console.WriteLine("Element at the end of the list deleted successfully");
                    break;
                case 8:
                    Console.WriteLine("Please enter the the value to be searched");
                    d = int.Parse(Console.ReadLine());
                    Console.WriteLine("The element present at address - " + list.Find(d));
                    break;
                case 9:
                    list.RemoveDuplicates();
                    Console.WriteLine("Remvoed duplicates successfully");
                    break;
                case 10:
                    list.Reverse();
                    Console.WriteLine("List has been reversed successfully");
                    break;
                case 11:
                    list.Sort();
                    Console.WriteLine("List has been sorted successfully");
                    break;
                case 12:
                    d = int.Parse(Console.ReadLine());
                    list.InsertInSortedList(d);
                    Console.WriteLine("element inserted successfully");
                    break;
                default:
                    Console.WriteLine("Invalid options, Please enter the Correct choice Again");
                    break;
            }
            list.PrintList();

            Console.WriteLine(@"
                    Plese select option from the menu
                    0.Exit
                    1.Print List
                    2.Get Size
                    3.Delete List
                    4.Insert At Start
                    5.Delete At Start
                    6.Insert At End
                    7.Delete At End
                    8.Find
                    9.Remove Duplicates
                    10.Reverse
                    11.Sort
                    12.Insert in sorted array (please sort before inserting)
                    ");

            option = int.Parse(Console.ReadLine());
        }
    }
}