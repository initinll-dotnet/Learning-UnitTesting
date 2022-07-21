namespace Users.Api.Tests.Unit;

public class UserControllerTests
{
    private readonly UserController _sut;
    private readonly IUserService _userService = Substitute.For<IUserService>();

    public UserControllerTests()
    {
        _sut = new UserController(_userService);
    }

    [Fact]
    public async Task GetById_ShouldReturnOkAndObject_WhenUserExists()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Nitin L"
        };
        var userResponse = user.ToUserResponse();

        _userService.GetByIdAsync(user.Id).Returns(user);

        // Act
        var result = (OkObjectResult) await _sut.GetById(user.Id);


        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeEquivalentTo(userResponse);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenUserDoesntExists()
    {
        // Arrange
        _userService.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = (NotFoundResult) await _sut.GetById(Guid.NewGuid());

        // Assert
        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetAll_ShouldReturnEmptyList_WhenNoUserExists()
    {
        // Arrange
        _userService.GetAllAsync().Returns(Enumerable.Empty<User>());

        // Act
        var result = (OkObjectResult) await _sut.GetAll();

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.As<IEnumerable<UserResponse>>().Should().BeEmpty();
    }

    [Fact]
    public async Task GetAll_ShouldReturnUsersResponse_WhenUsersExist()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Nitin L"
        };
        var users = new[] { user };
        var usersResponse = users.Select(x => x.ToUserResponse());

        _userService.GetAllAsync().Returns(users);

        // Act
        var result = (OkObjectResult) await _sut.GetAll();

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.As<IEnumerable<UserResponse>>().Should().BeEquivalentTo(usersResponse);
    }

    [Fact]
    public async Task Create_ShouldCreateUser_WhenCreateUserRequestIsValid()
    {
        // Arrange
        var createUserRequest = new CreateUserRequest
        {
            FullName = "Nitin L"
        };

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = createUserRequest.FullName
        };

        _userService.CreateAsync(Arg.Do<User>(x => user = x)).Returns(true);

        // Act
        var result = (CreatedAtActionResult) await _sut.Create(createUserRequest);
        var expectedUserResponse = user.ToUserResponse();

        // Assert
        result.StatusCode.Should().Be(201);
        result.Value.As<UserResponse>().Should().BeEquivalentTo(expectedUserResponse);
        result.RouteValues!["id"].Should().BeEquivalentTo(expectedUserResponse.Id);

        //result.Value
        //    .As<UserResponse>()
        //    .Should()
        //    .BeEquivalentTo(expectedUserResponse, option => option.Excluding(x => x.Id))
    }

    [Fact]
    public async Task Create_ShouldReturnBadRequest_WhenCreateUserRequestIsInvalid()
    {
        // Arrange
        _userService.CreateAsync(Arg.Any<User>()).Returns(false);

        // Act
        var result = (BadRequestResult) await _sut.Create(new CreateUserRequest());
        
        // Assert
        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task DeleteById_ShouldReturnOk_WhenUserIsDeleted()
    {
        // Arrange
        _userService.DeleteByIdAsync(Arg.Any<Guid>()).Returns(true);

        // Act
        var result = (OkResult) await _sut.DeleteById(Guid.NewGuid());

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task DeleteById_ShouldReturnNotFound_WhenUserIsNotDeleted()
    {
        // Arrange
        _userService.DeleteByIdAsync(Arg.Any<Guid>()).Returns(false);

        // Act
        var result = (NotFoundResult) await _sut.DeleteById(Guid.NewGuid());

        // Assert
        result.StatusCode.Should().Be(404);
    }
}
