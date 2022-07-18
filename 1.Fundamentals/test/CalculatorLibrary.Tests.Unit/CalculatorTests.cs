namespace CalculatorLibrary.Tests.Unit;

public class CalculatorTests
{
    private readonly Calculator _sut;

    public CalculatorTests()
    {
        _sut = new();
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(10, 10, 20)]
    [InlineData(-1, 1, 0)]
    [InlineData(1, -1, 0)]
    [InlineData(-5, -5, -10)]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int num1, int num2, int expected)
    {
        // Act
        var result = _sut.Add(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(10, 10, 0)]
    [InlineData(-1, 1, -2)]
    [InlineData(1, -1, 2)]
    [InlineData(-5, -5, 0)]
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
}

