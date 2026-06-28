// Question - Return the kth to last element of a singly linked list
// #linked-list #two-pointer #recursion #ctci

class Node<T> {
    T data;
    Node<T> next;
    Node(T d) { data = d; }
}

class SLL<T> {
    Node<T> head;
    void insert(T data) {
        Node<T> n = new Node<>(data);
        if (head == null) { head = n; return; }
        Node<T> cur = head;
        while (cur.next != null) cur = cur.next;
        cur.next = n;
    }
    void print() {
        Node<T> n = head;
        while (n != null) { System.out.print(n.data + " -> "); n = n.next; }
        System.out.println("null");
    }
}

public class KthToLastNode {

    // Two-pointer approach — O(n) time, O(1) space
    // Advance first pointer k steps, then walk both until first hits end
    static Integer kthToLast(SLL<Integer> list, int k) {
        Node<Integer> lead = list.head;
        Node<Integer> trail = list.head;
        for (int i = 0; i < k; i++) {
            if (lead == null) return null;
            lead = lead.next;
        }
        while (lead != null) {
            trail = trail.next;
            lead = lead.next;
        }
        return trail != null ? trail.data : null;
    }

    // Recursive approach — O(n) time, O(n) space (call stack)
    // Returns count from end; prints when count matches k
    static int recursiveKthToLast(Node<Integer> node, int k) {
        if (node == null)
            return 0;
        int index = recursiveKthToLast(node.next, k) + 1;
        if (index == k)
            System.out.println("Kth to last (recursive): " + node.data);
        return index;
    }

    public static void main(String[] args) {
        SLL<Integer> list = new SLL<>();
        for (int v : new int[]{7, 6, 5, 4, 3, 2, 1}) list.insert(v);
        list.print();

        System.out.println("4th to last (iterative): " + kthToLast(list, 4));
        recursiveKthToLast(list.head, 4);
    }
}
