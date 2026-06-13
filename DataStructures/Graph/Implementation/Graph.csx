class Node
{
    public int data { get; set; }
    public List<Node> adjecents { get; set; }

    public Node(int j)
    {
        data = j;
        adjecents = new List<Node>();
    }

}

//un-directed graph
class Graph
{
    private const int SIZE = 10;
    private Node[] nodes;

    private static bool[] visited;

    public Graph()
    {
        nodes = new Node[SIZE];
        visited = new bool[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            nodes[i] = new Node(i);
        }
    }


    public void AddEdge(int i, int j)
    {
        if (i < SIZE && !IsEdge(i, j))
        {
            nodes[i].adjecents.Add(nodes[j]);
            nodes[j].adjecents.Add(nodes[i]);
        }
    }

    public bool IsEdge(int i, int j)
    {
        if (i == j)
            return true;
        foreach (Node item in nodes[i].adjecents)
        {
            if (item.data == j)
                return true;
        }
        return false;
    }

    public void DFS()
    {
        for (int i = 0; i < visited.Length; i++)
        {
            visited[i] = false;
        }
        foreach (Node item in nodes)
        {
            if (!visited[item.data])
            {
                _DFS(item);
            }
        }
    }

    private void _DFS(Node v)
    {
        Visit(v);
        visited[v.data] = true;
        foreach (Node item in v.adjecents)
        {
            if (!visited[item.data])
                _DFS(item);
        }
    }

    private void Visit(Node node)
    {
        Console.Write(" " + node.data);
    }

    public void BFS()
    {
        Queue<Node> queue = new Queue<Node>();
        for (int i = 0; i < SIZE; i++)
        {
            visited[i] = false;
        }

        foreach (Node item in nodes)
        {
            if (!visited[item.data])
            {
                queue.Enqueue(item);
                visited[item.data] = true;
                while (queue.Count > 0)
                {
                    Node v = queue.Dequeue();
                    Visit(v);
                    foreach (Node node in v.adjecents)
                    {
                        if (!visited[node.data])
                        {
                            queue.Enqueue(node);
                            visited[node.data] = true;
                        }

                    }
                }
            }
        }
    }
}