// Given an array piles where piles[i] is the number of bananas in the ith pile, 
// and an integer h representing the maximum hours available, 
// find the minimum integer eating speed k (bananas/hour) such that all bananas can be eaten within h hours.

// #binarySearch

// Solution 1 - Brute force, start from k = 1 to max element in the array
public int MinEatingSpeed(int[] piles, int h)
{
    int k = 1;
    int n = piles.Length;
    int max = 0, sum = 0;

    for (int i = 0; i < n; i++)
    {
        max = Math.Max(max, piles[i]);
        sum += piles[i];
    }

    while (k < max)
    {
        long hours = GetHours(piles, h, k);
        Console.WriteLine("hours - {0}", hours);

        if (hours <= h)
            break;
        k++;
    }

    return k;
}

public long GetHours(int[] piles, int h, int k)
{
    long hours = 0;

    for (int i = 0; i < piles.Length; i++)
    {
        hours += piles[i] / k;

        if (piles[i] % k != 0)
        {
            hours += 1;
        }
    }

    return hours;
}

// solution 2- Binary search for the k value
public int MinEatingSpeed(int[] piles, int h)
{
    int n = piles.Length;
    int max = 0;

    for (int i = 0; i < n; i++)
    {
        max = Math.Max(max, piles[i]);
    }

    int start = 1, end = max;
    int k = start;

    while (start <= end)
    {
        k = start + (end - start) / 2;
        long hours = GetHours(piles, k);

        if (hours <= h)
        {
            end = k - 1;
        }
        else
        {
            start = k + 1;
        }
    }

    return start;
}

public long GetHours(int[] piles, int k)
{
    long hours = 0;

    for (int i = 0; i < piles.Length; i++)
    {
        hours += (piles[i] + k - 1) / k;
    }

    return hours;
}