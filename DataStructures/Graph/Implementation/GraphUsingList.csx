// Graph Implementation using Adjacency List (Node-based)
// ------------------------
// #graph
//
// Public Functions:
//   Constructors:
//   - GraphList(n)                  : Build empty graph with n nodes
//   - GraphList(n, edges)           : Build graph with n nodes from edge list
//
//   Basic Operations:
//   - AddEdge(u, v)                 : Add undirected edge between two nodes
//   - RemoveEdge(u, v)              : Remove edge between two nodes
//   - IsEdge(u, v)                  : Check if edge exists between two nodes
//   - GetNeighbours(v)              : Get all adjacent node values as List<int>
//   - GetDegree(v)                  : Count of edges for a node — O(1)
//
//   Traversals:
//   - DFS()                         : Depth-first traversal of all nodes (handles disconnected)
//   - DFSFromNode(v)                : DFS starting from node with value v
//   - BFS()                         : Breadth-first traversal of all nodes (handles disconnected)
//   - BFSFromNode(v)                : BFS starting from node with value v
//
//   Display:
//   - Print()                       : Print each node with its neighbor list
//
// Private Helpers:
//   - Initialize(n)                 : Shared setup for constructors
//   - DFSVisit(current, visited, result) : Recursive DFS helper
//   - BFSVisit(current, visited, result) : Iterative BFS helper using queue

// Graph using Adjacency list
class Node
{
    public int data { get; set; }
    public List<Node> neighbors { get; set; }

    public Node(int _data)
    {
        data = _data;
        neighbors = new List<Node>();
    }
}

//un-directed graph
class GraphList
{
    public int n;
    public Node[] nodes;

    public GraphList(int _n)
    {
        Intialize(_n);
    }

    public GraphList(int _n, int[][] edges)
    {
        Intialize(_n);
        for (int i = 0; i < edges.Length; i++)
        {
            AddEdge(edges[i][0], edges[i][1]);
        }
    }

    public void Initialize(int _n)
    {
        n = _n;
        nodes = new Node[n];

        for (int i = 0; i < n; i++)
        {
            nodes[i] = new Node(i);
        }
    }

    public void AddEdge(int u, int v)
    {
        if (u >= n || v >= n || IsEdge(u, v) || IsEdge(v, u)) return;

        nodes[u].neighbors.Add(nodes[v]);
        nodes[v].neighbors.Add(nodes[u]);
    }

    public void RemoveEdge(int u, int v)
    {
        if (u >= n || v >= n) return;

        nodes[u].neighbors.Remove(nodes[v]);
        nodes[v].neighbors.Remove(nodes[u]);
    }

    public bool IsEdge(int u, int v)
    {
        foreach (Node neighbor in nodes[u].neighbors)
        {
            if (neighbor.data == v)
                return true;
        }
        return false;
    }

    public List<int> GetNeighbours(int v)
    {
        if (v >= n) return new List<int>();

        List<int> result = new List<int>();
        foreach (var neigbor in nodes[v].neighbors)
        {
            result.Add(neigbor.data);
        }

        return result;
    }

    public int GetDegree(int v)
    {
        if (v >= n) return 0;

        return nodes[v].neighbors.Count;
    }

    public List<int> DFS()
    {
        bool[] visited = new bool[n];
        var result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            Node node = nodes[i];
            if (!visited[node.data])
            {
                DFSVisit(node, visited, result);
            }
        }

        return result;
    }

    public List<int> DFSFromNode(int v)
    {
        bool[] visited = new bool[n];
        var result = new List<int>();

        DFSVisit(nodes[v], visited, result);

        return result;
    }

    private void DFSVisit(Node current, bool[] visited, List<int> result)
    {
        visited[current.data] = true;
        result.Add(current.data);

        foreach (Node neigbor in current.neighbors)
        {
            if (!visited[neigbor.data])
                DFSVisit(neigbor, visited, result);
        }
    }

    public List<int> BFS()
    {
        bool[] visited = new bool[n];
        List<int> result = new List<int>();

        foreach (Node current in nodes)
        {
            if (!visited[current.data])
            {
                BFSVisit(current, visited, result);
            }
        }

        return result;
    }

    public List<int> BFSFromNode(int v)
    {
        bool[] visited = new bool[n];
        List<int> result = new List<int>();

        BFSVisit(nodes[v], visited, result);

        return result;
    }

    private void BFSVisit(Node current, bool[] visited, List<int> result)
    {
        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(current);
        visited[current.data] = true;

        while (queue.Count > 0)
        {
            Node v = queue.Dequeue();
            result.Add(v.data);

            foreach (Node neighbor in v.neighbors)
            {
                if (!visited[neighbor.data])
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor.data] = true;
                }

            }
        }
    }

    public void Print()
    {
        Console.WriteLine("Printing Graph");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Node " + nodes[i].data + " -> ");
            foreach (var neighbor in nodes[i].neighbors)
            {
                Console.Write(neighbor.data + " - ");
            }

            Console.WriteLine();
        }
    }
}

public void ManageGraphList()
{
    int n = 5;
    int[][] edges = new int[][] { [0, 1], [0, 4], [1, 3], [4, 3] };
    var graph = new GraphList(n, edges);

    graph.Print();
    List<int> list;
    // list = graph.DFS();
    // Console.WriteLine("DFS - {0}", string.Join(", ", list));

    // list = graph.DFSFromNode(0);
    // Console.WriteLine("DFS From Node - {0}", string.Join(", ", list));

    // list = graph.BFS();
    // Console.WriteLine("BFS All - {0}", string.Join(", ", list));

    // list = graph.BFSFromNode(0);
    // Console.WriteLine("BFS From Node - {0}", string.Join(", ", list));

    graph.RemoveEdge(4, 3);
    graph.AddEdge(2, 1);
    graph.Print();

    Console.WriteLine("Degree of Node - {0}", graph.GetDegree(1));

    list = graph.GetNeighbours(2);
    Console.WriteLine("Neighbors of Node - {0}", string.Join(", ", list));

    // graph.Print();
    // graph.RemoveEdge(4, 0);
}

ManageGraphList();