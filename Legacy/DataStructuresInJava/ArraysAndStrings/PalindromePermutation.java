// Question - Check if a string is a permutation of a palindrome
// #string #hashmap #palindrome #ctci

import java.util.HashMap;

public class PalindromePermutation {

    // Count character frequencies — at most one odd count allowed
    // O(n) time, O(1) space (bounded by character set)
    static boolean isPermutationOfPalindrome(String s) {
        HashMap<Character, Integer> countMap = new HashMap<>();
        int oddCount = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            countMap.put(c, countMap.getOrDefault(c, 0) + 1);
            if (countMap.get(c) % 2 == 0)
                oddCount--;
            else
                oddCount++;
        }
        return oddCount <= 1;
    }

    public static void main(String[] args) {
        System.out.println(isPermutationOfPalindrome("afasfasayuu")); // false
        System.out.println(isPermutationOfPalindrome("leelmom"));     // true
        System.out.println(isPermutationOfPalindrome("could"));       // false
        System.out.println(isPermutationOfPalindrome(" ccadd "));     // true
        System.out.println(isPermutationOfPalindrome("d"));           // true
    }
}
