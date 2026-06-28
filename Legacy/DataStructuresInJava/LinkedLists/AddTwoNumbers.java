// Question - Add two numbers represented as linked lists (both reverse and forward order)
// #linked-list #recursion #math #ctci

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
    int size() {
        int s = 0;
        Node<T> n = head;
        while (n != null) { s++; n = n.next; }
        return s;
    }
    void print() {
        Node<T> n = head;
        while (n != null) { System.out.print(n.data + " -> "); n = n.next; }
        System.out.println("null");
    }
}

public class AddTwoNumbers {

    // --- Approach 1: Iterative, digits stored in reverse order ---
    // O(n) time, O(n) space
    static SLL<Integer> addReverse(SLL<Integer> num1, SLL<Integer> num2) {
        Node<Integer> n1 = num1.head, n2 = num2.head;
        Node<Integer> tail = null;
        SLL<Integer> result = new SLL<>();
        int carry = 0;

        while (n1 != null || n2 != null || carry != 0) {
            int sum = carry;
            if (n1 != null) { sum += n1.data; n1 = n1.next; }
            if (n2 != null) { sum += n2.data; n2 = n2.next; }
            carry = sum / 10;
            Node<Integer> node = new Node<>(sum % 10);
            if (tail != null) tail.next = node; else result.head = node;
            tail = node;
        }
        return result;
    }

    // --- Approach 2: Recursive, digits stored in reverse order ---
    static Node<Integer> addReverseRecursive(Node<Integer> n1, Node<Integer> n2, int carry) {
        if (n1 == null && n2 == null && carry == 0)
            return null;
        int sum = carry;
        if (n1 != null) sum += n1.data;
        if (n2 != null) sum += n2.data;
        Node<Integer> node = new Node<>(sum % 10);
        node.next = addReverseRecursive(
            n1 != null ? n1.next : null,
            n2 != null ? n2.next : null,
            sum / 10
        );
        return node;
    }

    // --- Approach 3: Recursive, digits stored in forward order ---
    // Pad shorter list with zeros, then recurse from least significant
    static class CarryResult {
        int carry;
        Node<Integer> node;
        CarryResult(int c) { carry = c; }
    }

    static Node<Integer> addForward(SLL<Integer> num1, SLL<Integer> num2) {
        int len1 = num1.size(), len2 = num2.size();
        if (len1 > len2) padZeros(num2, len1 - len2);
        else             padZeros(num1, len2 - len1);

        CarryResult result = addForwardRecursive(num1.head, num2.head);
        if (result.carry > 0) {
            Node<Integer> head = new Node<>(result.carry);
            head.next = result.node;
            return head;
        }
        return result.node;
    }

    static CarryResult addForwardRecursive(Node<Integer> n1, Node<Integer> n2) {
        if (n1 == null && n2 == null)
            return new CarryResult(0);
        CarryResult sub = addForwardRecursive(n1.next, n2.next);
        int sum = sub.carry + n1.data + n2.data;
        CarryResult result = new CarryResult(sum / 10);
        Node<Integer> node = new Node<>(sum % 10);
        node.next = sub.node;
        result.node = node;
        return result;
    }

    static void padZeros(SLL<Integer> list, int count) {
        for (int i = 0; i < count; i++) {
            Node<Integer> node = new Node<>(0);
            node.next = list.head;
            list.head = node;
        }
    }

    static void printFrom(Node<Integer> n) {
        while (n != null) { System.out.print(n.data + " -> "); n = n.next; }
        System.out.println("null");
    }

    public static void main(String[] args) {
        // Reverse order: 287938 + 91454523
        SLL<Integer> n1 = new SLL<>(), n2 = new SLL<>();
        for (int v : new int[]{2, 8, 7, 9, 3, 8}) n1.insert(v);
        for (int v : new int[]{9, 1, 4, 5, 4, 5, 2, 3}) n2.insert(v);

        System.out.print("Num1: "); n1.print();
        System.out.print("Num2: "); n2.print();

        System.out.print("Sum (forward): ");
        printFrom(addForward(n1, n2));

        // Reverse order addition
        SLL<Integer> r1 = new SLL<>(), r2 = new SLL<>();
        for (int v : new int[]{7, 1, 6}) r1.insert(v);   // 617
        for (int v : new int[]{5, 9, 2}) r2.insert(v);   // 295

        System.out.print("\nReverse Num1: "); r1.print();
        System.out.print("Reverse Num2: "); r2.print();
        System.out.print("Sum (reverse iterative): ");
        addReverse(r1, r2).print();
        System.out.print("Sum (reverse recursive): ");
        printFrom(addReverseRecursive(r1.head, r2.head, 0));
    }
}
