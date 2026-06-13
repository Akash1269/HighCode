// Question - There are n rooms labeled from 0 to n - 1 and all the rooms are locked except for room 0. 
// Your goal is to visit all the rooms. However, you cannot enter a locked room without having its key.
// Given an array rooms where rooms[i] is the set of keys that you can obtain if you visited room i, return true if you can visit all the rooms, or false otherwise.

// #graph #dfs

// Solution 1: Recursive, DFS
public bool CanVisitAllRooms(IList<IList<int>> rooms)
{
    var visited = new bool[rooms.Count];
    Visit(rooms, 0, visited);

    foreach (var visit in visited)
    {
        if (!visit) return false;
    }

    return true;
}

public void Visit(IList<IList<int>> rooms, int roomIndex, bool[] visited)
{
    visited[roomIndex] = true;

    foreach (var roomKey in rooms[roomIndex])
    {
        if (!visited[roomKey])
            Visit(rooms, roomKey, visited);
    }
}