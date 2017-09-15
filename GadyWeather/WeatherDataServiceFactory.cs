namespace GadyWeather
{
    public class WeatherDataServiceFactory
    {
        public enum Sources
        {
            OpenWeather
        }

        public static IWeatherDataService getWeatherDataService(Sources source)
        {
            if (source == Sources.OpenWeather)
            {
                return OpenWeather.Instance;
            }
            else
            {
                return null;
            }
        }
    }
}