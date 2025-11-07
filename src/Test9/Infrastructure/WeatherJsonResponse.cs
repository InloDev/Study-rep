using System.Text.Json.Serialization;

namespace Infrastructure;

public sealed record WeatherJsonResponse(TempInfoDto Main, Wind Wind, string? Name, WeatherResponse[] Weather);