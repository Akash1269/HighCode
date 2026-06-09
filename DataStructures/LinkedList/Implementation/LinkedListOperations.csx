// ── Node ──────────────────────────────────────────────────────────
class Node
{
    public int Data;
    public Node Next;
}

// ── LinkedList ────────────────────────────────────────────────────
class LinkedList
{
    Node head;

    public void InsertAtStart(int data)
    {
        Node node = new Node();
        node.Data = data;
        node.Next = head;
        head = node;
    }

    public int DeleteAtStart()
    {
        int data = -1;
        if (head != null)
        {
            data = head.Data;
            head = head.Next;
        }
        return data;
    }

    public void InsertAtEnd(int data)
    {
        Node node = new Node();
        Node temp = head;

        node.Data = data;
        if (head == null)
        {
            head = node;
            return;
        }
        while (temp.Next != null)
            temp = temp.Next;
        temp.Next = node;
    }

    public int DeleteAtEnd()
    {
        int data = -1;

        if (head == null) return -1;
        if (head.Next == null)
        {
            data = head.Data;
            head = null;
            return data;
        }

        Node temp = head;
        while (temp.Next.Next != null)
            temp = temp.Next;

        data = temp.Next.Data;
        temp.Next = null;
        return data;
    }

    public void InsertInSortedList(int data)
    {
        Node node = new Node() { Data = data, Next = null };

        if (head == null || data <= head.Data)
        {
            node.Next = head;
            head = node;
            return;
        }

        Node temp = head;
        while (temp.Next != null && temp.Next.Data < data)
            temp = temp.Next;

        node.Next = temp.Next;
        temp.Next = node;
    }

    public int Find(int data)
    {
        int location = -1;
        Node temp = head;
        int i = 0;
        while (temp != null)
        {
            i++;
            if (temp.Data == data) location = i;
            temp = temp.Next;
        }
        return location;
    }

    public void RemoveDuplicates()
    {
        if (head == null) return;

        var set = new HashSet<int>();
        Node temp = head.Next;
        Node tail = head;
        set.Add(tail.Data);

        while (temp != null)
        {
            if (set.Contains(temp.Data))
            {
                tail.Next = temp.Next;
                temp = tail.Next;
            }
            else
            {
                set.Add(temp.Data);
                tail = temp;
                temp = temp.Next;
            }
        }
    }

    public void Reverse()
    {
        Node mid = null, tail = null;
        while (head != null)
        {
            tail = mid;
            mid = head;
            head = head.Next;
            mid.Next = tail;
        }
        head = mid;
    }

    void Swap(Node a, Node b)
    {
        int temp = a.Data;
        a.Data = b.Data;
        b.Data = temp;
    }

    public void Sort()
    {
        bool sorted = false;
        do
        {
            sorted = true;
            Node ptr = head;
            while (ptr.Next != null)
            {
                if (ptr.Data > ptr.Next.Data)
                {
                    sorted = false;
                    Swap(ptr, ptr.Next);
                }
                ptr = ptr.Next;
            }
        } while (!sorted);
    }

    public void PrintList()
    {
        Console.WriteLine("\nLinked list:");
        Node temp = head;
        if (temp == null)
        {
            Console.WriteLine("List is empty.\n");
            return;
        }
        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        Console.Write("null\n");
    }

    public int GetSize()
    {
        Node temp = head;
        int count = 0;
        while (temp != null) { temp = temp.Next; count++; }
        return count;
    }

    public void EmptyList() => head = null;
}

// ── Tests ─────────────────────────────────────────────────────────
var list = new LinkedList();
list.InsertAtEnd(3);
list.InsertAtEnd(1);
list.InsertAtEnd(4);
list.InsertAtEnd(1);
list.InsertAtEnd(5);
list.PrintList();           // 3 -> 1 -> 4 -> 1 -> 5 -> null

list.RemoveDuplicates();
list.PrintList();           // 3 -> 1 -> 4 -> 5 -> null

list.Sort();
list.PrintList();           // 1 -> 3 -> 4 -> 5 -> null

list.Reverse();
list.PrintList();           // 5 -> 4 -> 3 -> 1 -> null

Console.WriteLine($"Size: {list.GetSize()}");       // 4
Console.WriteLine($"Find 3: index {list.Find(3)}"); // index 3
