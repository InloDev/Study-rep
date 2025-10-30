namespace Application;

public class WeatherJsonResponce
{
    public Weather[] weather { get; set; }
    public Main main { get; set; }
    public Wind wind { get; set; }
    public string name { get; set; }

}
public class Weather
{
    public string main { get; set; }
    public string description { get; set; }
}
public class Main
{
    public double temp { get; set; }
}
public class Wind
{
    public double speed { get; set; }
}