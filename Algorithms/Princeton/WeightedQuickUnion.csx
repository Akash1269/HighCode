// Question - Union Find: Weighted Quick Union with Path Compression
// #union-find #tree #path-compression #princeton

// Weighted Quick Union with Path Compression
// Keeps trees balanced by always attaching smaller tree under larger
// Path compression flattens tree during Root() — nearly O(1) amortized (O(log* n))
// Best union-find approach from the course

class UnionFind
{
    public int[] Parent;
    public int[] Size;

    public UnionFind(int n)
    {
        Parent = new int[n];
        Size = new int[n];
        for (int i = 0; i < n; i++)
        {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    // Two-pass path compression:
    // Pass 1: halving (set[i] = set[set[i]]) during traversal
    // Pass 2: point all nodes directly to root
    public int Root(int i)
    {
        int j = i;
        while (Parent[i] != i)
        {
            Parent[i] = Parent[Parent[i]]; // path halving
            i = Parent[i];
        }
        // full path compression — point everything to root
        while (Parent[j] != i)
        {
            int next = Parent[j];
            Parent[j] = i;
            j = next;
        }
        return i;
    }

    // Weighted union: attach smaller tree under larger tree's root
    public void Union(int p, int q)
    {
        int pRoot = Root(p);
        int qRoot = Root(q);
        if (pRoot == qRoot) return;

        if (Size[pRoot] < Size[qRoot])
        {
            Parent[pRoot] = qRoot;
            Size[qRoot] += Size[pRoot];
        }
        else
        {
            Parent[qRoot] = pRoot;
            Size[pRoot] += Size[qRoot];
        }
    }

    public bool Find(int p, int q) => Root(p) == Root(q);

    public void Print() => Console.WriteLine(string.Join(" ", Parent));
}

// --- Demo ---
Console.WriteLine("=== Weighted Quick Union + Path Compression ===\n");

var uf = new UnionFind(10);
uf.Print();

uf.Union(3, 4); Console.Write("Union(3,4): "); uf.Print();
uf.Union(4, 9); Console.Write("Union(4,9): "); uf.Print();
uf.Union(8, 0); Console.Write("Union(8,0): "); uf.Print();
uf.Union(2, 3); Console.Write("Union(2,3): "); uf.Print();
uf.Union(5, 6); Console.Write("Union(5,6): "); uf.Print();
uf.Union(0, 2); Console.Write("Union(0,2): "); uf.Print();

Console.WriteLine($"\nFind(3,9): {uf.Find(3, 9)}");  // true
Console.WriteLine($"Find(8,9): {uf.Find(8, 9)}");    // true
Console.WriteLine($"Find(0,7): {uf.Find(0, 7)}");    // false
