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
}