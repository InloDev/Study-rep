using Infrastructure;

namespace Tests;

public sealed class WeatherApiTests
{
    [Fact]
    public async Task WeatherOutput()
    {
        IOpenWeatherApi stubApi = new StubOpenWeatherApi();
        IWeatherService service = new WeatherService(stubApi);

        var cityName = "Bender";
        var actualResult = (await service.GetWeatherInfoAsync(cityName)).GetDisplayInfo();
        var expectedResult = "Город: Bender\nПогода: Солнечно\nТемпература: 15 °C\nСкорость ветра: 30 м/с";
        Assert.Equal(actualResult, expectedResult);
    }
}