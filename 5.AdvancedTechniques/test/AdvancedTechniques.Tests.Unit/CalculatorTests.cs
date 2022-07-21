using System.Collections;

namespace AdvancedTechniques.Tests.Unit;

public class CalculatorTests
{
    private readonly Calculator _sut = new();

    [Theory]
    //[InlineData(1, 1, 2)]
    //[InlineData(10, 10, 20)]
    //[InlineData(-1, 1, 0)]
    //[InlineData(1, -1, 0)]
    //[InlineData(-5, -5, -10)]
    [MemberData("AddTestData")]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int num1, int num2, int expected)
    {
        // Act
        var result = _sut.Add(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    //[InlineData(1, 1, 0)]
    //[InlineData(10, 10, 0)]
    //[InlineData(-1, 1, -2)]
    //[InlineData(1, -1, 2)]
    //[InlineData(-5, -5, 0)]
    [ClassData(typeof(CalculatorSubtractTestData))]
    public void Substract_ShouldSubstractTwoNumbers_WhenTwoNumbersAreIntegers(int num1, int num2, int expected)
    {
        // Act 
        var result = _sut.Subtract(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(10, 10, 100)]
    [InlineData(-1, -1, 1)]
    [InlineData(1, -1, -1)]
    [InlineData(-5, -5, 25)]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenTwoNumbersAreIntegers(int num1, int num2, int expected)
    {
        // Act
        var result = _sut.Multiply(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(10, 10, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(10, 5, 2)]
    [InlineData(-5, -5, 1)]
    [InlineData(0, 0, 0)]
    public void Divide_ShouldDivideTwoNumbers_WhenTwoNumbersAreIntegers(int num1, int num2, int expected)
    {

        // Act
        var result = _sut.Divide(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ShouldThrowDivideByZeroException_WhenDividerIsZero()
    {
        // Act
        Action action = () => _sut.Divide(1, 0);
        var caughtException = Assert.Throws<DivideByZeroException>(() => action());

        // Assert
        Assert.Equal("Attempted to divide by zero.", caughtException.Message);
    }

    public static IEnumerable<object?[]> AddTestData => 
        new List<object[]>
        {
            new object[]{ 1, 1, 2  },
            new object[]{ 10, 10, 20 },
            new object[]{ -1, 1, 0 },
            new object[]{ 1, -1, 0 },
            new object[]{ -5, -5, -10 }
        };
}

public class CalculatorSubtractTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 1, 0 };
        yield return new object[] { 10, 10, 0 };
        yield return new object[] { -1, 1, -2 };
        yield return new object[] { 1, -1, 2 };
        yield return new object[] { -5, -5, 0 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
