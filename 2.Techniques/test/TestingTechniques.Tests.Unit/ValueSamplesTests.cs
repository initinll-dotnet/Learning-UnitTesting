namespace TestingTechniques.Tests.Unit;

public class ValueSamplesTests
{
    // sut => system under test
    private readonly ValueSamples _sut = new();

    [Fact]
    public void StringAssertionExample()
    {
        var fullname = _sut.FullName;

        fullname.Should().Be("Nick Chapsas");
        fullname.Should().NotBeEmpty();
        fullname.Should().StartWith("Nick");
        fullname.Should().EndWith("Chapsas");
    }

    [Fact]
    public void NumberAssertionExample()
    {
        var age = _sut.Age;

        age.Should().Be(21);
        age.Should().BePositive();
        age.Should().BeGreaterThanOrEqualTo(18);
        age.Should().BeInRange(18, 22);
    }

    [Fact]
    public void DateAssertionExample()
    {
        var date = _sut.DateOfBirth;

        date.Should().Be(new(2000, 6, 9));
    }

    [Fact]
    public void ObjectAssertionExample()
    {
        User expected = new()
        {
            FullName = "Nick Chapsas",
            Age = 21,
            DateOfBirth = new(2000, 6, 9)
        };

        var user = _sut.AppUser;

        user.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void EnumerableObjectAssertionExample()
    {
        User expected = new()
        {
            FullName = "Nick Chapsas",
            Age = 21,
            DateOfBirth = new(2000, 6, 9)
        };

        var users = _sut.Users.As<User[]>();

        users.Should().ContainEquivalentOf(expected);
        users.Should().HaveCount(3);
        users.Should().Contain(x => x.FullName.StartsWith("Nick") && x.Age > 5);
    }

    [Fact]
    public void EnumerableNumbersAssertionExample()
    {
        var numbers = _sut.Numbers.As<int[]>();

        numbers.Should().Contain(5);
    }

    [Fact]
    public void ExceptionThrownAssertionExample()
    {
        var calculator = new Calculator();

        Action result = () => calculator.Divide(1, 0);

        result
            .Should()
            .Throw<DivideByZeroException>()
            .WithMessage("Attempted to divide by zero.");
    }

    [Fact]
    public void EventRaisedAssertionExample()
    {
        var monitorSubject = _sut.Monitor();

        // raise event
        _sut.RaiseExampleEvent();

        // asset if event was raised
        monitorSubject.Should().Raise("ExampleEvent");
    }

    [Fact]
    public void TestingInternalMembersExample()
    {
        var number = _sut.InternalSecretNumber;

        number.Should().Be(42);
    }
}
