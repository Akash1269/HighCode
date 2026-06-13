// Solution 2: BFS Iterative Solution
public int FindCircleNum(int[][] isConnected)
{
    var visited = new bool[isConnected.Length];

    int provinces = 0;
    for (int i = 0; i < isConnected.Length; i++)
    {
        if (!visited[i])
        {
            VisitBFS(isConnected, i, visited);
            provinces++;
        }
    }

    return provinces;
}

public void VisitBFS(int[][] isConnected, int cityIndex, bool[] visited)
{
    visited[cityIndex] = true;

    var queue = new Queue<int>();
    queue.Enqueue(cityIndex);

    while (queue.Count > 0)
    {
        int city = queue.Dequeue();

        for (int i = 0; i < isConnected[city].Length; i++)
        {
            int connect = isConnected[city][i];

            if (!visited[i] && connect == 1)
            {
                queue.Enqueue(i);
                visited[i] = true;
            }
        }
    }
}


// Solution 1: DFS Recursive solution
public int FindCircleNum2(int[][] isConnected)
{
    var visited = new bool[isConnected.Length];

    int provinces = 0;
    for (int i = 0; i < isConnected.Length; i++)
    {
        if (!visited[i])
        {
            Visit(isConnected, i, visited);
            provinces++;
        }
    }

    return provinces;
}

public void Visit(int[][] isConnected, int cityIndex, bool[] visited)
{
    visited[cityIndex] = true;

    for (int i = 0; i < isConnected[cityIndex].Length; i++)
    {
        int connect = isConnected[cityIndex][i];

        if (!visited[i] && connect == 1)
        {
            Visit(isConnected, i, visited);
        }
    }
}