// Question - given array of workers with their cost, you have to choose k workers, 
// but you can choose only one worker with lowest cost (if same cost choose lower index) in one round, 
// next round you can choose another worker until you have chosen k workers.
// Now there is one condition, you have to always choose from first x(candidates) or last x(candidates) 
// so basically limits the array you can choose from, and over time array might shrink so more workers will come into this range.

// #heap

// Solution - Maintain two heaps for left and right choose min from two to dequeue
public long TotalCost(int[] costs, int k, int candidates)
{
    var leftHeap = new PriorityQueue<int, int>();
    var rightHeap = new PriorityQueue<int, int>();

    int leftEnd = candidates - 1;
    int rightStart = costs.Length - candidates;
    long totalCost = 0;

    IntializeHeap(costs, leftEnd, rightStart, leftHeap, rightHeap);

    for (int i = 0; i < k; i++)
    {
        int leftIndex, leftCost, rightIndex, rightCost;

        bool hasLeft = leftHeap.TryPeek(out leftIndex, out leftCost);
        bool hasRight = rightHeap.TryPeek(out rightIndex, out rightCost);

        if ((hasRight && !hasLeft) || (hasRight && hasLeft && rightCost < leftCost))
        {
            rightHeap.Dequeue();
            totalCost += rightCost;

            if (leftEnd < rightStart - 1)
            {
                rightStart--;
                rightHeap.Enqueue(rightStart, costs[rightStart]);
            }
        }
        else
        {
            leftHeap.Dequeue();
            totalCost += leftCost;


            if (leftEnd < rightStart - 1)
            {
                leftEnd++;
                leftHeap.Enqueue(leftEnd, costs[leftEnd]);
            }
        }
    }

    return totalCost;
}

public void IntializeHeap(int[] costs, int leftEnd, int rightStart, PriorityQueue<int, int> leftHeap, PriorityQueue<int, int> rightHeap)
{
    int n = costs.Length;

    for (int i = 0; i <= leftEnd; i++)
    {
        leftHeap.Enqueue(i, costs[i]);
    }

    int start = Math.Max(rightStart, leftEnd + 1);

    for (int i = start; i < n; i++)
    {
        rightHeap.Enqueue(i, costs[i]);
    }
}