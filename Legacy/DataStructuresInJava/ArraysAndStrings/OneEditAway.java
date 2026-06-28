// Question - Check if two strings are one edit (insert, remove, replace) away
// #string #two-pointer #ctci

public class OneEditAway {

    // Single pass with two pointers — O(n) time, O(1) space
    // Handles insert, delete, and replace in one loop
    static boolean isOneChangeAway(String s1, String s2) {
        if (Math.abs(s1.length() - s2.length()) > 1)
            return false;

        boolean oneDiff = false;
        for (int i = 0, j = 0; i < s1.length() && j < s2.length(); i++, j++) {
            if (s1.charAt(i) != s2.charAt(j)) {
                if (oneDiff)
                    return false;
                oneDiff = true;

                if (s1.length() > s2.length())
                    i++;       // skip char in s1 (deletion)
                else if (s2.length() > s1.length())
                    j++;       // skip char in s2 (insertion)
                // equal length: replacement — both advance via loop
            }
        }
        return true;
    }

    public static void main(String[] args) {
        System.out.println(isOneChangeAway("afas", "afs"));        // true (delete)
        System.out.println(isOneChangeAway("leelmom", "leelmsm")); // true (replace)
        System.out.println(isOneChangeAway("cod", "codr"));        // true (insert)
        System.out.println(isOneChangeAway("d", "t"));             // true (replace)
        System.out.println(isOneChangeAway("d", "rd"));            // true (insert)
        System.out.println(isOneChangeAway("abc", "ade"));         // false (2 edits)
        System.out.println(isOneChangeAway("dd", "ter"));          // false
        System.out.println(isOneChangeAway("dg", "rdgr"));        // false
    }
}
