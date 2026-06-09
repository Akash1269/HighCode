class Stack
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
    public Node Top { get; set; }

    public Stack()
    {
        Top = null;
    }

    public bool Push(int data)
    {
        try
        {
            Node node = new Node() { Data = data, Next = null };
            node.Next = Top;
            Top = node;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }
    public int Pop()
    {
        if (Top == null)
        {
            return -1;
        }
        int data = Top.Data;
        Top = Top.Next;
        return data;
    }

}

class Program
{
    static void Main(string[] args)
    {
        Stack stack = new Stack();
        int data;
        Console.WriteLine("Welcome to stack using Linked List program");
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
                    if (stack.Push(data))
                        Console.WriteLine("Element pushed successfully");
                    else
                        Console.WriteLine("Cant push element, Stack is full");
                    break;
                case 2:
                    data = stack.Pop();
                    if (data == -1)
                        Console.WriteLine("Stack Empty");
                    else
                        Console.WriteLine("Element: " + data);
                    break;
                default:
                    break;
            }
        }
    }
}