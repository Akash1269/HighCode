// Question - Check if one string is a permutation of another
// #string #hashmap #ctci

import java.util.HashMap;

public class IsPermutation {

    // HashMap frequency count — O(n) time, O(n) space
    static boolean isPermutation(String s1, String s2) {
        if (s1.length() != s2.length())
            return false;

        HashMap<Character, Integer> countMap = new HashMap<>();
        for (int i = 0; i < s1.length(); i++) {
            char c = s1.charAt(i);
            countMap.put(c, countMap.getOrDefault(c, 0) + 1);
        }
        for (int i = 0; i < s2.length(); i++) {
            char c = s2.charAt(i);
            if (!countMap.containsKey(c) || countMap.get(c) - 1 < 0)
                return false;
            countMap.put(c, countMap.get(c) - 1);
        }
        return true;
    }

    public static void main(String[] args) {
        System.out.println(isPermutation("ell", "lle"));       // true
        System.out.println(isPermutation("lemon", "noelm"));   // true
        System.out.println(isPermutation("could", "lie"));     // false
    }
}
