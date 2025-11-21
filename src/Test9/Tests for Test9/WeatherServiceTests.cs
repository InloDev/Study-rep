using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public sealed class WeatherServiceTests
{
    private readonly ServiceProvider _provider;

    public WeatherServiceTests()
    {
        var services = new ServiceCollection();
        services.AddTransient<IOpenWeatherApi, StubOpenWeatherApi>();
        services.AddTransient<IWeatherService,WeatherService>();
        _provider = services.BuildServiceProvider();
    }

    [Theory]
    [InlineData("Кишинев")]
    [InlineData("N")]
    [InlineData("Киев")]
    public async Task CityBlockedList(string input)
    {
        var weatherService = _provider.GetRequiredService<IWeatherService>();
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await weatherService.GetWeatherInfoAsync(input));
    }
    
    [Theory]
    [InlineData("  ")]
    [InlineData("")]
    public async Task CityNameInput(string input)
    {
        var weatherService = _provider.GetRequiredService<IWeatherService>();
        await Assert.ThrowsAsync<ArgumentException>(async () => await weatherService.GetWeatherInfoAsync(input));
    }
    [Fact]
    public async Task WeatherOutput()
    {
        IOpenWeatherApi stubApi = new StubOpenWeatherApi();
        IWeatherService service = new WeatherService(stubApi);

        var cityName = "Bender";
        var actualResult = (await service.GetWeatherInfoAsync(cityName)).GetDisplayInfo();
        var expectedResult = "Город: TestCity\nПогода: Солнечно\nТемпература: 15 °C\nСкорость ветра: 30 м/с";
        Assert.Equal(actualResult, expectedResult);
    }
}