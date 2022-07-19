namespace UnderstandingDependencies.Api.Tests.Unit;

public class UserServiceTests
{
    private readonly UserService _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    public UserServiceTests()
    {
        _sut = new UserService(_userRepository);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        // Arrange
        _userRepository.GetAllAsync().Returns(Array.Empty<User>());

        // Act
        var users = await _sut.GetAllAsync();

        // Assert
        users.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAListOfUsers_WhenUsersExist()
    {
        // Arrange
        var expectedUsers = new[]
        {
            new User
            {
                Id = Guid.NewGuid(),
                FullName = "Nick Chapsas"
            }
        };
        _userRepository.GetAllAsync().Returns(expectedUsers);

        // Act
        var users = await _sut.GetAllAsync();

        // Assert
        users.Should().Contain(x => x.FullName == "Nick Chapsas");
    }
}