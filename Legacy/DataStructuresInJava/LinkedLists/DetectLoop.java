// Question - Detect the start of a loop in a linked list (Floyd's cycle detection)
// #linked-list #fast-slow-pointer #cycle-detection #ctci

class Node<T> {
    T data;
    Node<T> next;
    Node(T d) { data = d; }
}

public class DetectLoop {

    // Floyd's algorithm — O(n) time, O(1) space
    // 1. Fast/slow pointers meet inside the loop
    // 2. Reset slow to head, advance both by 1 until they meet at loop start
    static Node<Integer> getLoopStart(Node<Integer> head) {
        if (head == null || head.next == null)
            return null;

        Node<Integer> slow = head;
        Node<Integer> fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) break;
        }
        if (fast == null || fast.next == null)
            return null;  // no cycle

        slow = head;
        while (slow != fast) {
            slow = slow.next;
            fast = fast.next;
        }
        return fast;
    }

    public static void main(String[] args) {
        // Build: 0 -> 1 -> 2 -> 3 -> 4 -> 5 -> back to 2
        Node<Integer> head = new Node<>(0);
        Node<Integer> node = head;
        Node<Integer> loopEntry = null;
        for (int i = 1; i <= 5; i++) {
            Node<Integer> next = new Node<>(i);
            node.next = next;
            node = next;
            if (i == 2) loopEntry = next;
        }
        node.next = loopEntry; // create cycle at node 2

        Node<Integer> result = getLoopStart(head);
        System.out.println("Loop starts at: " + (result != null ? result.data : "none"));
    }
}
