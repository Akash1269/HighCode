// Question - Given number n and chosen number x, guess the number x from range 1 to n

// #binarySearch

// Simple binary search on range 1 to n
public class Solution : GuessGame
{
    public int GuessNumber(int n)
    {
        int start = 1, end = n, mid = 0;
        int match = -1;

        while (start <= end)
        {
            mid = start + (end - start) / 2;
            match = guess(mid);

            if (match == -1)
            {
                end = mid - 1;
            }
            else if (match == 1)
            {
                start = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return 0;
    }
}