// Question - 
// Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj) such that row ri and column cj are equal.
// A row and column pair is considered equal if they contain the same elements in the same order (i.e., an equal array).

// #matrix 

// Simple solution, to make comparison easy transpose and compare inner arrays with each other all rows and columns
public int EqualPairs(int[][] grid)
{
    int n = grid.Length;
    int count = 0;
    var crossGrid = new int[n][];

    // Create transpose matrix, so its easy to compare arrays directly, instead of cris corssing
    // See this in example how its stored - [[3,2,1],[1,7,6],[2,7,7]] , transpose would be - [[3,1,2],[2,7,7],[1,6,7]]

    for (int col = 0; col < n; col++)
    {
        crossGrid[col] = new int[n];

        for (int row = 0; row < n; row++)
        {
            crossGrid[col][row] = grid[row][col];
        }
    }

    // Compare arrays directly for row and col all combinations, n * n * n
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (grid[i].SequenceEqual(crossGrid[j])) count++;
        }
    }

    return count;
}

// Save space, it compares in place for row to column, both are still o(n3)
public int EqualPairs(int[][] grid)
{

    int n = grid.Length;
    int count = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (IsRowColEqual(grid, i, j))
                count++;
        }
    }

    return count;
}

public bool IsRowColEqual(int[][] grid, int row, int col)
{
    for (int i = 0; i < grid.Length; i++)
    {
        if (grid[row][i] != grid[i][col])
            return false;
    }
    return true;
}

// Using hashmap to store key of each col and row to reduce from O(n3) to O(n2)
public int EqualPairs(int[][] grid)
{

    int n = grid.Length;
    int count = 0;
    var map = new Dictionary<string, int>();

    // Create map of rows with count;
    for (int row = 0; row < n; row++)
    {
        string sRow = string.Join('-', grid[row]);
        map[sRow] = map.ContainsKey(sRow) ? map[sRow] + 1 : 1;
    }

    for (int col = 0; col < n; col++)
    {
        var column = new int[n];
        var isEqual = true;

        for (int row = 0; row < n; row++)
        {
            column[row] = grid[row][col];
        }

        var sCol = string.Join('-', column);

        // Check if contains and add count, from prev, cant remove as some othe col might also have same combo and can be matched
        if (map.ContainsKey(sCol) && map[sCol] > 0)
        {
            count += map[sCol];
        }
    }

    return count;
}