using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace String_to_Integer;

public interface ISolutions
{
    /// <summary>
    /// Converts a string to a 32-bit signed integer (atoi) with overflow handling.
    /// </summary>
    /// <param name="s">Input string to convert</param>
    /// <returns>32-bit signed integer representation, clamped to int.MinValue/int.MaxValue - 1 on overflow</returns>
    /// <remarks>Time: O(n), Space: O(1)</remarks>
    int myAtoi(string s);
}

public class Solutions : ISolutions
{
    public int myAtoi(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        s = s.Trim();

        if (string.IsNullOrEmpty(s))
            return 0;

        int index = 0;
        bool isNegative = false;

        if (s[index] == '-')
        {
            isNegative = true;
            index += 1;
        }
        else if (s[index] == '+')
            index += 1;

        int result = 0;
        while (index < s.Length && s[index] >= '0' && s[index] <= '9')
        {
            int digit = s[index] - '0';

            if (!isNegative && (result > int.MaxValue / 10 ||
            result == int.MaxValue / 10 && digit > 7))
            {
                return int.MaxValue;
            }
            else if (isNegative && (result > -(int.MinValue / 10) ||
            result == -(int.MinValue / 10) && digit > 8))
            {
                return int.MinValue;
            }

            result = result * 10 + digit;
            index++;
        }

        return isNegative ? -result : result;
    }
}