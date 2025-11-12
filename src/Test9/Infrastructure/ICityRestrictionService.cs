namespace Infrastructure;

public interface ICityRestrictionService
{
    Task<string> GetWeatherAsync(string cityName);
}