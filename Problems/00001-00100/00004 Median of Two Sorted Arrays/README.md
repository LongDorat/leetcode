# 4. Median of Two Sorted Arrays

## 📝 Problem Description

Given two sorted arrays `nums1` and `nums2` of size `m` and `n` respectively, return **the median** of the two sorted arrays.

The overall run time complexity should be `O(log (m+n))`.

### Example 1:

```
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
```

### Example 2:

```
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
```

### Example 3:

```
Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000
```

### Example 4:

```
Input: nums1 = [], nums2 = [1]
Output: 1.00000
```

### Example 5:

```
Input: nums1 = [2], nums2 = []
Output: 2.00000
```

### Constraints:

- `nums1.length == m`
- `nums2.length == n`
- `0 <= m <= 1000`
- `0 <= n <= 1000`
- `1 <= m + n <= 2000`
- `-10^6 <= nums1[i], nums2[i] <= 10^6`

## 💡 Solution Approaches

### Approach 1: Merge and Find Median (Straightforward)

**Time Complexity:** O(m + n)
**Space Complexity:** O(m + n)

The straightforward approach is to merge both arrays and find the median:

```csharp
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
```

**Pros:** Simple and easy to understand
**Cons:** Not optimal time complexity, uses extra space

### Approach 2: Binary Search (Optimal)

**Time Complexity:** O(log(min(m, n)))
**Space Complexity:** O(1)

The optimal approach uses binary search to find the correct partition:

```csharp
public double FindMedianSortedArray_BinarySearch(int[] nums1, int[] nums2)
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
        return FindMedianSortedArray_BinarySearch(nums2, nums1);
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
```

**Pros:** Optimal time complexity, constant space
**Cons:** More complex implementation

### Approach 3: Two Pointers (Space Optimized)

**Time Complexity:** O(m + n)
**Space Complexity:** O(1)

Instead of creating a merged array, we can use two pointers and stop when we reach the median:

```csharp
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
```

**Pros:** No extra space for merged array
**Cons:** Still O(m + n) time complexity

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Best Case | Worst Case |
|----------|----------------|------------------|-----------|------------|
| Merge | O(m + n) | O(m + n) | O(m + n) | O(m + n) |
| Binary Search | O(log(min(m,n))) | O(1) | O(1) | O(log(min(m,n))) |
| Two Pointers | O(m + n) | O(1) | O(m + n) | O(m + n) |

## 🧪 Test Cases Covered

### Edge Cases:
- Both arrays empty: `[], []` → `0.0`
- One array empty: `[]`, `[1,2,3]` → `2.0`
- Single elements: `[1]`, `[2]` → `1.5`

### Normal Cases:
- Even total length: `[1,3]`, `[2,4]` → `2.5`
- Odd total length: `[1,2]`, `[3,4,5]` → `3.0`
- All elements in one array smaller: `[1,2,3,4]`, `[10,20]` → `3.5`

### Special Cases:
- Duplicate elements: `[1,2,2]`, `[2,3,4]` → `2.0`
- Negative numbers: `[-5,-1,0]`, `[-3,2,4]` → `-0.5`
- Large arrays: `[1,2,3,4,5]`, `[6,7,8,9,10]` → `5.5`

### Position Variations:
- Interleaved arrays: `[1,3,5]`, `[2,4,6]` → `3.5`
- Different sizes: `[1]`, `[2,3,4,5]` → `3.0`

## 💻 Current Status

- [X] Basic structure created
- [X] Merge approach implemented
- [X] Binary search approach implemented
- [X] Two pointers approach implemented
- [X] Comprehensive unit tests added
- [X] All implementations working and tested

## 🏷️ Metadata

- **Difficulty**: Hard
- **Tags**: Array, Binary Search, Divide and Conquer
- **Source**: [4. Median of Two Sorted Arrays](https://leetcode.com/problems/median-of-two-sorted-arrays/)
