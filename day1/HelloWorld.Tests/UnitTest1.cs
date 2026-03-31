namespace HelloWorld.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("да", true)]
    [InlineData("Да", true)]
    [InlineData(" д ", true)]
    [InlineData("y", true)]
    [InlineData("yes", true)]
    [InlineData("нет", false)]
    [InlineData("", false)]
    public void ShouldRepeat_ReturnsExpectedResult(string answer, bool expected)
    {
        bool actual = AppLogic.ShouldRepeat(answer);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldRepeat_ReturnsFalse_ForNull()
    {
        bool actual = AppLogic.ShouldRepeat(null);
        Assert.False(actual);
    }

    [Theory]
    [InlineData("Аня", "Аня")]
    [InlineData("  Олег  ", "Олег")]
    public void NormalizeName_TrimsAndReturnsName(string input, string expected)
    {
        string actual = AppLogic.NormalizeName(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NormalizeName_ReturnsGuest_ForNull()
    {
        string actual = AppLogic.NormalizeName(null);
        Assert.Equal("Гость", actual);
    }
}