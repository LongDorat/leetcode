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
public double FindMedianSortedArray(int[] nums1, int[] nums2)
{
    List<int> merged = [];
    
    // Handle empty arrays case
    if (nums1.Length == 0 && nums2.Length == 0)
        return 0;
    
    // Merge the two sorted arrays
    int i = 0, j = 0;
    while (i < nums1.Length && j < nums2.Length)
    {
        if (nums1[i] <= nums2[j])
        {
            merged.Add(nums1[i]);
            i++;
        }
        else
        {
            merged.Add(nums2[j]);
            j++;
        }
    }
    
    // Add remaining elements
    while (i < nums1.Length)
    {
        merged.Add(nums1[i]);
        i++;
    }
    
    while (j < nums2.Length)
    {
        merged.Add(nums2[j]);
        j++;
    }
    
    // Find median
    int totalLength = merged.Count;
    if (totalLength % 2 == 0)
    {
        return (merged[totalLength / 2 - 1] + merged[totalLength / 2]) / 2.0;
    }
    else
    {
        return merged[totalLength / 2];
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
public double FindMedianSortedArray(int[] nums1, int[] nums2)
{
    // Ensure nums1 is the smaller array
    if (nums1.Length > nums2.Length)
        return FindMedianSortedArray(nums2, nums1);
    
    int m = nums1.Length;
    int n = nums2.Length;
    int low = 0, high = m;
    
    while (low <= high)
    {
        int cut1 = (low + high) / 2;
        int cut2 = (m + n + 1) / 2 - cut1;
        
        int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
        int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
        
        int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
        int right2 = cut2 == n ? int.MaxValue : nums2[cut2];
        
        if (left1 <= right2 && left2 <= right1)
        {
            if ((m + n) % 2 == 0)
                return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
            else
                return Math.Max(left1, left2);
        }
        else if (left1 > right2)
            high = cut1 - 1;
        else
            low = cut1 + 1;
    }
    
    return 1.0;
}
```

**Pros:** Optimal time complexity, constant space
**Cons:** More complex implementation

### Approach 3: Two Pointers (Space Optimized)

**Time Complexity:** O(m + n)
**Space Complexity:** O(1)

Instead of creating a merged array, we can use two pointers and stop when we reach the median:

```csharp
public double FindMedianSortedArray(int[] nums1, int[] nums2)
{
    int m = nums1.Length, n = nums2.Length;
    int total = m + n;
    int target = total / 2;
    
    int i = 0, j = 0, current = 0, previous = 0;
    
    for (int count = 0; count <= target; count++)
    {
        previous = current;
        
        if (i < m && (j >= n || nums1[i] <= nums2[j]))
        {
            current = nums1[i];
            i++;
        }
        else
        {
            current = nums2[j];
            j++;
        }
    }
    
    if (total % 2 == 0)
        return (previous + current) / 2.0;
    else
        return current;
}
```

**Pros:** No extra space for merged array
**Cons:** Still O(m + n) time complexity

## 🧠 Algorithm Explanation

### Merge Approach (Step by Step):

1. **Handle Edge Cases**: Check for empty arrays
2. **Initialize**: Create pointers for both arrays and a merged list
3. **Merge**: Compare elements from both arrays and add smaller one to merged list
4. **Add Remaining**: Add any remaining elements from either array
5. **Find Median**: 
   - If total length is even: average of two middle elements
   - If total length is odd: middle element

### Why This Works:

- Merging two sorted arrays maintains the sorted order
- The median is always at the center of the sorted combined array
- For even length: median = (middle1 + middle2) / 2
- For odd length: median = middle element

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
- [X] Comprehensive unit tests added
- [ ] Binary search optimization pending
- [ ] Performance benchmarking pending

## 🏷️ Metadata

- **Difficulty**: Hard
- **Tags**: Array, Binary Search, Divide and Conquer
- **Source**: [4. Median of Two Sorted Arrays](https://leetcode.com/problems/median-of-two-sorted-arrays/)
