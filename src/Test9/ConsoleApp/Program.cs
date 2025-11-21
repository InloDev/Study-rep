using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Refit;

IServiceCollection services = new ServiceCollection();

services.AddRefitClient<IOpenWeatherApi>().ConfigureHttpClient(client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});
services.AddTransient<IWeatherService, WeatherService>();

var serviceProvider = services.BuildServiceProvider();
var cityRestrictionService = serviceProvider.GetRequiredService<IWeatherService>();

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName))
        Console.WriteLine("Недопустимое название города!");
    else
    {
        var weatherInfo =(await cityRestrictionService.GetWeatherInfoAsync(cityName)).GetDisplayInfo();
        Console.WriteLine(weatherInfo);
    }
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}