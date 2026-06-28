// Question - Delete a node from a linked list given only access to that node (not the head)
// #linked-list #in-place #ctci

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

public class DeleteMiddleNode {

    // Copy next node's data and skip it — O(1) time
    // Note: cannot delete the last node with this technique
    static boolean deleteNode(Node<Integer> node) {
        if (node == null || node.next == null)
            return false;
        node.data = node.next.data;
        node.next = node.next.next;
        return true;
    }

    public static void main(String[] args) {
        SLL<Integer> list = new SLL<>();
        for (int v : new int[]{7, 6, 5, 4, 3, 2, 1}) list.insert(v);
        list.print();

        // Navigate to node with value 3
        Node<Integer> node = list.head;
        while (node != null && node.data != 3) node = node.next;

        System.out.println("Deleting node with value: " + node.data);
        System.out.println("Deleted: " + deleteNode(node));
        list.print();
    }
}
