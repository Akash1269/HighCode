// Question - Given arrays spells[n] and potions[m], and an integer success,
// return an array where pairs[i] = number of potions where spells[i] * potions[j] >= success.

// #binarysearch

// Solution 1 - naive but optmized
public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
{
    Array.Sort(potions);
    int[] results = new int[spells.Length];

    for (int i = 0; i < spells.Length; i++)
    {
        for (int j = 0; j < potions.Length; j++)
        {
            long product = (long)spells[i] * potions[j];
            if (product >= success)
            {
                results[i] = potions.Length - j;
                break;
            }
        }
    }

    return results;
}

// Solution 2 - Using binary search fuzzy until it reaches point of start <= end as we are not finding any element here.
public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
{
    Array.Sort(potions);
    int n = potions.Length;
    int[] results = new int[spells.Length];

    for (int i = 0; i < spells.Length; i++)
    {
        int start = 0, end = n - 1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if ((long)spells[i] * potions[mid] < success)
                start = mid + 1;
            else
                end = mid - 1;
        }

        results[i] = n - start;
    }

    return results;
}