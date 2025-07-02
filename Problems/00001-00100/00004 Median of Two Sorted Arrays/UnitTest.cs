using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Median_of_Two_Sorted_Arrays;

public class UnitTest
{
    private readonly ISolution _solution;

    public UnitTest()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }

    #region Merging Arrays - Tests

    [Fact]
    public void FindMedianSortedArray_BothArraysEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void FindMedianSortedArray_OneArrayEmpty_ReturnsMedianOfOtherArray()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [1, 2, 3];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindMedianSortedArray_SecondArrayEmpty_ReturnsMedianOfFirstArray()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_EvenTotalLength_ReturnsAverageOfMiddleElements()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_OddTotalLength_ReturnsMiddleElement()
    {
        // Arrange
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4, 5];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindMedianSortedArray_AllElementsInFirstArray_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4];
        int[] nums2 = [10, 20];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_AllElementsInSecondArray_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [10, 20];
        int[] nums2 = [1, 2, 3, 4];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_InterleavedArrays_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 3, 5];
        int[] nums2 = [2, 4, 6];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_DuplicateElements_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 2];
        int[] nums2 = [2, 3, 4];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindMedianSortedArray_NegativeNumbers_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [-5, -1, 0];
        int[] nums2 = [-3, 2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(-0.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_SingleElementArrays_ReturnsAverage()
    {
        // Arrange
        int[] nums1 = [1];
        int[] nums2 = [2];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(1.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_LargeArrays_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4, 5];
        int[] nums2 = [6, 7, 8, 9, 10];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void FindMedianSortedArray_DifferentSizes_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1];
        int[] nums2 = [2, 3, 4, 5];

        // Act
        double result = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3, result);
    }

    #endregion
    
    #region Binary Search Tests

    [Fact]
    public void FindMedianSortedArrayBinarySearch_BothArraysEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_OneArrayEmpty_ReturnsMedianOfOtherArray()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [1, 2, 3];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_SecondArrayEmpty_ReturnsMedianOfFirstArray()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_EvenTotalLength_ReturnsAverageOfMiddleElements()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_OddTotalLength_ReturnsMiddleElement()
    {
        // Arrange
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4, 5];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_LargeArrays_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4, 5];
        int[] nums2 = [6, 7, 8, 9, 10];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_NegativeNumbers_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [-5, -1, 0];
        int[] nums2 = [-3, 2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(-0.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayBinarySearch_SingleElementArrays_ReturnsAverage()
    {
        // Arrange
        int[] nums1 = [1];
        int[] nums2 = [2];

        // Act
        double result = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);

        // Assert
        Assert.Equal(1.5, result);
    }

    #endregion

    #region Two Pointers Tests

    [Fact]
    public void FindMedianSortedArrayTwoPointers_BothArraysEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_OneArrayEmpty_ReturnsMedianOfOtherArray()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [1, 2, 3];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_SecondArrayEmpty_ReturnsMedianOfFirstArray()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_EvenTotalLength_ReturnsAverageOfMiddleElements()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(2.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_OddTotalLength_ReturnsMiddleElement()
    {
        // Arrange
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4, 5];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_LargeArrays_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 3, 4, 5];
        int[] nums2 = [6, 7, 8, 9, 10];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_NegativeNumbers_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [-5, -1, 0];
        int[] nums2 = [-3, 2, 4];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(-0.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_SingleElementArrays_ReturnsAverage()
    {
        // Arrange
        int[] nums1 = [1];
        int[] nums2 = [2];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(1.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_InterleavedArrays_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 3, 5];
        int[] nums2 = [2, 4, 6];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(3.5, result);
    }

    [Fact]
    public void FindMedianSortedArrayTwoPointers_DuplicateElements_ReturnsCorrectMedian()
    {
        // Arrange
        int[] nums1 = [1, 2, 2];
        int[] nums2 = [2, 3, 4];

        // Act
        double result = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(2, result);
    }

    #endregion

    #region Cross-Method Validation Tests

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test1()
    {
        // Arrange
        int[] nums1 = [1, 3];
        int[] nums2 = [2, 4];

        // Act
        double mergeResult = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

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
        double mergeResult = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

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
        double mergeResult = _solution.FindMedianSortedArrayMergeArray(nums1, nums2);
        double binarySearchResult = _solution.FindMedianSortedArrayBinarySearch(nums1, nums2);
        double twoPointersResult = _solution.FindMedianSortedArrayTwoPointers(nums1, nums2);

        // Assert
        Assert.Equal(mergeResult, binarySearchResult);
        Assert.Equal(mergeResult, twoPointersResult);
        Assert.Equal(2, mergeResult);
    }

    #endregion
}
