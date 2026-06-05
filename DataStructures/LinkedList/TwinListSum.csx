// Question - 
// In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node
// Add sum of twin node and find max sum of any twin pair nodes

// #linkedList #twoPointer #recursive #stack

// Some other solutions- 
// 3. Use stack for first half and then compare that with second half in forward order using slow pointer
// 4. Craete array and traverse from both side two pointer sum

// Recursive solution, basically move towards end and then backtrack with two points end and start smartly
// Keep count in ref, and head moves next from end backwards.
public int PairSum2(ListNode head)
{
    int max = 0;

    RecurseSum(head, head, ref max);

    return max;
}

public ListNode RecurseSum(ListNode head, ListNode twinHead, ref int max)
{
    if (twinHead == null) return head;

    ListNode mainHead = RecurseSum(head, twinHead.next, ref max);

    int sum = mainHead.val + twinHead.val;
    max = Math.Max(sum, max);

    return mainHead.next;
}

// Simple intuitive solution, more efficient to reverse second half and sum each element with first half
// In place most efficient time and space complexity, but changes linekdlist, can be reversed again
public int PairSum(ListNode head)
{
    int maxSum = 0;
    ListNode fast = head, slow = head;

    // Find head of twin list, that is middle node 
    while (fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
    }

    ListNode prev = null;
    ListNode current = slow;

    // revert the list from middle
    while (current != null)
    {
        ListNode next = current.next;
        current.next = prev;
        prev = current;
        current = next;
    }

    ListNode twinHead = prev;
    current = head;

    // loop form both ends of the list twins, and maintain max sum
    while (twinHead != null && current != null)
    {
        Console.WriteLine("twin - " + twinHead.val + "main - " + current.val);
        int sum = twinHead.val + current.val;
        maxSum = Math.Max(sum, maxSum);
        twinHead = twinHead.next;
        current = current.next;
    }

    return maxSum;
}