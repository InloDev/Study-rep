using Infrastructure;

Console.Write("Напишите название города: ");
var cityName = Convert.ToString(Console.ReadLine());
var request = new HttpRequest(new HttpClient());
if (cityName != null) await request.GetResponseAsync(cityName);