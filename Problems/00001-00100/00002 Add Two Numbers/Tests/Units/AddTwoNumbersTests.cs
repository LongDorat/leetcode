namespace Add_Two_Numbers.Tests.Units;

public class AddTwoNumbersTests : TestBase
{
    [Fact]
    public void Test1_BasicAddition_TwoDigitNumbers()
    {
        // Arrange: [2,4,3] + [5,6,4] = [7,0,8] (342 + 465 = 807)
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(7, result.val);
        Assert.Equal(0, result.next?.val);
        Assert.Equal(8, result.next?.next?.val);
        Assert.Null(result.next?.next?.next);
    }

    [Fact]
    public void Test2_AdditionWithCarry_ResultHasExtraDigit()
    {
        // Arrange: [9,9,9,9,9,9,9] + [9,9,9,9] = [8,9,9,9,0,0,0,1]
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(8, result.val);
        Assert.Equal(9, result.next?.val);
        Assert.Equal(9, result.next?.next?.val);
        Assert.Equal(9, result.next?.next?.next?.val);
        Assert.Equal(0, result.next?.next?.next?.next?.val);
        Assert.Equal(0, result.next?.next?.next?.next?.next?.val);
        Assert.Equal(0, result.next?.next?.next?.next?.next?.next?.val);
        Assert.Equal(1, result.next?.next?.next?.next?.next?.next?.next?.val);
    }

    [Fact]
    public void Test3_SingleDigitAddition_NoCarry()
    {
        // Arrange: [2] + [3] = [5]
        var l1 = new ListNode(2);
        var l2 = new ListNode(3);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(5, result.val);
        Assert.Null(result.next);
    }

    [Fact]
    public void Test4_SingleDigitAddition_WithCarry()
    {
        // Arrange: [5] + [5] = [0,1] (5 + 5 = 10)
        var l1 = new ListNode(5);
        var l2 = new ListNode(5);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(0, result.val);
        Assert.Equal(1, result.next?.val);
        Assert.Null(result.next?.next);
    }

    [Fact]
    public void Test5_DifferentLengths_FirstListLonger()
    {
        // Arrange: [1,2,3] + [4,5] = [5,7,3] (321 + 54 = 375)
        var l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
        var l2 = new ListNode(4, new ListNode(5));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(5, result.val);
        Assert.Equal(7, result.next?.val);
        Assert.Equal(3, result.next?.next?.val);
        Assert.Null(result.next?.next?.next);
    }

    [Fact]
    public void Test6_DifferentLengths_SecondListLonger()
    {
        // Arrange: [1,2] + [3,4,5] = [4,6,5] (21 + 543 = 564)
        var l1 = new ListNode(1, new ListNode(2));
        var l2 = new ListNode(3, new ListNode(4, new ListNode(5)));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(4, result.val);
        Assert.Equal(6, result.next?.val);
        Assert.Equal(5, result.next?.next?.val);
        Assert.Null(result.next?.next?.next);
    }

    [Fact]
    public void Test7_AdditionWithZero()
    {
        // Arrange: [0] + [0] = [0]
        var l1 = new ListNode(0);
        var l2 = new ListNode(0);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(0, result.val);
        Assert.Null(result.next);
    }

    [Fact]
    public void Test8_AddZeroToNumber()
    {
        // Arrange: [1,2,3] + [0] = [1,2,3] (321 + 0 = 321)
        var l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
        var l2 = new ListNode(0);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(1, result.val);
        Assert.Equal(2, result.next?.val);
        Assert.Equal(3, result.next?.next?.val);
        Assert.Null(result.next?.next?.next);
    }

    [Fact]
    public void Test9_CarryPropagation()
    {
        // Arrange: [9,9] + [1] = [0,0,1] (99 + 1 = 100)
        var l1 = new ListNode(9, new ListNode(9));
        var l2 = new ListNode(1);

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(0, result.val);
        Assert.Equal(0, result.next?.val);
        Assert.Equal(1, result.next?.next?.val);
        Assert.Null(result.next?.next?.next);
    }

    [Fact]
    public void Test10_MultipleCarries()
    {
        // Arrange: [9,9,9] + [9,9,9] = [8,9,9,1] (999 + 999 = 1998)
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9)));

        // Act
        var result = _solution.AddTwoNumbers(l1, l2);

        // Assert
        Assert.Equal(8, result.val);
        Assert.Equal(9, result.next?.val);
        Assert.Equal(9, result.next?.next?.val);
        Assert.Equal(1, result.next?.next?.next?.val);
        Assert.Null(result.next?.next?.next?.next);
    }
}