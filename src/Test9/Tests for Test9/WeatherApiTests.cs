using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public sealed class WeatherApiTests
{
    [Fact]
    public async Task CheckWeatherOutput()
    {
        IOpenWeatherApi stubApi = new StubOpenWeatherApi();
        IWeatherService service = new WeatherService(stubApi);

        var cityName = "Bender";
        var actualResult = await service.GetWeatherServiceAsync(cityName);
        var expectedResult = "Город: Bender\nПогода: Солнечно\nТемпература: 15 °C\nСкорость ветра: 30 м/с";
        Assert.Equal(actualResult, expectedResult);
    }
}

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
    public async Task CheckCityBlockedListValidator(string input)
    {
        var validator = _provider.GetRequiredService<IWeatherService>();
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await validator.GetWeatherServiceAsync(input));
    }
    
    [Theory]
    [InlineData("  ")]
    [InlineData("")]
    public async Task CheckCityNameInput(string input)
    {
        var validator = _provider.GetRequiredService<IWeatherService>();
        await Assert.ThrowsAsync<ArgumentException>(async () => await validator.GetWeatherServiceAsync(input));
    }
}