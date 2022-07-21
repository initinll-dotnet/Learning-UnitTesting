namespace AdvancedTechniques.Tests.Unit;

public class LongRunningTests
{
    [Fact(Timeout = 2000)]
    public async Task Slowest()
    {
        await Task.Delay(3000);
    }
}
