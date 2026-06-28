// Question - Remove duplicates from an unsorted linked list
// #linked-list #hashset #ctci

import java.util.HashSet;

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

public class RemoveDuplicates {

    // HashSet approach — O(n) time, O(n) space
    static void removeDuplicates(SLL<Integer> list) {
        Node<Integer> node = list.head;
        Node<Integer> prev = null;
        HashSet<Integer> seen = new HashSet<>();
        while (node != null) {
            if (seen.contains(node.data)) {
                prev.next = node.next;
            } else {
                seen.add(node.data);
                prev = node;
            }
            node = node.next;
        }
    }

    public static void main(String[] args) {
        SLL<Integer> list = new SLL<>();
        for (int v : new int[]{6, 4, 7, 6, 3, 2}) list.insert(v);
        list.print();
        removeDuplicates(list);
        list.print();

        SLL<Integer> list2 = new SLL<>();
        for (int v : new int[]{6, 4, 7, 6, 4, 6}) list2.insert(v);
        list2.print();
        removeDuplicates(list2);
        list2.print();
    }
}
