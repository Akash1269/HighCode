// Question - 
// Given an integer array nums, return true if there exists a triple of indices (i, j, k) 
// such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.

// #subSequence

// Most brute force, simple - O(n3)
public bool IncreasingTriplet(int[] nums)
{
    int n = nums.Length;

    for (int i = 0; i < n; i++)
    {
        for (int j = i; j < n; j++)
        {
            if (nums[i] < nums[j])
            {
                for (int k = j; k < n; k++)
                {
                    if (nums[j] < nums[k])
                    {
                        return true;
                    }
                }
            }
        }
    }

    return false;
}

// Brute force but recursive - O(n3), but takes more space due to call stack
public bool IncreasingTriplet(int[] nums)
{
    int[] table = new int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
        int length = IncreasingSubLength(nums, i, table);

        if (length >= 3) return true;
    }
    return false;
}

private int IncreasingSubLength(int[] nums, int start, int[] table)
{
    int max = 0;

    for (int i = start + 1; i < nums.Length; i++)
    {
        if (nums[i] > nums[start])
        {
            if (table[i] == 0) table[i] = IncreasingSubLength(nums, i, table);
            max = Math.Max(max, table[i]);
        }

        if (max >= 2) break;
    }
    return 1 + max;
}

// O(n), Not so intuitive, store two numbers one greater than another, 
// if third greater number than both found then you have triplet
public bool IncreasingTriplet(int[] nums)
{
    int firstMax = int.MaxValue;
    int secondMax = int.MaxValue;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] <= firstMax)
        {
            firstMax = nums[i];
        }
        else if (nums[i] <= secondMax)
        {
            secondMax = nums[i];
        }
        else
        {
            return true;
        }
    }

    return false;
}