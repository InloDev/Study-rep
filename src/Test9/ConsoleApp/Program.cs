using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();


services.AddTransient<HttpClient>();
services.AddTransient<IWeatherApi, WeatherApi>();
services.AddTransient<ICityRestrictionService, CityRestrictionService>();

var serviceProvider = services.BuildServiceProvider();
var cityRestrictionService = serviceProvider.GetRequiredService<ICityRestrictionService>();

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName))
        Console.WriteLine("Недопустимое название города!");
    else Console.WriteLine(await cityRestrictionService.GetWeatherAsync(cityName));
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}