// Question - 
// Given an array of integers nums, calculate the pivot index of this array.
// The pivot index is the index where the sum of left of the index is equal to the sum of index's right.

// #prefixSum

// Simple intuitive but only caveat is when to compare and add or remove for current element
public int PivotIndex(int[] nums)
{
    int leftSum = 0, rightSum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        rightSum += nums[i];
    }

    for (int i = 0; i < nums.Length; i++)
    {
        // remvoe current element from right sum.
        rightSum -= nums[i];

        if (leftSum == rightSum) return i;

        // add current element to left sum to compare in next run.
        leftSum += nums[i];
    }

    return -1;
}