class Queue
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public Node Front { get; set; }
    public Node Rear { get; set; }

    public Queue()
    {
        Front = Rear = null;
    }
    public bool Push(int data)
    {
        Node node = new Node() { Data = data, Next = null };
        if (Front == null)
        {
            Front = Rear = node;
            return true;
        }

        Rear.Next = node;
        Rear = node;
        return true;
    }
    public int Pop()
    {
        if (Front == null)
            return -1;

        int data = Front.Data;
        Front = Front.Next;
        return data;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue queue = new Queue();
        int data;
        Console.WriteLine("Welcome to queue using Linked List program");
        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Push");
            Console.WriteLine("2.Pop");
            Console.WriteLine("Please enter appropriate choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter the element");
                    data = int.Parse(Console.ReadLine());
                    if (queue.Push(data))
                        Console.WriteLine("Element pushed successfully");
                    else
                        Console.WriteLine("Cant push element, Queue is full");
                    break;
                case 2:
                    data = queue.Pop();
                    if (data == -1)
                        Console.WriteLine("Queue is already empty");
                    else
                        Console.WriteLine("Element: " + data);
                    break;
                default:
                    break;
            }
        }
    }
}