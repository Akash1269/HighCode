// Question - Replace all spaces in a string with '%20' (in-place using char array)
// #string #array #two-pointer #ctci

public class URLify {

    // Two-pass: count spaces, then fill from the back — O(n) time, O(1) extra space
    static String urlify(String s, int trueLength) {
        int spaceCount = 0;
        for (int i = 0; i < trueLength; i++) {
            if (s.charAt(i) == ' ')
                spaceCount += 2;
        }
        char[] arr = s.toCharArray();
        int insertIndex = trueLength + spaceCount - 1;
        for (int i = trueLength - 1; i >= 0; i--) {
            if (arr[i] == ' ') {
                arr[insertIndex]     = '0';
                arr[insertIndex - 1] = '2';
                arr[insertIndex - 2] = '%';
                insertIndex -= 3;
            } else {
                arr[insertIndex] = arr[i];
                insertIndex--;
            }
        }
        return new String(arr);
    }

    public static void main(String[] args) {
        System.out.println(urlify("el l  ", 4));           // el%20l
        System.out.println(urlify("le m on      ", 7));    // le%20m%20on
        System.out.println(urlify("could", 5));            // could
        System.out.println(urlify(" ccdd  ", 5));           // %20ccdd
    }
}
