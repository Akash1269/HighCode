// Question - Find the intersection node of two singly linked lists
// #linked-list #two-pointer #ctci

class Node<T> {
    T data;
    Node<T> next;
    Node(T d) { data = d; }
}

public class ListIntersection {

    static class ListInfo {
        int length;
        Node<Integer> tail;
        ListInfo(int len, Node<Integer> tail) { this.length = len; this.tail = tail; }
    }

    // Get length and tail node
    static ListInfo getInfo(Node<Integer> head) {
        int length = 1;
        while (head.next != null) { head = head.next; length++; }
        return new ListInfo(length, head);
    }

    // Advance pointer by n steps
    static Node<Integer> advance(Node<Integer> node, int n) {
        for (int i = 0; i < n; i++) node = node.next;
        return node;
    }

    // Find intersection — O(n+m) time, O(1) space
    // 1. Check if same tail (must intersect)
    // 2. Trim longer list to match length
    // 3. Walk both until they meet
    static Node<Integer> getIntersection(Node<Integer> h1, Node<Integer> h2) {
        if (h1 == null || h2 == null) return null;

        ListInfo info1 = getInfo(h1);
        ListInfo info2 = getInfo(h2);

        if (info1.tail != info2.tail) return null;  // no intersection

        Node<Integer> longer  = info1.length > info2.length ? h1 : h2;
        Node<Integer> shorter = info1.length > info2.length ? h2 : h1;
        longer = advance(longer, Math.abs(info1.length - info2.length));

        while (longer != shorter) {
            longer = longer.next;
            shorter = shorter.next;
        }
        return longer;
    }

    public static void main(String[] args) {
        // Build two lists that intersect at node with value 3
        Node<Integer> shared = new Node<>(3);
        shared.next = new Node<>(4);
        shared.next.next = new Node<>(5);

        Node<Integer> h1 = new Node<>(0);
        h1.next = new Node<>(1);
        h1.next.next = new Node<>(2);
        h1.next.next.next = shared;

        Node<Integer> h2 = new Node<>(10);
        h2.next = shared;

        Node<Integer> result = getIntersection(h1, h2);
        System.out.println("Intersection at: " + (result != null ? result.data : "none"));
    }
}
