// Graph Implementation using Adjacency Matrix
// ------------------------
// #graph
//
// Public Functions:
//   Constructor & Basic Operations:
//   - GraphMatrix(n, edges)         : Build n×n matrix from edge list
//   - GraphMatrix(n)                : Build empty n×n matrix (no edges)
//   - AddEdge(v1, v2)               : Add undirected edge between two nodes
//   - RemoveEdge(v1, v2)            : Remove edge between two nodes
//   - IsEdge(v1, v2)                : Check if edge exists — O(1)
//   - GetNeighbours(v)              : Get all adjacent nodes as List<int>
//   - GetDegree(v)                  : Count of edges for a node
//
//   Traversals:
//   - DFS()                         : Depth-first traversal of all nodes (handles disconnected)
//   - DFSFromNode(node)             : DFS starting from a specific node
//   - BFS()                         : Breadth-first traversal of all nodes (handles disconnected)
//   - BFSFromNode(node)             : BFS starting from a specific node
//
//   Path & Connectivity:
//   - HasPath(v1, v2)               : Check if path exists between two nodes
//   - CountConnectedComponents()    : Count disconnected components
//   - IsConnected()                 : Check if entire graph is one component
//
//   Properties:
//   - NodeCount()                   : Return number of nodes
//   - EdgeCount()                   : Return number of edges (undirected)
//
//   Display:
//   - Print()                       : Display raw matrix
//   - PrintPretty()                 : Display matrix with row/column labels
//
// Private Helpers:
//   - DFSVisit(current, visited, result)  : Recursive DFS helper
//   - BFSVisit(current, visited, result)  : Iterative BFS helper using queue
//   - DFSFind(current, find, visited)     : DFS reachability helper
//   - BFSFind(current, find, visited)     : BFS reachability helper

// Using adjacency matrix - rarely used but mostly for dense graphs
class GraphMatrix
{
    public int[][] matrix;
    public int n;

    public GraphMatrix(int _n, int[][] edges)
    {
        n = _n;
        matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        foreach (int[] edge in edges)
        {
            int row = edge[0], col = edge[1];
            matrix[row][col] = 1;
            matrix[col][row] = 1; // Only for undirected graphs
        }
    }

    public GraphMatrix(int _n)
    {
        n = _n;
        matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }
    }

    public void AddEdge(int v1, int v2)
    {
        matrix[v1][v2] = 1;
        matrix[v2][v1] = 1; // Set both for undirected
    }

    public void RemoveEdge(int v1, int v2)
    {
        matrix[v1][v2] = 0;
        matrix[v2][v1] = 0; // Set both for undirected
    }

    public bool IsEdge(int v1, int v2)
    {
        return matrix[v1][v2] == 1;
    }

    public List<int> GetNeighbours(int v)
    {
        var list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (matrix[v][i] == 1)
                list.Add(i);
        }

        return list;
    }

    public int GetDegree(int v)
    {
        var degree = 0;
        for (int i = 0; i < n; i++)
        {
            if (matrix[v][i] == 1)
                degree++;
        }

        return degree;
    }

    public List<int> DFS()
    {
        var result = new List<int>();
        bool[] visited = new bool[n];

        for (int start = 0; start < n; start++)
        {
            if (!visited[start])
                DFSVisit(start, visited, result);
        }

        Console.WriteLine("DFS all: " + string.Join(" → ", result));
        return result;
    }

    public List<int> DFSFromNode(int node)
    {
        var result = new List<int>();
        bool[] visited = new bool[n];
        DFSVisit(node, visited, result);

        Console.WriteLine("DFS from {0}: " + string.Join(" → ", result), node);
        return result;
    }

    private void DFSVisit(int current, bool[] visited, List<int> result)
    {
        visited[current] = true;
        result.Add(current);

        for (int neighbor = 0; neighbor < n; neighbor++)
        {
            if (!visited[neighbor] && matrix[current][neighbor] == 1)
                DFSVisit(neighbor, visited, result);
        }
    }

    public List<int> BFS()
    {
        var result = new List<int>();
        bool[] visited = new bool[n];

        for (int start = 0; start < n; start++)
        {
            if (!visited[start])
                BFSVisit(start, visited, result);
        }

        Console.WriteLine("BFS all: " + string.Join(" → ", result));
        return result;
    }

    public List<int> BFSFromNode(int node)
    {
        var result = new List<int>();
        bool[] visited = new bool[n];
        BFSVisit(node, visited, result);

        Console.WriteLine("BFS from {0}: " + string.Join(" → ", result), node);
        return result;
    }

    private void BFSVisit(int current, bool[] visited, List<int> result)
    {
        Queue<int> q = new Queue<int>();
        if (!visited[current])
        {
            q.Enqueue(current);
            visited[current] = true;
        }

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            result.Add(node);

            for (int neighbor = 0; neighbor < n; neighbor++)
            {
                if (!visited[neighbor] && matrix[node][neighbor] == 1)
                {
                    q.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
        }
    }

    private bool DFSFind(int current, int find, bool[] visited)
    {
        if (current == find) return true;

        visited[current] = true;

        for (int neighbor = 0; neighbor < n; neighbor++)
        {
            if (!visited[neighbor] && matrix[current][neighbor] == 1)
            {
                bool found = DFSFind(neighbor, find, visited);
                if (found) 
                    return true;
            }
        }

        return false;
    }

    private bool BFSFind(int current, int find, bool[] visited)
    {
        Queue<int> q = new Queue<int>();
        
        if (!visited[current])
        {
            q.Enqueue(current);
            visited[current] = true;
        }

        while (q.Count > 0)
        {
            int node = q.Dequeue();
            if(node == find) return true;

            for (int neighbor = 0; neighbor < n; neighbor++)
            {
                if (!visited[neighbor] && matrix[node][neighbor] == 1)
                {
                    q.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
        }

        return false;
    }

    public bool HasPath(int v1, int v2)
    {
        bool[] visited = new bool[n];
        
        // return DFSFind(v1, v2, visited);

        return BFSFind(v1, v2, visited);
    }

    public int CountConnectedComponents() {
        bool[] visited = new bool[n];
        int count = 0;

        for (int start = 0; start < n; start++)
        {
            if (!visited[start]) {
                DFSVisit(start, visited, new List<int>());
                count++;
            }
        }

        return count;
    }

    public bool IsConnected() {
        return CountConnectedComponents() == 1;
    }

    public int NodeCount() {
        return n;
    }

    public int EdgeCount() {
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(matrix[i][j] == 1)
                    count++;
            }
        }

        return count / 2; // Each undirected edge is stored twice
    }

    public void Print()
    {
        Console.WriteLine("Here's your graph - ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i][j] + "-");
            }
        }
        Console.WriteLine();
    }

    public void PrintPretty()
    {
        // Header row
        Console.Write("  |");
        for (int i = 0; i < n; i++)
            Console.Write(" " + i);
        Console.WriteLine();

        // Separator
        Console.Write("--+");
        Console.WriteLine(new string('-', n * 2));

        // Data rows
        for (int i = 0; i < n; i++)
        {
            Console.Write(i + " |");
            for (int j = 0; j < n; j++)
            {
                Console.Write(" " + matrix[i][j]);
            }
            Console.WriteLine();
        }
    }
}

