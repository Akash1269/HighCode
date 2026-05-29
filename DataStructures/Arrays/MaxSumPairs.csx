// Question - 
// You are given an integer array nums and an integer k. 
// In one operation, you can pick two numbers from the array whose sum equals k and remove them from the array.
// Return the maximum number of operations you can perform on the array.

// #hashmap #twoPointer #sort

// Simple brute force, two loops find all pairs, make removed as 0 to avoid reusing numbers
// Space - O(1), Time - O(n2) 
public int MaxOperations1(int[] nums, int k)
{
    int maxCount = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0) continue;

        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[j] != 0 && k == nums[i] + nums[j])
            {
                maxCount++;
                nums[i] = 0;
                nums[j] = 0;
                break;
            }
        }
    }

    return maxCount;
}

// Space - O(n), Time - O(n) 
// Use has map in single loop to save seen numbers and its count, and find pair for each number in the map
public int MaxOperations2(int[] nums, int k)
{
    var map = new Dictionary<int, int>();
    int remains = 0;
    int maxCount = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        remains = k - nums[i];

        if (map.ContainsKey(remains) && map[remains] >= 1)
        {
            map[remains]--;
            maxCount++;
        }
        else if (map.ContainsKey(nums[i])) map[nums[i]]++;
        else  map[nums[i]] = 1;
    }

    return maxCount;
}

// Sort first and then find pairs from both ends
// Space - O(1), Time - O(n logn) 
public int MaxOperations(int[] nums, int k)
{
    int maxCount = 0;
    int start = 0, end = nums.Length - 1;

    Array.Sort(nums);

    while (start < end)
    {
        int total = nums[start] + nums[end];

        if (total < k) start++;
        else if (total > k) end--;
        else
        {
            maxCount++;
            start++;
            end--;
        }
    }

    return maxCount;
}