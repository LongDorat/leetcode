namespace TwoSum;

public interface ISolutions
{
    /// <summary>
    /// Finds two numbers in the array that add up to the target using brute force approach
    /// </summary>
    /// <param name="nums">Array of integers to search through</param>
    /// <param name="target">Target sum value</param>
    /// <returns>Array containing the indices of the two numbers that add up to target, or empty array if no solution exists</returns>
    /// <remarks> Time Complexity: O(n²) | Space Complexity: O(1) </remarks>
    int[] TwoSum_BruteForce(int[] nums, int target);

    /// <summary>
    /// Finds two numbers in the array that add up to the target using hash table for O(n) lookup
    /// </summary>
    /// <param name="nums">Array of integers to search through</param>
    /// <param name="target">Target sum value</param>
    /// <returns>Array containing the indices of the two numbers that add up to target, or empty array if no solution exists</returns>
    /// <remarks> Time Complexity: O(n) | Space Complexity: O(n) </remarks>
    int[] TwoSum_HashTable(int[] nums, int target);
}

public class Solutions : ISolutions
{
    public int[] TwoSum_BruteForce(int[] nums, int target)
    {
        if (nums.Length == 0 || nums.Length == 1)
            return [];

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }
        return [];
    }

    public int[] TwoSum_HashTable(int[] nums, int target)
    {
        if (nums.Length == 0 || nums.Length == 1)
            return [];

        Dictionary<int, int> map = [];
        for (int i = 0; i < nums.Length; i++)
        {
            int argument = target - nums[i];
            if (map.TryGetValue(argument, out int index))
                return [index, i];
            map.TryAdd(nums[i], i);
        }
        return [];
    }
}