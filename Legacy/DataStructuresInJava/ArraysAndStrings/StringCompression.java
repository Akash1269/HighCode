// Question - Compress a string using counts of repeated characters (e.g., "aabcccccaaa" → "a2b1c5a3")
// #string #two-pointer #ctci

public class StringCompression {

    // Two-pass: first check if compression is shorter, then build
    // O(n) time, O(n) space
    static String compressString(String s) {
        int countConsecutive = 0;
        int compressedSize = 0;
        for (int i = 0; i < s.length(); i++) {
            countConsecutive++;
            if (i + 1 >= s.length() || s.charAt(i) != s.charAt(i + 1)) {
                compressedSize += 1 + String.valueOf(countConsecutive).length();
                countConsecutive = 0;
            }
        }

        if (s.length() <= compressedSize)
            return s;

        StringBuilder sb = new StringBuilder();
        countConsecutive = 0;
        for (int i = 0; i < s.length(); i++) {
            countConsecutive++;
            if (i + 1 >= s.length() || s.charAt(i) != s.charAt(i + 1)) {
                sb.append(s.charAt(i)).append(countConsecutive);
                countConsecutive = 0;
            }
        }
        return sb.toString();
    }

    public static void main(String[] args) {
        System.out.println(compressString("aaaattttttttttttttjjj")); // a4t14j3
        System.out.println(compressString("leelmmmmmm"));            // l1e2l1m6
        System.out.println(compressString("could"));                 // could (not shorter)
        System.out.println(compressString("ccaddddddtt"));           // c2a1d6t2
        System.out.println(compressString("d"));                     // d (not shorter)
    }
}
