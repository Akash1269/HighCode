// Question - 
// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

// #bothEnds

// Intuitive solution by finding all numbers product first, and then divide by self
// But this has lot of edge cases like 0 and all needs to be handled. Order of cases also matters
// Time - O(n), Space - O(n) , but no extra space than output.
public int[] ProductExceptSelf(int[] nums)
{
    int product = 1;
    int hasZero = 0;
    int[] output = new int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0) hasZero += 1;
        else product = product * nums[i];
    }

    for (int i = 0; i < nums.Length; i++)
    {
        // order of these conditions matter a lot, since it eliminates prev conditions
        if (hasZero > 1) output[i] = 0;
        else if (nums[i] == 0) output[i] = product;
        else if (hasZero == 1) output[i] = 0;
        else output[i] = product / nums[i];
    }

    return output;
}

// Store one end of multiplications first and then multiply from other end to get except product.
// Not too many complex edge cases. Product[i] = nums[i] * ... * nums[n - 1];
// Time - O(n), Space - O(n) , but no extra space than output.
public int[] ProductExceptSelf(int[] nums)
{
    int product = 1;
    int[] output = new int[nums.Length];

    for (int i = nums.Length - 1; i >= 0; i--)
    {
        product = product * nums[i];
        output[i] = product;
    }

    product = 1;
    for (int i = 0; i < nums.Length - 1; i++)
    {
        output[i] = product * output[i + 1];
        product = product * nums[i];
    }

    // since we have to limit loop for i + 1, last item remains for which there is no right product
    output[nums.Length - 1] = product;

    return output;
}