// Includes all utility and test code for graph matrix
public void ManageGraphMatrix()
{
    int n = 5;
    int[][] edges = new int[][] { [0, 1], [0, 4], [1, 3], [4, 3] };
    var graph = new GraphMatrix(n, edges);

    // graph.Print();
    graph.PrintPretty();

    // Console.WriteLine("No of Nodes - {0}", graph.NodeCount());
    // Console.WriteLine("No of Edges - {0}", graph.EdgeCount());

    // ------ Test Connections
    // graph.AddEdge(2, 3);
    // graph.RemoveEdge(0, 1);
    // graph.RemoveEdge(0, 4);
    // graph.RemoveEdge(3, 1);
    // int components = graph.CountConnectedComponents();
    // Console.WriteLine("Components - {0}", components);
    // Console.WriteLine("Is Connected - {0}", graph.IsConnected());

    // ------- Test Path
    // bool hasPath = false;
    // hasPath = graph.HasPath(1, 0);
    // Console.WriteLine("Has Path - {0}", hasPath);
    // hasPath = graph.HasPath(1, 4);
    // Console.WriteLine("Has Path - {0}", hasPath);

    // hasPath = graph.HasPath(1, 0);
    // Console.WriteLine("Has Path - {0}", hasPath);
    // hasPath = graph.HasPath(1, 4);
    // Console.WriteLine("Has Path - {0}", hasPath);

    // ----- Test Traversal
    graph.BFS();
    // graph.BFSFromNode(1);
    // graph.BFSFromNode(2);

    graph.DFS();
    // graph.DFSFromNode(2);
    // graph.DFSFromNode(4);
    // graph.DFSFromNode(3);

    // ---- Test Modifications and basic functions
    // graph.AddEdge(2, 3);
    // graph.Print();

    // bool val = graph.IsEdge(2, 3);
    // Console.WriteLine(val);
    // val = graph.IsEdge(3, 4);
    // Console.WriteLine(val);
    // val = graph.IsEdge(1, 4);
    // Console.WriteLine(val);

    // var list = graph.GetNeighbours(3);
    // Console.WriteLine("Neighbours for {0} - {1}", 3, string.Join(", ", list));

    // var degree = graph.GetDegree(3);
    // Console.WriteLine("Degree for {0} - {1}", 3, degree);

    // graph.RemoveEdge(1, 3);
    // graph.Print();
}

ManageGraphMatrix();