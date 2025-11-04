using Infrastructure;

namespace Tests;

public class HttpRequestTests
{
    [Fact]
    public async Task CheckWeatherOutput()
    {
        IWeatherApi client = new StubHttpRequest();
        var cityName = "Bender";
        var result = await client.GetResponseAsync(cityName);
        var actualResult = result.GetDisplayInfo();
        var expectedResult = "Город: Bender\nПогода: Солнечно\nТемпература: 15 °C\nСкорость ветра: 30 м/с";
        Assert.Equal(actualResult, expectedResult);
    }

    [Theory]
    [InlineData("  ")]
    [InlineData("")]
    public async Task CheckCityNameInput(string input)
    {
        IWeatherApi client = new StubHttpRequest();
        await Assert.ThrowsAsync<Exception>(async () => await client.GetResponseAsync(input));
    }
}