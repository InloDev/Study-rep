//Console.WriteLine("Введите название города: ");
//var cityName = Console.ReadLine();
//var apiKey = "65eed83ce86219a7eba772b95cccf376";

using Test9;

var cityName = "London";
var weather = await Infrastructure(cityName);
