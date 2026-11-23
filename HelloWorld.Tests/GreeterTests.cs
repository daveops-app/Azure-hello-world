using Xunit;

public class GreeterTests
{
    [Fact]
    public void GetMessage_ReturnsHelloWorld()
    {
        Assert.Equal("Hello, World!", Greeter.GetMessage());
    }
}
