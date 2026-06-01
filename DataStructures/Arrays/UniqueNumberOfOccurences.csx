// Question - 
// Given an array of integers arr, return true if the number of occurrences of each value in the array is unique or false otherwise.

// #HashMap

// Simple and intuitive, some short forms help
public bool UniqueOccurrences(int[] arr)
{
    var map = new Dictionary<int, int>();

    foreach (int x in arr)
    {
        map[x] = map.ContainsKey(x) ? map[x] + 1 : 1;
    }

    var set = new HashSet<int>();

    foreach (int count in map.Values)
    {
        if (set.Contains(count)) return false;
        else set.Add(count);
    }

    return true;
}