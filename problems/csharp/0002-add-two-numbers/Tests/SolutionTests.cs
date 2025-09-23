using Xunit;

namespace AddTwoNumbers.Tests;

public class AddTwoNumbersTests
{
    private readonly Solution _solution = new Solution();

    [Fact]
    public void BasicAddition_ShouldReturnCorrectSum()
    {
        // Arrange: 342 + 465 = 807 (represented as [2,4,3] + [5,6,4] = [7,0,8])
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(7, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(0, result.next.val);
        Assert.NotNull(result.next.next);
        Assert.Equal(8, result.next.next.val);
        Assert.Null(result.next.next.next);
    }

    [Fact]
    public void WithCarryOver_ShouldHandleCarryCorrectly()
    {
        // Arrange: 999 + 9999 = 10998 (represented as [9,9,9] + [9,9,9,9] = [8,9,9,0,1])
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(8, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(9, result.next.val);
        Assert.NotNull(result.next.next);
        Assert.Equal(9, result.next.next.val);
        Assert.NotNull(result.next.next.next);
        Assert.Equal(0, result.next.next.next.val);
        Assert.NotNull(result.next.next.next.next);
        Assert.Equal(1, result.next.next.next.next.val);
        Assert.Null(result.next.next.next.next.next);
    }

    [Fact]
    public void SingleDigits_ShouldReturnCorrectSum()
    {
        // Arrange: 5 + 5 = 10 (represented as [5] + [5] = [0,1])
        var l1 = new ListNode(5);
        var l2 = new ListNode(5);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(0, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(1, result.next.val);
        Assert.Null(result.next.next);
    }

    [Fact]
    public void DifferentLengths_ShouldHandleCorrectly()
    {
        // Arrange: 123 + 45 = 168 (represented as [3,2,1] + [5,4] = [8,6,1])
        var l1 = new ListNode(3, new ListNode(2, new ListNode(1)));
        var l2 = new ListNode(5, new ListNode(4));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(8, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(6, result.next.val);
        Assert.NotNull(result.next.next);
        Assert.Equal(1, result.next.next.val);
        Assert.Null(result.next.next.next);
    }

    [Fact]
    public void ZeroPlusNumber_ShouldReturnNumber()
    {
        // Arrange: 0 + 123 = 123 (represented as [0] + [3,2,1] = [3,2,1])
        var l1 = new ListNode(0);
        var l2 = new ListNode(3, new ListNode(2, new ListNode(1)));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(3, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(2, result.next.val);
        Assert.NotNull(result.next.next);
        Assert.Equal(1, result.next.next.val);
        Assert.Null(result.next.next.next);
    }

    [Fact]
    public void BothZero_ShouldReturnZero()
    {
        // Arrange: 0 + 0 = 0 (represented as [0] + [0] = [0])
        var l1 = new ListNode(0);
        var l2 = new ListNode(0);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(0, result.val);
        Assert.Null(result.next);
    }

    [Fact]
    public void LargeNumbers_ShouldHandleCorrectly()
    {
        // Arrange: 9876543210 + 1234567890 = 11111111100
        // [0,1,2,3,4,5,6,7,8,9] + [0,9,8,7,6,5,4,3,2,1] = [0,0,1,1,1,1,1,1,1,1,1]
        var l1 = new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, 
                  new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9))))))))));
        var l2 = new ListNode(0, new ListNode(9, new ListNode(8, new ListNode(7, new ListNode(6, 
                  new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1))))))))));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        var current = result;
        int[] expected = {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.NotNull(current);
            Assert.Equal(expected[i], current.val);
            current = current.next;
        }
        Assert.Null(current);
    }
}