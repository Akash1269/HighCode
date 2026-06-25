// Question - Given an integer array nums and an integer k, return the kth largest element in the array. (without sorting)

// #priorityQueue #heap

// Simply use priority queue of size k and remove element if size is already k
// So this mean heap will have kth largest element at root since all other higher elements are in the down child heap.
public int FindKthLargest(int[] nums, int k)
{
    PriorityQueue<int, int> q = new PriorityQueue<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        q.Enqueue(nums[i], nums[i]);

        if (q.Count > k)
            q.Dequeue();
    }

    return q.Peek();
}