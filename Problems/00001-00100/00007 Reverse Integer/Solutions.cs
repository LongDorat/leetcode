namespace Reverse_Integer;

public interface ISolutions
{
    /// <summary>
    /// Reverses the digits of a 32-bit signed integer. Returns 0 if the reversed integer overflows.
    /// </summary>
    /// <param name="x">The integer to reverse</param>
    /// <returns>The reversed integer, or 0 if overflow occurs</returns>
    /// <remarks>Time Complexity: O(log n), Space Complexity: O(1)</remarks>
    int Reverse(int x);
}

public class Solutions : ISolutions
{
    public int Reverse(int x)
    {
        int result = 0;
        while (x != 0)
        {
            int digit = x % 10;
            x /= 10;

            if (result > int.MaxValue / 10 ||
                (result == int.MaxValue / 10 && digit > 7))
            {
                return 0;
            }
            if (result < int.MinValue / 10 ||
                (result == int.MinValue / 10 && digit < -8))
            {
                return 0;
            }

            result = result * 10 + digit;
        }

        return result;
    }
}