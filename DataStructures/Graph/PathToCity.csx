// You're given a tree where every edge has a direction. Find the minimum number of edges to reverse so that every node has a path leading to node 0.

// #dfs #tree

// Solution 1 - Store the direction which is present and add direction which is not present, 
// and try to reach to the end from 0 th node in all directions. Add 1 for each node which was not present
int count = 0;
public int MinReorder(int n, int[][] connections)
{
    List<(int, int)>[] graph = new List<(int, int)>[n];
    bool[] visited = new bool[n];

    for (int i = 0; i < n; i++)
    {
        graph[i] = new List<(int, int)>();
    }

    foreach (int[] connection in connections)
    {
        int u = connection[0];
        int v = connection[1];

        graph[u].Add((v, 1));
        graph[v].Add((u, 0));
    }

    visited[0] = true;
    DFS(graph, 0, visited);
    // PrintGraph(graph);

    return count;
}

public void DFS(List<(int, int)>[] graph, int node, bool[] visited)
{
    foreach (var (neighbour, dir) in graph[node])
    {
        if (!visited[neighbour])
        {
            count += dir;
            visited[neighbour] = true;
            DFS(graph, neighbour, visited);
        }
    }

    return;
}