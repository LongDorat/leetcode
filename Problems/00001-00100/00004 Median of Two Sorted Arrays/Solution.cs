using System.Globalization;

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
    double FindMedianSortedArray_MergeArray(int[] num1, int[] num2);

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
    double FindMedianSortedArray_BinarySearch(int[] nums1, int[] nums2);

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
    double FindMedianSortedArray_TwoPointers(int[] nums1, int[] nums2);
}

public class Solution : ISolution
{
    public double FindMedianSortedArray_MergeArray(int[] nums1, int[] nums2)
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

    public double FindMedianSortedArray_BinarySearch(int[] nums1, int[] nums2)
    {
        return 0.0;
    }

    public double FindMedianSortedArray_TwoPointers(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        int totalSize = m + n;

        if (m + n == 0)
        {
            return 0.0;
        }

        if (m == 0)
        {
            if (n % 2 == 0)
                return (nums2[n / 2] + nums2[n / 2 - 1]) / 2.0;
            else
                return nums2[n / 2];
        }
        else if (n == 0)
            return FindMedianSortedArray_TwoPointers(nums2, nums1);

        int i = 0, j = 0;
        int prev = 0, curr = 0;

        for (int count = 0; count <= totalSize / 2; count++)
        {
            prev = curr;

            if (i < m && (j >= n || nums1[i] < nums2[j]))
            {
                curr = nums1[i];
                i++;
            }
            else
            {
                curr = nums2[j];
                j++;
            }
        }

        if (totalSize % 2 == 0)
        {
            return (prev + curr) / 2.0;
        }
        else
        {
            return curr;
        }
    }
}