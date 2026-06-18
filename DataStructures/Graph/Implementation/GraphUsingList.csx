// Graph Implementation using Adjacency List (Node-based)
// ------------------------
// #graph
// Note: In this implementation, node data == node index (id).
//       All search/path APIs use node index/id values in range 0..n-1.
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
//   Path & Connectivity:
//   - HasPath(u, v)                 : Check if any path exists between two nodes
//   - IsConnected()                 : True if the whole graph is one component
//   - CountConnectedComponents()    : Number of connected components
//
//   Properties:
//   - NodesCount()                  : Number of nodes in the graph
//   - EdgeCount()                   : Number of edges (undirected edges counted twice in current implementation)
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
        Initialize(_n);
    }

    public GraphList(int _n, int[][] edges)
    {
        Initialize(_n);
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
        foreach (var neighbor in nodes[v].neighbors)
        {
            result.Add(neighbor.data);
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

        foreach (Node neighbor in current.neighbors)
        {
            if (!visited[neighbor.data])
                DFSVisit(neighbor, visited, result);
        }
    }

    private bool DFSFind(int u, int v, bool[] visited)
    {
        Node node = nodes[u];
        visited[node.data] = true;
        if (node.data == v) return true;

        foreach (Node neighbor in node.neighbors)
        {
            if (!visited[neighbor.data])
            {
                bool found = DFSFind(neighbor.data, v, visited);
                if (found) return true;
            }
        }

        return false;
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

    private bool BFSFind(int u, int v, bool[] visited)
    {
        Queue<Node> queue = new Queue<Node>();
        Node node = nodes[u];
        queue.Enqueue(node);
        visited[node.data] = true;

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            if (current.data == nodes[v].data) return true;

            foreach (Node neighbor in current.neighbors)
            {
                if (!visited[neighbor.data])
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor.data] = true;
                }
            }
        }

        return false;
    }

    public bool HasPath(int u, int v)
    {
        bool[] visited = new bool[n];
        return BFSFind(u, v, visited);
        // return DFSFind(u, v, visited);
    }

    public bool IsConnected()
    {
        return CountConnectedComponents() == 1;
    }

    public int CountConnectedComponents()
    {
        bool[] visited = new bool[n];
        var result = new List<int>();
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            Node node = nodes[i];
            if (!visited[node.data])
            {
                DFSVisit(node, visited, result);
                count++;
            }
        }

        return count;
    }

    public int NodeCount()
    {
        return n;
    }

    public int EdgeCount()
    {
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            Node node = nodes[i];
            count += node.neighbors.Count;
        }

        // divide by 2 for undirected graph
        return count / 2;
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

    // Console.WriteLine("Nodes count - {0}", graph.NodeCount());
    // Console.WriteLine("Edges count - {0}", graph.EdgeCount());

    bool hasPath;
    hasPath = graph.HasPath(0, 4);
    Console.WriteLine("Has Path ? 0 to 4 - {0}", hasPath);
    hasPath = graph.HasPath(2, 3);
    Console.WriteLine("Has Path ? 2 to 3 - {0}", hasPath);
    hasPath = graph.HasPath(1, 3);
    Console.WriteLine("Has Path ? 1 to 3 - {0}", hasPath);

    // Console.WriteLine("Is Connected - {0}", graph.IsConnected());
    // Console.WriteLine("No of Connected components - {0}", graph.CountConnectedComponents());

    // graph.AddEdge(2, 1);

    // Console.WriteLine("Is Connected - {0}", graph.IsConnected());
    // Console.WriteLine("No of Connected components - {0}", graph.CountConnectedComponents());

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

    // graph.RemoveEdge(4, 3);
    // graph.AddEdge(2, 1);
    // graph.Print();

    // Console.WriteLine("Degree of Node - {0}", graph.GetDegree(1));

    // list = graph.GetNeighbours(2);
    // Console.WriteLine("Neighbors of Node - {0}", string.Join(", ", list));

    // graph.Print();
    // graph.RemoveEdge(4, 0);
}

ManageGraphList();