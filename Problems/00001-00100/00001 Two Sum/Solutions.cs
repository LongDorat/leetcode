namespace Two_Sum;

public interface ISolutions
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

public class Solutions : ISolutions
{
    public int[] TwoSum_BruteForce(int[] num, int target)
    {
        // Iterate through each element as the first number
        for (int i = 0; i < num.Length; i++)
        {
            // For each first number, check all remaining elements as the second number
            for (int j = i + 1; j < num.Length; j++)
            {
                // If the two numbers sum to target, return their indices
                if (num[i] + num[j] == target)
                {
                    return [i, j];
                }
            }
        }
        // Return empty array if no solution found (though problem guarantees one exists)
        return [];
    }

    public int[] TwoSum_Hashmap(int[] num, int target)
    {
        // Dictionary to store value -> index mapping for fast lookup
        var map = new Dictionary<int, int>();
        for (int i = 0; i < num.Length; i++)
        {
            // Calculate what number we need to reach the target
            int complement = target - num[i];
            // Check if the complement exists in our map (O(1) lookup)
            if (map.TryGetValue(complement, out int index))
            {
                // Found the pair: complement at 'index' and current number at 'i'
                return [index, i];
            }
            // Store current number and its index for future lookups
            map[num[i]] = i;
        }
        // Return empty array if no solution found (though problem guarantees one exists)
        return [];
    }
}