namespace Two_Sum;

public interface ISolution
{
    /// <summary>
    /// Finds two numbers in the array that add up to target using brute force approach.
    /// </summary>
    /// <param name="num">Array of integers</param>
    /// <param name="target">Target sum</param>
    /// <returns>Indices of the two numbers that sum to target</returns>
    /// <remarks>Time: O(n²), Space: O(1)</remarks>
    int[] TwoSum_BruteForce(int[] num, int target);
    /// <summary>
    /// Finds two numbers that add up to target using hash map for O(n) time complexity.
    /// </summary>
    /// <param name="num">Array of integers</param>
    /// <param name="target">Target sum</param>
    /// <returns>Indices of the two numbers that sum to target</returns>
    /// <remarks>Time: O(n), Space: O(n)</remarks>
    int[] TwoSum_Hashmap(int[] num, int target);
}

public class Solution : ISolution
{
    public int[] TwoSum_BruteForce(int[] num, int target)
    {
        for (int i = 0; i < num.Length; i++)
        {
            for (int j = i + 1; j < num.Length; j++)
            {
                if (num[i] + num[j] == target)
                {
                    return [i, j];
                }
            }
        }
        return [];
    }

    public int[] TwoSum_Hashmap(int[] num, int target)
    {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < num.Length; i++)
        {
            int complement = target - num[i];
            if (map.TryGetValue(complement, out int index))
            {
                return [index, i];
            }
            map[num[i]] = i;
        }
        return [];
    }
}