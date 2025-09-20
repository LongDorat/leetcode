namespace TwoSum;

public class Solution
{
    /// <summary>
    /// Finds two numbers in the array that add up to the target using a brute-force approach.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <param name="target">The target sum to find.</param>
    /// <returns>An array containing the indices of the two numbers that add up to the target, or [-1, -1] if not found.</returns>
    /// <remarks> Time Complexity: O(n^2), Space Complexity: O(1) </remarks>
    public int[] BruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [-1, -1];
    }

    /// <summary>
    /// Finds two numbers in the array that add up to the target using a hash table.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <param name="target">The target sum to find.</param>
    /// <returns>An array containing the indices of the two numbers that add up to the target, or [-1, -1] if not found.</returns>
    /// <remarks> Time Complexity: O(n), Space Complexity: O(n) </remarks>
    public int[] HashTable(int[] nums, int target)
    {
        Dictionary<int, int> hashTable = [];

        for (int i = 0; i < nums.Length; i++)
        {
            if (hashTable.ContainsKey(target - nums[i]))
            {
                return [hashTable[target - nums[i]], i];
            }
            hashTable.TryAdd(nums[i], i);
        }

        return [-1, -1];
    }
}
