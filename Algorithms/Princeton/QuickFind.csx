// Question - Union Find: Quick Find (Eager Approach)
// #union-find #array #princeton

// Quick Find: Array-based eager union-find
// Find is O(1) — just compare array values
// Union is O(n) — must update all entries with matching root
// Too slow for large inputs (n union ops on n objects = O(n²))

void Union(int[] set, int p, int q)
{
    int pRoot = set[p];
    int qRoot = set[q];
    for (int i = 0; i < set.Length; i++)
    {
        if (set[i] == pRoot)
            set[i] = qRoot;
    }
}

bool Find(int[] set, int p, int q) => set[p] == set[q];

void Print(int[] arr) => Console.WriteLine(string.Join(" ", arr));

// --- Demo ---
int n = 10;
int[] set = new int[n];
for (int i = 0; i < n; i++) set[i] = i;

Console.WriteLine("=== Quick Find (Eager) ===\n");
Print(set);

Union(set, 3, 4); Console.Write("Union(3,4): "); Print(set);
Union(set, 4, 9); Console.Write("Union(4,9): "); Print(set);
Union(set, 8, 0); Console.Write("Union(8,0): "); Print(set);
Union(set, 2, 3); Console.Write("Union(2,3): "); Print(set);
Union(set, 5, 6); Console.Write("Union(5,6): "); Print(set);

Console.WriteLine($"\nFind(3,9): {Find(set, 3, 9)}");  // true
Console.WriteLine($"Find(0,7): {Find(set, 0, 7)}");    // false
