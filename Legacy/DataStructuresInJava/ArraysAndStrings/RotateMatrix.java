// Question - Rotate an NxN matrix 90 degrees clockwise in-place
// #matrix #array #in-place #ctci

public class RotateMatrix {

    // Layer-by-layer rotation, 4 elements at a time
    // O(n²) time, O(1) space
    static boolean rotateInPlace(int[][] matrix) {
        if (matrix.length == 0 || matrix[0].length == 0 || matrix.length != matrix[0].length)
            return false;

        int n = matrix.length;
        for (int i = 0; i < n / 2; i++) {
            for (int j = i; j < n - i - 1; j++) {
                int temp = matrix[i][j];
                matrix[i][j]                 = matrix[n - j - 1][i];
                matrix[n - j - 1][i]         = matrix[n - i - 1][n - j - 1];
                matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                matrix[j][n - i - 1]         = temp;
            }
        }
        return true;
    }

    static void printMatrix(int[][] matrix) {
        for (int[] row : matrix) {
            for (int val : row)
                System.out.print(val + "\t");
            System.out.println();
        }
    }

    public static void main(String[] args) {
        int[][] m1 = {{1,2,3},{4,5,6},{7,8,9}};
        System.out.println("Original 3x3:"); printMatrix(m1);
        rotateInPlace(m1);
        System.out.println("Rotated:");      printMatrix(m1);

        int[][] m2 = {{1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16}};
        System.out.println("Original 4x4:"); printMatrix(m2);
        rotateInPlace(m2);
        System.out.println("Rotated:");      printMatrix(m2);

        int[][] m3 = {{1,2,3},{4,5,6}};
        System.out.println("Non-square (should fail): " + rotateInPlace(m3));
    }
}
