// Question - Union Find: Quick Union (Lazy Approach)
// #union-find #tree #princeton

// Quick Union: Tree-based lazy union-find
// Array represents forest of trees — set[i] is parent of i
// Root is where set[i] == i
// Union is O(n) worst case — trees can get tall
// Find is O(n) worst case — must chase root

int Root(int[] set, int i)
{
    while (set[i] != i)
        i = set[i];
    return i;
}

void Union(int[] set, int p, int q)
{
    int pRoot = Root(set, p);
    int qRoot = Root(set, q);
    set[pRoot] = qRoot;
}

bool Find(int[] set, int p, int q) => Root(set, p) == Root(set, q);

void Print(int[] arr) => Console.WriteLine(string.Join(" ", arr));

// --- Demo ---
int n = 10;
int[] set = new int[n];
for (int i = 0; i < n; i++) set[i] = i;

Console.WriteLine("=== Quick Union (Lazy) ===\n");
Print(set);

Union(set, 3, 4); Console.Write("Union(3,4): "); Print(set);
Union(set, 4, 9); Console.Write("Union(4,9): "); Print(set);
Union(set, 8, 0); Console.Write("Union(8,0): "); Print(set);
Union(set, 2, 3); Console.Write("Union(2,3): "); Print(set);
Union(set, 5, 6); Console.Write("Union(5,6): "); Print(set);

Console.WriteLine($"\nFind(3,9): {Find(set, 3, 9)}");  // true
Console.WriteLine($"Find(0,7): {Find(set, 0, 7)}");    // false
