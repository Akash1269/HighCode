// Question - Check if a linked list is a palindrome
// #linked-list #stack #fast-slow-pointer #ctci

import java.util.Stack;

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

public class LinkedListPalindrome {

    // Stack + fast/slow pointer — O(n) time, O(n) space
    // Push first half onto stack, compare with second half
    static boolean isPalindrome(SLL<Integer> list) {
        Stack<Integer> stack = new Stack<>();
        Node<Integer> slow = list.head;
        Node<Integer> fast = list.head;

        // Push first half
        while (fast != null && fast.next != null) {
            stack.push(slow.data);
            slow = slow.next;
            fast = fast.next.next;
        }
        // Odd length: skip middle element
        if (fast != null)
            slow = slow.next;

        // Compare second half with stack
        while (slow != null) {
            if (!slow.data.equals(stack.pop()))
                return false;
            slow = slow.next;
        }
        return true;
    }

    public static void main(String[] args) {
        SLL<Integer> even = new SLL<>();
        for (int v : new int[]{2, 6, 4, 4, 6, 2}) even.insert(v);
        even.print();
        System.out.println("Palindrome: " + isPalindrome(even));

        SLL<Integer> odd = new SLL<>();
        for (int v : new int[]{9, 1, 4, 5, 4, 1, 9}) odd.insert(v);
        odd.print();
        System.out.println("Palindrome: " + isPalindrome(odd));

        SLL<Integer> no = new SLL<>();
        for (int v : new int[]{9, 1, 4, 5, 6, 1, 9}) no.insert(v);
        no.print();
        System.out.println("Palindrome: " + isPalindrome(no));
    }
}
