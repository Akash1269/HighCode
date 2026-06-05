class Book
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Price { get; set; }
    public int Copies { get; set; }
}

class Library
{
    const int MAX_SIZE = 100;

    public Book[] Books { get; set; }
    public int Length { get; set; }

    public Library()
    {
        Books = new Book[MAX_SIZE];
        Length = 0;
    }

    bool IsFull()
    {
        return Length == 100;
    }

    bool IsEmpty()
    {
        return Length == 0;
    }
    public bool Insert(Book book)
    {
        if (IsFull() && Find(book.ID) != -1)
            return false;

        Books[Length] = book;
        Length++;
        return true;
    }

    public int Find(int ID)
    {
        for (int i = 0; i < Length; i++)
        {
            if (Books[i].ID == ID)
                return i;
        }
        return -1;
    }

    public bool Delete(int ID)
    {

        int found = Find(ID);
        if (IsEmpty() || found == -1)
            return false;

        for (int i = found; i < Length; i++)
        {
            Books[i] = Books[i + 1];
        }
        Length--;
        return true;
    }

    public bool Update(Book book)
    {
        int index = Find(book.ID);
        if (IsEmpty() || index == -1)
            return false;
        Books[index] = book;
        return true;
    }

    void swap(ref Book a, ref Book b)
    {
        Book temp = a;
        a = b;
        b = temp;
    }

    int compareBooks(Book a, Book b)
    {
        return string.Compare(a.Name, b.Name);
    }

    public void sort()
    {
        int compare;
        bool sorted = false;
        for (int i = 0; i < Length && sorted == false; i++)
        {
            sorted = true;
            for (int j = 0; j < Length - 1; j++)
            {
                compare = compareBooks(Books[j], Books[j + 1]);
                if (compare > 0)
                {
                    sorted = false;
                    swap(ref Books[j], ref Books[j + 1]);
                }
            }
        }
    }

    public void PrintAllRecords()
    {
        for (int i = 0; i < Length; i++)
        {
            Console.WriteLine(Books[i].ID + " - " + Books[i].Name + " - " + Books[i].Author + " - " + Books[i].Price + " - " + Books[i].Copies);
        }
    }
}

class LibraryIO
{
    static public Library ReadLibraryDataFromFile(string filePath)
    {
        string line;
        Library l = new Library();
        using (StreamReader myReader = new StreamReader(filePath))
        {
            while ((line = myReader.ReadLine()) != null)
            {
                string[] record = line.Split('\t');
                Book book = new Book();
                book.ID = int.Parse(record[0]);
                book.Name = record[1];
                book.Author = record[2];
                book.Price = int.Parse(record[3]);
                book.Copies = int.Parse(record[4]);
                l.Insert(book);
            }
        }
        return l;
    }

    static public bool WriteLibraryDataToFile(string filePath, Library l)
    {
        Book book;
        using (StreamWriter myWriter = new StreamWriter(filePath))
        {
            if (myWriter == null)
            {
                return false;
            }
            for (int i = 0; i < l.Length; i++)
            {
                book = l.Books[i];
                string record = book.ID.ToString() + "\t" + book.Name + '\t' + book.Author + '\t' + book.Price + '\t' + book.Copies;
                myWriter.WriteLine(record);
            }
        }
        return true;
    }


    static public Book ReadBookRecordFromConsole()
    {
        Book book = new Book();
        Console.WriteLine("Enter The Details Below in tab Seperated Format");

        string[] record = Console.ReadLine().Split('\t');

        book.ID = int.Parse(record[0]);
        book.Name = record[1];
        book.Author = record[2];
        book.Price = int.Parse(record[3]);
        book.Copies = int.Parse(record[4]);

        return book;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\n\t\t\tWelcome to Library Management System");

        const string FILE_PATH = @"c:\users\hp\documents\visual studio 2015\Projects\ArrayDSLibrary\ArrayDSLibrary\Data\library.txt";
        Library l = LibraryIO.ReadLibraryDataFromFile(FILE_PATH);
        bool flag;
        int choice = -1, index;
        while (choice != 0)
        {
            switch (choice)
            {
                case 1:
                    flag = l.Insert(LibraryIO.ReadBookRecordFromConsole());
                    if (flag)
                        Console.WriteLine("Succefully inserted the record in the library");
                    else
                        Console.WriteLine("Error: Library is Already Full or record is already present for the given ID");
                    break;
                case 2:
                    flag = l.Update(LibraryIO.ReadBookRecordFromConsole());
                    if (flag)
                        Console.WriteLine("Succefully Updated the record in the library");
                    else
                        Console.WriteLine("Error: Record Not Found");
                    break;
                case 3:
                    Console.WriteLine("Please enter the ID of the record to be deleted");
                    flag = l.Delete(int.Parse(Console.ReadLine()));
                    if (flag)
                        Console.WriteLine("Succefully deleted the record in the library");
                    else
                        Console.WriteLine("Error: Record not found");
                    break;
                case 4:
                    Console.WriteLine("Please enter the ID of the record to search");
                    index = l.Find(int.Parse(Console.ReadLine()));
                    if (index != -1)
                        Console.WriteLine("Record found at index : " + index);
                    else
                        Console.WriteLine("Error: Record not found");
                    break;
                case 5:
                    l.PrintAllRecords();
                    break;
                case 6:
                    Console.WriteLine("Size of the library is : " + l.Length);
                    break;
                case 7:
                    l.sort();
                    Console.WriteLine("All elements are sorted successfully");
                    l.PrintAllRecords();
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n\n*******MENU*******\n\n");

            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Insert");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Print All Records");
            Console.WriteLine("6.Size");
            Console.WriteLine("7.Sort");

            Console.Write("\nPlease Enter The choice from the Menu : ");
            choice = int.Parse(Console.ReadLine());
        }

        flag = LibraryIO.WriteLibraryDataToFile(FILE_PATH, l);
        if (flag)
            Console.WriteLine("All data has been successfull saved to files");
        else
            Console.WriteLine("Unable to save the data to file");
    }
}