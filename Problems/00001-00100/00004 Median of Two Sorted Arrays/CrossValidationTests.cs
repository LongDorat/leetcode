using Xunit;

namespace Median_of_Two_Sorted_Arrays;

public class CrossValidationTests : BaseUnitTest
{
    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test1()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 4];

        // Act
        double mergeResult = _solution.FindMedianSortedArray_MergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArray_BinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArray_TwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(mergeResult, binarySearchResult);
        Assert.Equal(mergeResult, twoPointersResult);
        Assert.Equal(2.5, mergeResult);
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test2()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4, 5];
        int[] nums2 = [6, 7, 8, 9, 10];

        // Act
        double mergeResult = _solution.FindMedianSortedArray_MergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArray_BinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArray_TwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(mergeResult, binarySearchResult);
        Assert.Equal(mergeResult, twoPointersResult);
        Assert.Equal(5.5, mergeResult);
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test3()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [1, 2, 3];

        // Act
        double mergeResult = _solution.FindMedianSortedArray_MergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArray_BinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArray_TwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(mergeResult, binarySearchResult);
        Assert.Equal(mergeResult, twoPointersResult);
        Assert.Equal(2, mergeResult);
    }
}
