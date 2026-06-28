// Question - If an element in an MxN matrix is 0, set its entire row and column to 0
// #matrix #array #in-place #ctci

public class ZeroMatrix {

    // Uses first row/column as markers — O(mn) time, O(1) space
    static boolean makeMatrixZero(int[][] matrix) {
        if (matrix.length == 0 || matrix[0].length == 0)
            return false;

        int rows = matrix.length;
        int cols = matrix[0].length;
        boolean firstRowZero = false;
        boolean firstColZero = false;

        // Check if first row/column have zeros
        for (int j = 0; j < cols; j++)
            if (matrix[0][j] == 0) { firstRowZero = true; break; }
        for (int i = 0; i < rows; i++)
            if (matrix[i][0] == 0) { firstColZero = true; break; }

        // Mark zeros in first row/column
        for (int i = 1; i < rows; i++)
            for (int j = 1; j < cols; j++)
                if (matrix[i][j] == 0) {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }

        // Zero out marked rows
        for (int i = 1; i < rows; i++)
            if (matrix[i][0] == 0)
                for (int j = 1; j < cols; j++) matrix[i][j] = 0;

        // Zero out marked columns
        for (int j = 1; j < cols; j++)
            if (matrix[0][j] == 0)
                for (int i = 1; i < rows; i++) matrix[i][j] = 0;

        // Handle first row/column last
        if (firstRowZero)
            for (int j = 0; j < cols; j++) matrix[0][j] = 0;
        if (firstColZero)
            for (int i = 0; i < rows; i++) matrix[i][0] = 0;

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
        int[][] m1 = {{0,2,3},{4,5,6},{7,8,9}};
        System.out.println("Original:");  printMatrix(m1);
        makeMatrixZero(m1);
        System.out.println("Zeroed:");    printMatrix(m1);

        int[][] m2 = {{1,2,3,0},{5,6,0,8},{9,10,11,0},{13,14,15,16}};
        System.out.println("Original:");  printMatrix(m2);
        makeMatrixZero(m2);
        System.out.println("Zeroed:");    printMatrix(m2);

        int[][] m3 = {{1,2,3},{4,5,0}};
        System.out.println("Original:");  printMatrix(m3);
        makeMatrixZero(m3);
        System.out.println("Zeroed:");    printMatrix(m3);
    }
}
