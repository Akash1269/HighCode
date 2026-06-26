// Question - For Maximum Subsequence Score:
// Choose exactly k indices from nums1 and nums2 (same indices in both arrays).
// Maximize (sum of chosen nums1 values) × (minimum chosen nums2 value).

// #heap #sort

// Solution 1 -
// Pair nums1 and nums2, then sort by nums2 in descending order.
// Traverse the sorted pairs, maintaining the largest k nums1 values in a min heap and their running sum.
// Whenever the heap has k elements, compute runningSum × current nums2 (since the current nums2 is the minimum of the chosen set) and update the maximum score.
public long MaxScore(int[] nums1, int[] nums2, int k)
{
    int n = nums1.Length;

    // Pair nums1 and nums2 together
    var pairs = new (int num1, int num2)[n];
    for (int i = 0; i < n; i++)
    {
        pairs[i] = (nums1[i], nums2[i]);
    }

    // Sort by nums2 in descending order
    Array.Sort(pairs, (a, b) => b.num2.CompareTo(a.num2));

    var minHeap = new PriorityQueue<int, int>(k);
    long sum = 0;
    long answer = 0;

    foreach (var (num1, num2) in pairs)
    {
        // Add current nums1
        minHeap.Enqueue(num1, num1);
        sum += num1;

        // Keep only the largest k nums1 values
        if (minHeap.Count > k)
        {
            sum -= minHeap.Dequeue();
        }

        // If we have exactly k elements, can consider this subsequence
        if (minHeap.Count == k)
        {
            answer = Math.Max(answer, sum * num2);
        }
    }

    return answer;
}

// Solution - Same approach with minor optimization like index arry and conditions
public long MaxScore(int[] nums1, int[] nums2, int k)
{
    int n = nums1.Length;

    // Create index array
    int[] order = new int[n];
    for (int i = 0; i < n; i++)
    {
        order[i] = i;
    }

    // Sort indices by nums2 descending
    Array.Sort(order, (a, b) => nums2[b].CompareTo(nums2[a]));

    var minHeap = new PriorityQueue<int, int>(k);
    long sum = 0;
    long answer = 0;

    for (int i = 0; i < n; i++)
    {
        int index = order[i];

        sum += nums1[index];
        minHeap.Enqueue(nums1[index], nums1[index]);

        if (minHeap.Count > k)
        {
            sum -= minHeap.Dequeue();
        }

        if (minHeap.Count == k)
        {
            long score = sum * nums2[index];

            if (score > answer)
            {
                answer = score;
            }
        }
    }

    return answer;
}