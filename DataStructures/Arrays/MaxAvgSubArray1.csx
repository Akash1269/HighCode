// Question - 
// You are given an integer array nums consisting of n elements, and an integer k.
// Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value.

// #slidingWindow

// Simple intuitive solution O(n) time complexity. 
public double FindMaxAverage(int[] nums, int k)
{
    int runningSum = 0;
    int maxSum = int.MinValue;

    for (int i = 0; i < nums.Length; i++)
    {
        runningSum += nums[i];

        // when length > k, start deleting from start
        if (i >= k) runningSum -= nums[i - k];

        // when length >= k, then start considering, before that range is smaller
        if (i >= k - 1) maxSum = Math.Max(maxSum, runningSum);
    }

    return maxSum * 1.0 / k;
}

// Another approach would be to split this into two loops and then run it in same way
public double FindMaxAverage(int[] nums, int k)
{
    int sum = 0;

    for (int i = 0; i < k; i++)
        sum += nums[i];

    int maxSum = sum;

    for (int i = k; i < nums.Length; i++)
    {
        sum += nums[i] - nums[i - k];
        maxSum = Math.Max(maxSum, sum);
    }

    return (double)maxSum / k;
}