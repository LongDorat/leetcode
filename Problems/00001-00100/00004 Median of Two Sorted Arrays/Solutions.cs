using System.Globalization;

namespace Median_of_Two_Sorted_Arrays;

public interface ISolutions
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

public class Solutions : ISolutions
{
    public double FindMedianSortedArrays_MergeArray(int[] nums1, int[] nums2)
    {
        List<int> merged = []; // Store merged result

        // Handle edge case of both arrays being empty
        if (nums1.Length + nums2.Length == 0)
        {
            return 0.0;
        }

        int i = 0; // Pointer for nums1
        int j = 0; // Pointer for nums2

        // Merge two sorted arrays using two pointers
        while (i < nums1.Length || j < nums2.Length)
        {
            // If nums1 is exhausted, take from nums2
            if (i == nums1.Length)
            {
                merged.Add(nums2[j]);
                j++;
            }
            // If nums2 is exhausted, take from nums1
            else if (j == nums2.Length)
            {
                merged.Add(nums1[i]);
                i++;
            }
            else
            {
                // Take smaller element to maintain sorted order
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
                else // Equal elements: add both
                {
                    merged.Add(nums1[i]);
                    merged.Add(nums2[j]);
                    i++;
                    j++;
                }
            }
        }

        // Calculate median: average of middle two elements for even length,
        // middle element for odd length
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

        // If one array is empty, find median of the other
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

        // Ensure nums1 is the smaller array for efficiency
        if (m > n)
        {
            return FindMedianSortedArrays_BinarySearch(nums2, nums1);
        }

        int low = 0, high = m; // Binary search on the smaller array
        int totalLeft = (m + n + 1) / 2; // Number of elements on left side of median

        while (low <= high)
        {
            // Partition points: cut1 elements from nums1, cut2 from nums2
            int cut1 = (low + high) / 2;
            int cut2 = totalLeft - cut1;

            // Elements just left and right of partition points
            int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
            int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];

            int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
            int right2 = cut2 == n ? int.MaxValue : nums2[cut2];

            // Check if we found the correct partition
            if (left1 <= right2 && left2 <= right1)
            {
                // Correct partition found - calculate median
                if ((m + n) % 2 == 0)
                {
                    // Even total length: average of two middle elements
                    return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                }
                else
                {
                    // Odd total length: larger of the two left elements
                    return Math.Max(left1, left2);
                }
            }
            else if (left1 > right2)
            {
                // Too many elements from nums1, move left
                high = cut1 - 1;
            }
            else
            {
                // Too few elements from nums1, move right
                low = cut1 + 1;
            }
        }

        return 0.0; // This line should never be reached if inputs are valid
    }

    public double FindMedianSortedArrays_TwoPointers(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        int totalSize = m + n;

        // Handle edge case of both arrays being empty
        if (m + n == 0)
        {
            return 0.0;
        }

        // If one array is empty, find median of the other
        if (m == 0)
        {
            if (n % 2 == 0)
                return (nums2[n / 2] + nums2[n / 2 - 1]) / 2.0;
            else
                return nums2[n / 2];
        }
        else if (n == 0)
            return FindMedianSortedArrays_TwoPointers(nums2, nums1);

        int i = 0, j = 0; // Pointers for nums1 and nums2
        int prev = 0, curr = 0; // Track current and previous elements

        /* We only need to iterate until we reach the median position(s).
           For even total size, we need elements at positions totalSize/2-1 and totalSize/2
           For odd total size, we need element at position totalSize/2 */
        for (int count = 0; count <= totalSize / 2; count++)
        {
            prev = curr; // Store previous element for even-length case

            // Choose smaller element from current positions in both arrays
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

        // Calculate median based on total size
        if (totalSize % 2 == 0)
        {
            // Even length: average of two middle elements
            return (prev + curr) / 2.0;
        }
        else
        {
            // Odd length: the middle element
            return curr;
        }
    }
}