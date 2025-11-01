using Infrastructure;

Console.Write("Напишите название города: ");
var cityName = Convert.ToString(Console.ReadLine());

IWeatherApi weatherApi = new HttpRequest(new HttpClient());
if (cityName != null)
{
    var weather = await weatherApi.GetResponseAsync(cityName);
    var weatherInfo = weather.PrintWeatherInfo();
    Console.WriteLine(weatherInfo);
}