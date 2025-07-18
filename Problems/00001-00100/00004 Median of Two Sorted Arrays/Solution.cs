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
    double FindMedianSortedArrays_MergeArray(int[] num1, int[] num2);

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
    double FindMedianSortedArrays_BinarySearch(int[] nums1, int[] nums2);

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
    double FindMedianSortedArrays_TwoPointers(int[] nums1, int[] nums2);
}

public class Solution : ISolution
{
    public double FindMedianSortedArrays_MergeArray(int[] nums1, int[] nums2)
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

    public double FindMedianSortedArrays_BinarySearch(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;

        // Handle edge cases with empty arrays
        if (m == 0 && n == 0)
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

        if (n == 0)
        {
            if (m % 2 == 0)
                return (nums1[m / 2] + nums1[m / 2 - 1]) / 2.0;
            else
                return nums1[m / 2];
        }

        // Ensure nums1 is the smaller array
        if (m > n)
        {
            return FindMedianSortedArrays_BinarySearch(nums2, nums1);
        }

        int low = 0, high = m;
        int totalLeft = (m + n + 1) / 2;

        while (low <= high)
        {
            int cut1 = (low + high) / 2;
            int cut2 = totalLeft - cut1;

            int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
            int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];

            int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
            int right2 = cut2 == n ? int.MaxValue : nums2[cut2];

            if (left1 <= right2 && left2 <= right1)
            {
                if ((m + n) % 2 == 0)
                {
                    return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                }
                else
                {
                    return Math.Max(left1, left2);
                }
            }
            else if (left1 > right2)
            {
                high = cut1 - 1;
            }
            else
            {
                low = cut1 + 1;
            }
        }
        
        return 0.0; // This line should never be reached if inputs are valid
    }

    public double FindMedianSortedArrays_TwoPointers(int[] nums1, int[] nums2)
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
            return FindMedianSortedArrays_TwoPointers(nums2, nums1);

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