// Question -
// Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

// #twoPointer

// Sol 1 - Brute force is create new array and insert all non zero values first and then assign 0
// Sol 2 O(2n) - Instead of doing this in new array, do it in place using two pointers, 2n operations for 2 pass
// Sol 3 O(n) - With swap you can do it in place so instead of possible 2n operations you do n operations only
public void MoveZeroes2(int[] nums)
{
    int z = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0) nums[z++] = nums[i];
    }

    for (int i = z; i < nums.Length; i++)
    {
        nums[i] = 0;
    }
}

public void MoveZeroes3(int[] nums)
{
    int z = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0)
        {
            swap(nums, i, z);
            z++;
        }
    }
}

public void swap(int[] nums, int x, int y)
{
    int temp = nums[x];
    nums[x] = nums[y];
    nums[y] = temp;
}