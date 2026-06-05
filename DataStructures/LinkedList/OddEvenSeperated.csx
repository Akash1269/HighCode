// Question
// Seperate odd and even indexed nodes, all even nodes in same order on left and after that odd nodes in same order

// #linkedList #twoPointer

public ListNode OddEvenList(ListNode head)
{
    if (head == null || head.next == null) return head;

    ListNode current = head;

    ListNode evenHead = new ListNode();
    ListNode lastEvenNode = evenHead;

    while (current.next != null)
    {
        // attach even node to even list
        lastEvenNode.next = current.next;
        lastEvenNode = lastEvenNode.next;

        // remove odd node and move to next odd
        current.next = current.next.next;

        // go next on current only next is not null since we want to set even list on last node
        if (current.next == null) break;
        current = current.next;
    }

    lastEvenNode.next = null;

    current.next = evenHead.next;
    return head;
}