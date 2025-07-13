namespace Median_of_Two_Sorted_Arrays.Tests.Units;

public class MergeArrayTests : TestBase
{
    [Fact]
    public void FindMedianSortedArray_BothArraysEmpty_ReturnsZero()
    {
        // Arrange
        int[] nums1 = [];
        int[] nums2 = [];

        // Act
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

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
        double result = _solution.FindMedianSortedArrays_MergeArray(nums1, nums2);

        // Assert
        Assert.Equal(3, result);
    }
}
