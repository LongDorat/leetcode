using System.Text;

namespace ZigZag_Conversion;

public interface ISolutions
{
    /// <summary>
    /// Converts a string into a zigzag pattern on a given number of rows and reads it row by row - Row-by-Row Simulation
    /// </summary>
    /// <param name="s">The input string to be converted</param>
    /// <param name="numRows">The number of rows for the zigzag pattern</param>
    /// <returns>The string read line by line after zigzag conversion</returns>
    /// <remarks>Time Complexity: O(n), Space Complexity: O(n)</remarks>
    public string Convert_RowByRow(string s, int numRows);

    /// <summary>
    /// Converts a string into a zigzag pattern on a given number of rows and reads it row by row - Mathematical Pattern Calculation
    /// </summary>
    /// <param name="s">The input string to be converted</param>
    /// <param name="numRows">The number of rows for the zigzag pattern</param>
    /// <returns>The string read line by line after zigzag conversion</returns>
    /// <remarks>Time Complexity: O(n), Space Complexity: O(1)</remarks>
    public string Convert_Calculate(string s, int numRows);
}

public class Solutions : ISolutions
{
    public string Convert_RowByRow(string s, int numRows)
    {
        if (numRows == 1 || string.IsNullOrEmpty(s))
            return s;

        StringBuilder[] rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new StringBuilder();

        int currentRow = 0;
        bool goingDown = false;

        foreach (var c in s)
        {
            rows[currentRow].Append(c);

            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;

            currentRow += goingDown ? 1 : -1;
        }

        var result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }

    public string Convert_Calculate(string s, int numRows)
    {
        if (numRows == 1 || string.IsNullOrEmpty(s)) return s;

        StringBuilder result = new();
        int period = numRows * 2 - 2;

        for (int row = 0; row < numRows; row++)
        {
            int increment = row * 2;
            for (int i = row; i < s.Length; i += increment)
            {
                result.Append(s[i]);

                if (increment != period)
                    increment = period - increment;
            }
        }

        return result.ToString();
    }
}