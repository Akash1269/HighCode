// Question - 
// Given a binary array nums and an integer k, return the maximum number of consecutive 1's in the array if you can flip at most k 0's.
// #slidingWindow

// Intuitive, Single pass, max 2n operations for moving start and end
public int LongestOnes(int[] nums, int k)
{
    int start = 0, count = 0, maxCount = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        // if 1 then increase count, if 0 then check remaining 0s > k to be flipped
        if (nums[i] == 1)
        {
            count++;
        }
        else if (k > 0)
        {
            count++;
            k--;
        }
        // k flips exhausted, count max length and change window start
        else if (k == 0)
        {
            maxCount = Math.Max(count, maxCount);

            while (nums[start] == 1 && start < nums.Length)
            {
                start++;
                count--;
            }
            start++;
        }

        // If max array end at last element, it dosent get chance to get max unless last element is 0
        maxCount = Math.Max(count, maxCount);

    }

    return maxCount;
}