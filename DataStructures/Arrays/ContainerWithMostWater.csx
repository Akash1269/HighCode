// Question - 
// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
// Find two lines that together with the x-axis form a container, such that the container contains the most water.

// #twoPointer

// Single loop, two pointer O(n), start from both ends for max area
// At each step, area is limited by the shorter wall. If we move the taller wall, width decreases but the shorter wall still limits water, 
// so area cannot improve. Hence, we move the shorter pointer to try finding a taller wall.
// For a fixed shorter wall, the farthest wall already gives maximum width, 
// so no better answer can exist with that same wall. We safely discard it and continue, which ensures no solution is missed.
public int MaxArea(int[] height)
{
    int maxArea = 0;
    int start = 0, end = height.Length - 1;

    while (start < end)
    {
        int area = (end - start) * Math.Min(height[start], height[end]);
        maxArea = Math.Max(area, maxArea);

        if (height[start] < height[end]) start++;
        else end--;
    }

    return maxArea;
}

// Brute force, try all possible combinations O(n2)
public int MaxArea1(int[] height)
{
    int maxArea = 0;

    for (int i = 0; i < height.Length; i++)
    {
        for (int j = i + 1; j < height.Length; j++)
        {
            int area = (j - i) * Math.Min(height[i], height[j]);
            maxArea = Math.Max(area, maxArea);
        }
    }

    return maxArea;
}