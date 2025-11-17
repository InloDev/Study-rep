using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public sealed class WeatherApiTests
{
    [Fact]
    public async Task CheckWeatherOutput()
    {
        IWeatherApi client = new StubWeatherApi();
        var cityName = "Bender";
        var result = await client.GetWeatherApiAsync(cityName);
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
        await Assert.ThrowsAsync<ArgumentException>(async () => await client.GetWeatherApiAsync(input));
    }
}

public sealed class WeatherServiceTests
{
    private readonly ServiceProvider _provider;

    public WeatherServiceTests()
    {
        var services = new ServiceCollection();
        services.AddTransient<IWeatherApi, StubWeatherApi>();
        services.AddTransient<IWeatherService, WeatherService>();
        _provider = services.BuildServiceProvider();
    }

    [Theory]
    [InlineData("Кишинев")]
    [InlineData("N")]
    [InlineData("Киев")]
    public async Task CheckCityBlockedListValidator(string input)
    {
        var validator = _provider.GetRequiredService<IWeatherService>();
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await validator.GetWeatherServiceAsync(input));
    }
}