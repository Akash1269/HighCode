// Question - Define Kth largest in a stream of integers, where on insert return kth largest at that point
// KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of test scores.
// int add(int val) Adds a new test score and returns kth largest element in the pool.

// #heap

// Solution 1
public class KthLargest
{
    PriorityQueue<int, int> pq;
    int kValue;

    public KthLargest(int k, int[] nums)
    {
        pq = new PriorityQueue<int, int>();
        kValue = k;
        foreach (int num in nums)
        {
            AddValue(num);
        }
    }

    public void AddValue(int val)
    {
        pq.Enqueue(val, val);

        if (pq.Count > kValue)
        {
            pq.Dequeue();
        }
    }

    public int Add(int val)
    {
        AddValue(val);
        return pq.Peek();
    }
}