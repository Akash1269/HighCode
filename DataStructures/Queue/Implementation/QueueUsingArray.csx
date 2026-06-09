class Queue
{
    const int MAX_SIZE = 10;
    public int[] list { get; set; }
    public int front { get; set; }
    public int rear { get; set; }
    public int size { get; set; }

    public Queue()
    {
        list = new int[MAX_SIZE];
        rear = -1;
        front = 0;
        size = 0;
    }
    public bool Push(int data)
    {
        if (size == MAX_SIZE)
            return false;

        rear = (rear + 1) % MAX_SIZE;
        list[rear] = data;
        size++;

        return true;
    }
    public int Pop()
    {
        if (size == 0)
            return -1;

        int data = list[front];
        front = (front + 1) % MAX_SIZE;
        size--;
        return data;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue queue = new Queue();
        int data;
        Console.WriteLine("Welcome to queue using Array program");
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