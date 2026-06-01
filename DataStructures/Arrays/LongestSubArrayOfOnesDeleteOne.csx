// Question - 
// Given a binary array nums, you should delete one element from it.
// Return the size of the longest non-empty subarray containing only 1's in the resulting array. Return 0 if there is no such subarray.

// #slidingWindow

// Simple Intuitive solution, consider one 0 to be deleted in longest subarray
// if already considered then remove from start till found 0
public int LongestSubarray(int[] nums)
{
    int start = 0, count = 0, maxCount = 0;
    bool isDeleted = false;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 1) count++;
        else if (!isDeleted) isDeleted = true;
        else
        {
            while (nums[start] == 1)
            {
                start++;
                count--;
            }
            start++;
        }

        maxCount = Math.Max(count, maxCount);
    }

    if (!isDeleted) maxCount--;

    return maxCount;
}

// Lil different approach, but similar mindset
public int LongestSubarray2(int[] nums)
{
    int start = 0, zeros = 0, maxCount = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0) zeros++;

        while (zeros > 1)
        {
            if (nums[start] == 0) zeros--;
            start++;
        }

        maxCount = Math.Max(maxCount, i - start);
    }

    return maxCount;
}