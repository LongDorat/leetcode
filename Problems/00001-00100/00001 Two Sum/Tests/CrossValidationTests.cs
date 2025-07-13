namespace Two_Sum.Tests;

public class CrossValidationTests : TestBase
{
    [Theory]
    [InlineData(new int[] { 1, 5, 3, 2, 9, 8 }, 10, new int[] { 0, 4 })]
    [InlineData(new int[] { 15, 2, 7, 8 }, 9, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void AllMethods_SameInput_ReturnSameResult(int[] nums, int target, int[] expected)
    {
        // Act
        var bruteForceResult = _solution.TwoSum_BruteForce(nums, target);
        var hashMapResult = _solution.TwoSum_Hashmap(nums, target);

        // Assert
        Assert.Equal(expected, bruteForceResult);
        Assert.Equal(expected, hashMapResult);
        Assert.Equal(bruteForceResult, hashMapResult);
    }
}
