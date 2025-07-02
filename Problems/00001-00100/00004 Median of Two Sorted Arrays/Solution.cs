namespace Median_of_Two_Sorted_Arrays;

public interface ISolution
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// Merge approach implementation.
    /// </summary>
    /// <param name="num1">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <param name="num2">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <returns>
    /// Return the median of the two sorted arrays.
    /// </returns>
    /// <remarks>
    /// Time Complexity: O(m + n),
    /// Space Complexity: O(m + n), where m and n are the lengths of the two arrays.
    /// </remarks>
    double FindMedianSortedArrayMergeArray(int[] num1, int[] num2);

    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// Binary search approach implementation - optimal solution.
    /// </summary>
    /// <param name="nums1">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <param name="nums2">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <returns>
    /// Return the median of the two sorted arrays.
    /// </returns>
    /// <remarks>
    /// Time Complexity: O(log(min(m, n))),
    /// Space Complexity: O(1), where m and n are the lengths of the two arrays.
    /// </remarks>
    double FindMedianSortedArrayBinarySearch(int[] nums1, int[] nums2);

    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
    /// Two pointers approach implementation - space optimized.
    /// </summary>
    /// <param name="nums1">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <param name="nums2">
    /// Arrays of integers sorted in ascending order.
    /// </param>
    /// <returns>
    /// Return the median of the two sorted arrays.
    /// </returns>
    /// <remarks>
    /// Time Complexity: O(m + n),
    /// Space Complexity: O(1), where m and n are the lengths of the two arrays.
    /// </remarks>
    double FindMedianSortedArrayTwoPointers(int[] nums1, int[] nums2);
}

public class Solution : ISolution
{
    public double FindMedianSortedArrayMergeArray(int[] nums1, int[] nums2)
    {
        List<int> merged = [];

        if (nums1.Length + nums2.Length == 0)
        {
            return 0.0;
        }

        int i = 0;
        int j = 0;
        while (i < nums1.Length || j < nums2.Length)
        {
            if (i == nums1.Length)
            {
                merged.Add(nums2[j]);
                j++;
            }
            else if (j == nums2.Length)
            {
                merged.Add(nums1[i]);
                i++;
            }
            else
            {
                if (nums1[i] < nums2[j])
                {
                    merged.Add(nums1[i]);
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    merged.Add(nums2[j]);
                    j++;
                }
                else
                {
                    merged.Add(nums1[i]);
                    merged.Add(nums2[j]);
                    i++;
                    j++;
                }
            }
        }

        if (merged.Count % 2 == 0)
        {
            return (double)(merged[merged.Count / 2] + merged[merged.Count / 2 - 1]) / 2;
        }
        else
        {
            return merged[merged.Count / 2];
        }
    }

    public double FindMedianSortedArrayBinarySearch(int[] nums1, int[] nums2)
    {
        return 0.0;
    }

    public double FindMedianSortedArrayTwoPointers(int[] nums1, int[] nums2)
    {
        return 0.0;
    }
}