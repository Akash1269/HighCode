// Problem
// Find middle node at index n/2 ceiling digit, and delete it, return if new head

// #linkedList #twoPointer

// Intuitive and simple solution, do not try to over optimize it.
public ListNode DeleteMiddle(ListNode head)
{
    ListNode slow = head, fast = head;
    ListNode prev = null;

    while (fast != null && fast.next != null)
    {
        prev = slow;
        slow = slow.next;
        fast = fast.next.next;
    }

    if (prev == null) return null;

    // Console.WriteLine("prev - " + prev.val + ", current - " + slow.val);
    prev.next = slow.next;

    return head;
}