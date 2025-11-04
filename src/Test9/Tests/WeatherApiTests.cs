using Infrastructure;

namespace Tests;

public sealed class WeatherApiTests
{
    [Fact]
    public async Task CheckWeatherOutput()
    {
        IWeatherApi client = new StubWeatherApi();
        var cityName = "Bender";
        var result = await client.GetAsync(cityName);
        var actualResult = result.GetDisplayInfo();
        var expectedResult = "Город: Bender\nПогода: Солнечно\nТемпература: 15 °C\nСкорость ветра: 30 м/с";
        Assert.Equal(actualResult, expectedResult);
    }

    [Theory]
    [InlineData("  ")]
    [InlineData("")]
    public async Task CheckCityNameInput(string input)
    {
        IWeatherApi client = new StubWeatherApi();
        await Assert.ThrowsAsync<ArgumentException>(async () => await client.GetAsync(input));
    }
}