// Question - Partition a linked list around a value x (all nodes < x before nodes >= x)
// #linked-list #partition #ctci

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

public class PartitionList {

    // Move smaller elements to the front — O(n) time, O(1) space
    static void partitionMoveToStart(SLL<Integer> list, int value) {
        Node<Integer> node = list.head;
        Node<Integer> prev = null;
        while (node != null) {
            if (node.data < value && prev != null) {
                prev.next = node.next;
                node.next = list.head;
                list.head = node;
                node = prev.next;
            } else {
                prev = node;
                node = node.next;
            }
        }
    }

    // Move larger elements to the end — O(n) time, O(1) space
    static void partitionMoveToEnd(SLL<Integer> list, int value) {
        Node<Integer> node = list.head;
        Node<Integer> last = node;
        Node<Integer> prev = null;
        int size = 0;
        while (last.next != null) { last = last.next; size++; }

        while (node != null && size >= 0) {
            if (node.data >= value && prev != null) {
                prev.next = node.next;
                node.next = null;
                last.next = node;
                last = node;
                node = prev.next;
            } else {
                prev = node;
                node = node.next;
            }
            size--;
        }
    }

    public static void main(String[] args) {
        SLL<Integer> list1 = new SLL<>();
        for (int v : new int[]{2, 6, 3, 1, 8, 9, 4}) list1.insert(v);
        System.out.print("Original:   "); list1.print();
        partitionMoveToStart(list1, 5);
        System.out.print("Partition<5:"); list1.print();

        SLL<Integer> list2 = new SLL<>();
        for (int v : new int[]{2, 6, 3, 1, 8, 9, 4}) list2.insert(v);
        System.out.print("\nOriginal:   "); list2.print();
        partitionMoveToEnd(list2, 5);
        System.out.print("Partition<5:"); list2.print();
    }
}
