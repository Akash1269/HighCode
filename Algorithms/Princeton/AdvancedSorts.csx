// Question - Advanced Sorting: Merge Sort, Quick Sort, Heap Sort, Quick Select
// #sorting #merge-sort #quick-sort #heap-sort #quick-select #princeton

// ============================================================
// MERGE SORT — O(n log n) guaranteed, O(n) space, stable
// Divide array in half, sort each, merge back
// Optimization: cutoff to insertion sort for small subarrays
// ============================================================

const int MERGE_CUTOFF = 7;

void MergeSort(int[] list)
{
    int[] aux = new int[list.Length];
    MergeSortHelper(list, aux, 0, list.Length - 1);
}

void MergeSortHelper(int[] list, int[] aux, int low, int high)
{
    if (high - low < MERGE_CUTOFF)
    {
        InsertionSort(list, low, high);
        return;
    }
    int mid = low + (high - low) / 2;
    MergeSortHelper(list, aux, low, mid);
    MergeSortHelper(list, aux, mid + 1, high);
    if (list[mid] <= list[mid + 1]) return; // already sorted
    Merge(list, aux, low, mid, high);
}

void Merge(int[] list, int[] aux, int low, int mid, int high)
{
    for (int k = low; k <= high; k++) aux[k] = list[k];

    int i = low, j = mid + 1;
    for (int k = low; k <= high; k++)
    {
        if (i > mid)              list[k] = aux[j++];
        else if (j > high)        list[k] = aux[i++];
        else if (aux[j] < aux[i]) list[k] = aux[j++];
        else                      list[k] = aux[i++];
    }
}

// ============================================================
// BOTTOM-UP MERGE SORT — O(n log n), iterative, no recursion
// Merge subarrays of size 1, 2, 4, 8, ... 
// ============================================================

void BottomUpMergeSort(int[] list)
{
    int[] aux = new int[list.Length];
    for (int sz = 1; sz < list.Length; sz *= 2)
    {
        for (int lo = 0; lo < list.Length - sz; lo += 2 * sz)
        {
            Merge(list, aux, lo, lo + sz - 1, Math.Min(list.Length - 1, lo + 2 * sz - 1));
        }
    }
}

// ============================================================
// QUICK SORT — O(n log n) avg, O(n²) worst, in-place
// Partition around pivot, recurse on halves
// Cutoff to insertion sort for small subarrays
// ============================================================

const int QUICK_CUTOFF = 5;

void QuickSort(int[] list)
{
    QuickSortHelper(list, 0, list.Length - 1);
}

void QuickSortHelper(int[] list, int low, int high)
{
    if (high <= low + QUICK_CUTOFF - 1)
    {
        InsertionSort(list, low, high);
        return;
    }
    int j = Partition(list, low, high);
    QuickSortHelper(list, low, j - 1);
    QuickSortHelper(list, j + 1, high);
}

int Partition(int[] list, int low, int high)
{
    int i = low + 1, j = high;
    while (true)
    {
        while (i <= high && list[i] <= list[low]) i++;
        while (j > low && list[j] >= list[low]) j--;
        if (i >= j) break;
        (list[i], list[j]) = (list[j], list[i]);
        i++; j--;
    }
    (list[low], list[j]) = (list[j], list[low]);
    return j;
}

// ============================================================
// 3-WAY QUICK SORT (Dijkstra) — optimal for many duplicates
// Partitions into 3 regions: < pivot | == pivot | > pivot
// ============================================================

void ThreeWayQuickSort(int[] list)
{
    ThreeWayHelper(list, 0, list.Length - 1);
}

void ThreeWayHelper(int[] list, int low, int high)
{
    if (high <= low) return;
    int lt = low, gt = high, i = low + 1;
    int pivot = list[low];

    while (i <= gt)
    {
        if (list[i] < pivot)
        {
            (list[i], list[lt]) = (list[lt], list[i]);
            i++; lt++;
        }
        else if (list[i] > pivot)
        {
            (list[i], list[gt]) = (list[gt], list[i]);
            gt--;
        }
        else
        {
            i++;
        }
    }
    // list[low..lt-1] < pivot, list[lt..gt] == pivot, list[gt+1..high] > pivot
    ThreeWayHelper(list, low, lt - 1);
    ThreeWayHelper(list, gt + 1, high);
}

// ============================================================
// QUICK SELECT — O(n) avg to find kth smallest element
// Uses partition to narrow search to one side
// ============================================================

int QuickSelect(int[] list, int k)
{
    int low = 0, high = list.Length - 1;
    while (low < high)
    {
        int j = Partition(list, low, high);
        if (j < k)       low = j + 1;
        else if (j > k)  high = j - 1;
        else              return list[k];
    }
    return list[k];
}

// ============================================================
// HEAP SORT — O(n log n) guaranteed, O(1) space, not stable
// Build max-heap bottom-up, then repeatedly extract max
// ============================================================

void HeapSort(int[] a)
{
    int n = a.Length;
    // build heap (bottom-up)
    for (int i = n / 2 - 1; i >= 0; i--)
        Sink(a, i, n);
    // sortdown
    for (int end = n - 1; end > 0; end--)
    {
        (a[0], a[end]) = (a[end], a[0]);
        Sink(a, 0, end);
    }
}

void Sink(int[] a, int i, int n)
{
    while (2 * i + 1 < n)
    {
        int j = 2 * i + 1; // left child (0-indexed)
        if (j + 1 < n && a[j + 1] > a[j]) j++; // pick larger child
        if (a[i] >= a[j]) break;
        (a[i], a[j]) = (a[j], a[i]);
        i = j;
    }
}

// ============================================================
// Shared helper: Insertion Sort for small subarrays
// ============================================================

void InsertionSort(int[] list, int low, int high)
{
    for (int i = low; i <= high; i++)
        for (int j = i; j > low && list[j] < list[j - 1]; j--)
            (list[j], list[j - 1]) = (list[j - 1], list[j]);
}

// --- Demo ---
void PrintSort(string name, Action<int[]> sortFn, int[] source)
{
    int[] arr = (int[])source.Clone();
    sortFn(arr);
    Console.WriteLine($"{name,-22}: {string.Join(" ", arr)}");
}

int[] data = { 38, 27, 43, 3, 9, 82, 10, 27, 3, 50 };
Console.WriteLine($"{"Original",-22}: {string.Join(" ", data)}\n");

PrintSort("Merge Sort", MergeSort, data);
PrintSort("BU Merge Sort", BottomUpMergeSort, data);
PrintSort("Quick Sort", QuickSort, data);
PrintSort("3-Way Quick Sort", ThreeWayQuickSort, data);
PrintSort("Heap Sort", HeapSort, data);

// Quick Select
int[] selectArr = (int[])data.Clone();
int k = 3;
int kth = QuickSelect(selectArr, k);
Console.WriteLine($"\n{k}th smallest (0-indexed): {kth}");
