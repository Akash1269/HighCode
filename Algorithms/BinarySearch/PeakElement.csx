// A peak element is an element that is strictly greater than its neighbors.
// Given a integer array nums, find a peak element, and return its index. If it has multiple peaks, return any of the peaks.

// #binarySerch

// Solution 1 - Linear search
public int FindPeakElement(int[] nums)
{
    if (nums.Length == 1)
        return 0;

    int n = nums.Length;

    if (nums[0] > nums[1])
        return 0;

    if (nums[n - 1] > nums[n - 2])
        return n - 1;

    for (int i = 1; i < nums.Length - 1; i++)
    {
        if (nums[i] > nums[i + 1] && nums[i] > nums[i - 1])
        {
            return i;
        }
    }

    return 0;
}

// Solution 2 - Binary search on side where neighbour is higher, so there is already chance of one neighbour valid
public int FindPeakElement(int[] nums)
{
    int n = nums.Length;

    if (n == 1)
        return 0;

    if (nums[0] > nums[1])
        return 0;

    if (nums[n - 1] > nums[n - 2])
        return n - 1;

    int start = 1, end = n - 2;

    while (start <= end)
    {
        int mid = start + (end - start) / 2;

        if (nums[mid] > nums[mid + 1] && nums[mid] > nums[mid - 1])
        {
            return mid;
        }
        else if (nums[mid] < nums[mid + 1])
        {
            start = mid + 1;
        }
        else
        {
            end = mid - 1;
        }
    }

    return 0;
}