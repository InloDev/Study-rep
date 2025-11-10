using Infrastructure;

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName))
    {
        Console.WriteLine("Недопустимое название города!");
    }
    else
    {
        IWeatherApi weatherApi = new WeatherApi(new HttpClient());
        var check = new BannedCitiesValidator(weatherApi);
        Console.WriteLine(await check.GetWeatherAsync(cityName));
    }
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}