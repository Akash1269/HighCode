// this is max heap
//
// === Core Operations ===
// - Insert(int value)       : Adds a new value and bubbles it up to correct position — O(log n)
// - GetMax()                : Returns the maximum element (root) without removing — O(1)
// - ExtractMax()            : Removes and returns the maximum element — O(log n)
// - Delete(int i)           : Removes element at index i, fixes heap in both directions — O(log n)
//
// === Heap Construction & Sorting ===
// - BuildMaxHeap()          : Converts unordered array into a valid max-heap — O(n)
// - HeapSort()              : Sorts the array in ascending order using heap sort — O(n log n)
//
// === Internal Heapify ===
// - BubbleUp(int i)         : Moves element up until max-heap property is restored — O(log n)
// - MaxHeapifySimple(int i) : Pushes element down to restore heap (standard approach) — O(log n)
// - MaxHeapify(int i)       : Pushes element down (verbose early-return approach) — O(log n)
//
// === Helpers ===
// - Heap(int[] _arr)        : Constructor — initializes heap with given array (does not heapify)
// - Swap(int i, int j)      : Exchanges elements at indices i and j
// - GetParentIndex(int i)   : Returns parent index → (i-1)/2
// - GetLeftIndex(int i)     : Returns left child index → 2i+1
// - GetRightIndex(int i)    : Returns right child index → 2i+2
// - Size()                  : Returns current number of elements in the heap
//
// === Display ===
// - Print()                 : Displays heap elements in array order
// - PrintTree()             : Visualizes the heap as a level-by-level tree
//
class Heap
{
    public int[] arr;
    public int n;
    public int MAX_SIZE = 100;

    public Heap(int[] _arr)
    {
        arr = new int[MAX_SIZE];
        n = _arr.Length;

        for (int i = 0; i < n; i++)
            arr[i] = _arr[i];
    }

    public void BubbleUp(int i)
    {
        if (i >= n) return;

        int parent = GetParentIndex(i);

        while (i > 0 && arr[i] > arr[parent])
        {
            Swap(i, parent);
            i = parent;
            parent = GetParentIndex(i);
        }
    }

    public void Insert(int value)
    {
        if (n >= MAX_SIZE)
        {
            Console.WriteLine("Heap is full");
            return;
        }

        arr[n] = value;
        BubbleUp(n);
        n++;
    }

    public int GetMax()
    {
        if (n == 0) throw new InvalidOperationException("Heap is empty");

        return arr[0];
    }

    public int ExtractMax()
    {
        if (n == 0) throw new InvalidOperationException("Heap is empty");
        int max = arr[0];
        Delete(0);
        return max;
    }

    public void Delete(int i)
    {
        if (i >= n || n == 0) return;

        Swap(i, n - 1);
        n = n - 1;

        BubbleUp(i);
        MaxHeapify(i);
    }

    public void HeapSort()
    {
        BuildMaxHeap();
        Print();
        int size = n;

        while (n > 0)
        {
            Swap(0, n - 1);
            n = n - 1;
            MaxHeapifySimple(0);
        }

        for (int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + "-");
        }
    }

    public void BuildMaxHeap()
    {
        for (int i = n / 2; i >= 0; i--)
        {
            // MaxHeapify(i);
            MaxHeapifySimple(i);
        }
    }

    public void MaxHeapifySimple(int i)
    {
        int left = GetLeftIndex(i);
        int right = GetRightIndex(i);
        int largest = i;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            Swap(largest, i);
            MaxHeapifySimple(largest);
        }
    }

    public void MaxHeapify(int i)
    {
        int left = GetLeftIndex(i);
        int right = GetRightIndex(i);

        if (left >= n && right >= n)
            return;

        // Has only one child then it would always be left due to complete tree
        if (right >= n)
        {
            if (arr[i] > arr[left]) return;
            else
            {
                Swap(left, i);
                MaxHeapify(left);
            }
            return;
        }

        // has both children and no violation
        if (arr[i] > arr[left] && arr[i] > arr[right])
            return;

        // has violation, pick bigger child
        if (arr[left] > arr[right])
        {
            Swap(left, i);
            MaxHeapify(left);
        }
        else
        {
            Swap(right, i);
            MaxHeapify(right);
        }
    }

    private void Swap(int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    private int GetParentIndex(int i)
    {
        return (i - 1) / 2;
    }

    private int GetLeftIndex(int i)
    {
        return 2 * i + 1;
    }

    private int GetRightIndex(int i)
    {
        return 2 * i + 2;
    }

    public int Size()
    {
        return n;
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} | ", arr[i]);
        }

        Console.WriteLine();
    }

    public void PrintTree()
    {
        if (n == 0) return;

        int height = (int)Math.Floor(Math.Log2(n));
        int cellWidth = 4; // minimum spacing per node slot
        int leafSlots = (int)Math.Pow(2, height);
        int totalWidth = leafSlots * cellWidth;

        int index = 0;
        for (int level = 0; level <= height && index < n; level++)
        {
            int nodesAtLevel = (int)Math.Pow(2, level);
            int slotWidth = totalWidth / nodesAtLevel;

            string line = "";
            for (int j = 0; j < nodesAtLevel && index < n; j++)
            {
                string val = arr[index].ToString();
                int padLeft = (slotWidth - val.Length) / 2;
                int padRight = slotWidth - val.Length - padLeft;
                line += new string(' ', padLeft) + val + new string(' ', padRight);
                index++;
            }

            Console.WriteLine(line.TrimEnd());
        }

        Console.WriteLine();
    }
}

public void Manager()
{
    int[] sample = { 2, 16, 4, 7, 1, 9, 12, 3, 11, 14 };
    Heap heap = new Heap(sample);
    heap.Print();
    heap.PrintTree();

    Console.WriteLine("Built Max Heap");
    heap.BuildMaxHeap();
    heap.Print();
    heap.PrintTree();

    // Console.WriteLine("Insert element");
    // heap.Insert(13);
    // heap.Print();
    // heap.PrintTree();

    // Console.WriteLine("Delete element");
    // heap.Delete(2);
    // heap.Print();
    // heap.PrintTree();

    heap.HeapSort();
}

Manager();