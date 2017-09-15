namespace GadyWeather
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
    }
}