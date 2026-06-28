// Question - Check if one string is a rotation of another using a single call to contains()
// #string #ctci

public class StringRotation {

    // Concatenate s1+s1 and check if s2 is a substring — O(n) time
    static boolean isRotation(String s1, String s2) {
        if (s1.length() != s2.length())
            return false;
        return (s1 + s1).contains(s2);
    }

    public static void main(String[] args) {
        System.out.println(isRotation("ell", "lle"));                       // true
        System.out.println(isRotation("lemon", "onlem"));                   // true
        System.out.println(isRotation("le", "el"));                         // true
        System.out.println(isRotation("ccdd", "ddcc"));                     // true
        System.out.println(isRotation("c", "c"));                           // true
        System.out.println(isRotation("cd", "cdc"));                        // false
        System.out.println(isRotation("iamadiscodancer", "discodanceriama")); // true
    }
}
