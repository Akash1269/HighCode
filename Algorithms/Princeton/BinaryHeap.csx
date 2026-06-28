// Question - Binary Heap (Max Priority Queue)
// #heap #priority-queue #data-structure #princeton

// Max Binary Heap — 1-indexed array
// Insert: O(log n) — add at end, swim up
// DeleteMax: O(log n) — swap root with last, sink down
// ReadMax: O(1) — peek at root

class MaxHeap
{
    private int[] heap;
    public int Count { get; private set; }

    public MaxHeap(int capacity)
    {
        heap = new int[capacity + 1]; // 1-indexed
        Count = 0;
    }

    public bool IsEmpty => Count == 0;

    public int ReadMax()
    {
        if (IsEmpty) throw new InvalidOperationException("Heap is empty");
        return heap[1];
    }

    public void Insert(int val)
    {
        heap[++Count] = val;
        Swim(Count);
    }

    public int DeleteMax()
    {
        if (IsEmpty) throw new InvalidOperationException("Heap is empty");
        int max = heap[1];
        (heap[1], heap[Count]) = (heap[Count], heap[1]);
        Count--;
        Sink(1);
        return max;
    }

    // Swim up: child > parent → swap
    private void Swim(int i)
    {
        while (i > 1 && heap[i] > heap[i / 2])
        {
            (heap[i], heap[i / 2]) = (heap[i / 2], heap[i]);
            i /= 2;
        }
    }

    // Sink down: parent < larger child → swap
    private void Sink(int i)
    {
        while (2 * i <= Count)
        {
            int j = 2 * i;
            if (j < Count && heap[j + 1] > heap[j]) j++; // pick larger child
            if (heap[i] >= heap[j]) break;
            (heap[i], heap[j]) = (heap[j], heap[i]);
            i = j;
        }
    }
}

// --- Demo ---
Console.WriteLine("=== Max Binary Heap (Priority Queue) ===\n");

var pq = new MaxHeap(20);
foreach (var val in new[] { 10, 20, 5, 30, 15, 25 })
{
    pq.Insert(val);
    Console.WriteLine($"Insert({val}) → Max: {pq.ReadMax()}");
}

Console.WriteLine();
while (!pq.IsEmpty)
    Console.WriteLine($"DeleteMax: {pq.DeleteMax()}");
