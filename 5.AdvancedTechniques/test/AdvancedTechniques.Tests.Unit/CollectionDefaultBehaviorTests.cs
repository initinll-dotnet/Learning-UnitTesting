namespace AdvancedTechniques.Tests.Unit;

[Collection("MyCollectionFixture")]
public class CollectionDefaultBehaviorTests1
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly MyClassFixture _fixture;

    public CollectionDefaultBehaviorTests1(ITestOutputHelper testOutputHelper,
        MyClassFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = fixture;
    }

    [Fact]
    public void ExampleTest1()
    {
        _testOutputHelper.WriteLine($"The Guid was (Instance) : {_id}");
        _testOutputHelper.WriteLine($"The Guid was (Shared)   : {_fixture.Id}");
    }

    [Fact]
    public void ExampleTest2()
    {
        _testOutputHelper.WriteLine($"The Guid was (Instance) : {_id}");
        _testOutputHelper.WriteLine($"The Guid was (Shared)   : {_fixture.Id}");
    }
}

[Collection("MyCollectionFixture")]
public class CollectionDefaultBehaviorTests2
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly MyClassFixture _fixture;

    public CollectionDefaultBehaviorTests2(ITestOutputHelper testOutputHelper,
        MyClassFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = fixture;
    }

    [Fact]
    public void ExampleTest1()
    {
        _testOutputHelper.WriteLine($"The Guid was (Instance) : {_id}");
        _testOutputHelper.WriteLine($"The Guid was (Shared)   : {_fixture.Id}");
    }

    [Fact]
    public void ExampleTest2()
    {
        _testOutputHelper.WriteLine($"The Guid was (Instance) : {_id}");
        _testOutputHelper.WriteLine($"The Guid was (Shared)   : {_fixture.Id}");
    }
}
