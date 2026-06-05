// Question - Reverse Linked List

// #linkedList

// Intuitive, save next and then change next to prev
public ListNode ReverseList(ListNode head)
{
    ListNode current = head;
    ListNode prev = null;

    while (current != null)
    {
        ListNode newNext = current.next;
        current.next = prev;
        prev = current;
        current = newNext;
    }

    return prev;
}