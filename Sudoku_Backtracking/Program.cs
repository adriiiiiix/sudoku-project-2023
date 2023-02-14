using System;
class GFG {

    public static int numberOfIterations = 0;

    public static bool IsSafe (int[, ] board, int row, int col, int num) {

        // verify if the number is already in this row 
        for (int columnNumber = 0; columnNumber < board.GetLength (0); columnNumber++) {
            if (board[row, columnNumber] == num) {
                return false;
            }
        }

        // verify if the number is already in this column 
        for (int rowNumber = 0; rowNumber < board.GetLength (0); rowNumber++) {
            if (board[rowNumber, col] == num) {
                return false;
            }
        }

        // find i,j where the box start 
        int sqrt = (int) Math.Sqrt (board.GetLength (0));
        int boxRowStart = row - row % sqrt;
        int boxColStart = col - col % sqrt;

        for (int r = boxRowStart; r < boxRowStart + sqrt; r++) {
            for (int d = boxColStart; d < boxColStart + sqrt; d++) {
                if (board[r, d] == num) {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool solveSudoku (int[, ] board, int n)

    {

        numberOfIterations += 1;
        Console.WriteLine ("----- Iteration number: " + numberOfIterations);
        print (board, board.GetLength (0));
        Console.WriteLine ();

        int row = 0;
        int col = 0;
        bool isEmpty = true;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i, j] == 0) {
                    row = i;
                    col = j;
                    // turn isEmpty to false because we still have missing values 
                    isEmpty = false;
                    break;
                }
            }

            if (!isEmpty) {
                break;
            }
        }

        // no empty space left   
        if (isEmpty) {
            return true;
        }

        for (int num = 1; num <= n; num++) {
            if (IsSafe (board, row, col, num)) {
                board[row, col] = num;

                if (solveSudoku (board, n)) {
                    return true;
                } else {
                    board[row, col] = 0; // replace it   
                }
            }
        }

        return false;

    }

    public static void linesRow (int N) {

        Console.WriteLine ();

        for (int emptyLineColumn = 0; emptyLineColumn < N; emptyLineColumn++) {
            if (emptyLineColumn == 0) {
                Console.Write (" --");
            } else if (emptyLineColumn == 8) {
                Console.Write ("--- ");
            } else {
                Console.Write ("--");
            }
        }

    }

    public static void print (int[, ] board, int N) {

        int column, row = 0;

        for (row = 0; row < N; row++) {

            if (row == 0) {
                linesRow (N);
                Console.WriteLine ();
            }

            for (column = 0; column < N; column++) {
                if (column == 0) {
                    Console.Write (" | " + board[row, column]);
                } else {
                    Console.Write (board[row, column]);
                }

                if (column % 3 == 2) {
                    Console.Write (" | ");
                }
            }

            if (row % 3 == 2) {
                linesRow (N);
            }

            Console.WriteLine ();

        }

    }

    public static void Main (String[] args) {

        int[, ] board = { { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
        };

        int N = board.GetLength (0);

        if (solveSudoku (board, N)) {
            Console.WriteLine ("Solution: ");
            print (board, N);
        } else {
            Console.WriteLine ("No solution");
        }

        Console.ReadKey ();

    }

}