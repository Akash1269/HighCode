
// See LinkedList.md for full API reference and key concepts.

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