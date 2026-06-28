// Question - Determine if a string has all unique characters
// #string #hashset #ctci

import java.util.HashSet;

public class IsUniqueChars {

    // HashSet approach — O(n) time, O(n) space
    private static boolean isUnique(String s) {
        HashSet<Character> set = new HashSet<>();
        for (char c : s.toCharArray()) {
            if (set.contains(c))
                return false;
            set.add(c);
        }
        return true;
    }

    public static void main(String[] args) {
        System.out.println(isUnique("today"));   // true
        System.out.println(isUnique("Tot"));      // true (case-sensitive)
        System.out.println(isUnique("Hello"));    // false ('l' repeats)
    }
}
