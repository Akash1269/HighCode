// Question - Resizable Generic Array List (Dynamic Array)
// #array #generics #data-structure #princeton

using System.Collections;

// Resizable array that doubles when full, halves when 1/4 full
// Add: O(1) amortized | Get: O(1) | Remove: O(n)

class ArrayList<T> : IEnumerable<T>
{
    private T[] Items;
    public int Count { get; private set; }
    private int Capacity;

    public ArrayList(int size = 2)
    {
        Items = new T[size];
        Capacity = size;
        Count = 0;
    }

    private void Resize(int newSize)
    {
        Capacity = newSize;
        T[] newItems = new T[Capacity];
        for (int i = 0; i < Count; i++)
            newItems[i] = Items[i];
        Items = newItems;
    }

    public void Add(T data)
    {
        if (Count == Capacity)
            Resize(Capacity * 2);
        Items[Count++] = data;
    }

    public T Get(int i)
    {
        if (i < 0 || i >= Count)
            throw new IndexOutOfRangeException($"Index {i} is out of range [0, {Count - 1}]");
        return Items[i];
    }

    public bool Remove(T data)
    {
        for (int i = 0; i < Count; i++)
        {
            if (data.Equals(Items[i]))
            {
                // shift left
                for (int j = i; j < Count - 1; j++)
                    Items[j] = Items[j + 1];
                Items[--Count] = default(T); // prevent memory leak
                // shrink when 1/4 full
                if (Count >= 2 && Count <= Capacity / 4)
                    Resize(Capacity / 2);
                return true;
            }
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
            yield return Items[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// --- Demo ---
Console.WriteLine("=== Generic ArrayList ===\n");

var list = new ArrayList<int>();
foreach (var val in new[] { 1, 2, 3, 4, 5, 6, 7, 8 })
    list.Add(val);

Console.Write("After adding 1-8: ");
Console.WriteLine(string.Join(" ", list));
Console.WriteLine($"Count: {list.Count}");

Console.WriteLine($"Get(3): {list.Get(3)}");

list.Remove(5);
Console.Write("After Remove(5): ");
Console.WriteLine(string.Join(" ", list));

list.Remove(1); list.Remove(2); list.Remove(3); list.Remove(4);
Console.Write("After removing 1-4: ");
Console.WriteLine(string.Join(" ", list));
Console.WriteLine($"Count: {list.Count}");
