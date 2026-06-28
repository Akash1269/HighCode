// Question - Elementary Sorting Algorithms: Bubble, Selection, Insertion, Shell Sort
// #sorting #bubble-sort #selection-sort #insertion-sort #shell-sort #princeton

// Bubble Sort — O(n²) avg/worst, O(n) best (with early exit)
// Repeatedly swaps adjacent out-of-order elements
void BubbleSort(int[] list)
{
    for (int i = 0; i < list.Length; i++)
    {
        bool swapped = false;
        for (int j = 0; j < list.Length - 1 - i; j++)
        {
            if (list[j] > list[j + 1])
            {
                (list[j], list[j + 1]) = (list[j + 1], list[j]);
                swapped = true;
            }
        }
        if (!swapped) break; // already sorted
    }
}

// Selection Sort — O(n²) always, not stable
// Find minimum in unsorted portion, swap to front
void SelectionSort(int[] list)
{
    for (int i = 0; i < list.Length; i++)
    {
        int minIdx = i;
        for (int j = i + 1; j < list.Length; j++)
        {
            if (list[j] < list[minIdx])
                minIdx = j;
        }
        (list[i], list[minIdx]) = (list[minIdx], list[i]);
    }
}

// Insertion Sort — O(n²) avg/worst, O(n) best (nearly sorted data)
// Builds sorted portion left-to-right, inserts each element in correct position
void InsertionSort(int[] list, int low = -1, int high = -1)
{
    if (low == -1) { low = 0; high = list.Length - 1; }
    for (int i = low; i <= high; i++)
    {
        for (int j = i; j > low && list[j] < list[j - 1]; j--)
            (list[j], list[j - 1]) = (list[j - 1], list[j]);
    }
}

// Shell Sort — O(n^1.5) using Knuth's 3x+1 gap sequence
// Generalized insertion sort — sorts elements h-apart, then shrinks h
void ShellSort(int[] list)
{
    int h = 1;
    while (h < list.Length / 3)
        h = h * 3 + 1; // Knuth sequence: 1, 4, 13, 40, 121, ...

    while (h >= 1)
    {
        for (int i = h; i < list.Length; i++)
        {
            for (int j = i; j >= h && list[j] < list[j - h]; j -= h)
                (list[j], list[j - h]) = (list[j - h], list[j]);
        }
        h /= 3;
    }
}

// --- Demo ---
void PrintSort(string name, Action<int[]> sortFn, int[] source)
{
    int[] arr = (int[])source.Clone();
    sortFn(arr);
    Console.WriteLine($"{name,-18}: {string.Join(" ", arr)}");
}

int[] data = { 38, 27, 43, 3, 9, 82, 10 };
Console.WriteLine($"{"Original",-18}: {string.Join(" ", data)}\n");

PrintSort("Bubble Sort", BubbleSort, data);
PrintSort("Selection Sort", SelectionSort, data);
PrintSort("Insertion Sort", a => InsertionSort(a), data);
PrintSort("Shell Sort", ShellSort, data);
