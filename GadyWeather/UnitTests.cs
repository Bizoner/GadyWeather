using NUnit.Framework;

namespace GadyWeather.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Sources.OpenWeather);
    
        [Test]
        public void TestGetWeatherDataByName()
        {
            Location loc = new Location();
            loc.CityName = "Dimona";
            loc.Country = "il";
            WeatherData weatherData = service.GetWeatherData(loc);
            Assert.That(weatherData.CityName, Is.EqualTo("Dimona"));
            Assert.That(weatherData.CityName, Is.Not.Null);
            Assert.That(weatherData.Temp, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.Humidity, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.WindSpeed, Is.GreaterThanOrEqualTo(0));
        }
        
        [Test]
        public void TestGetWeatherDataByCoordinates()
        {
            Location loc = new Location();
            loc.lat = 35;
            loc.lon = 139;
            WeatherData weatherData = service.GetWeatherData(loc);
            Assert.That(weatherData.CityName, Is.EqualTo("Shuzenji"));
            Assert.That(weatherData.CityName, Is.Not.Null);
            Assert.That(weatherData.Temp, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.Humidity, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.WindSpeed, Is.GreaterThanOrEqualTo(0));
        }
        
        [Test]
        public void TestGetWeatherDataByZipcode()
        {
            Location loc = new Location();
            loc.zipCode = 94040;
            loc.Country = "US";
            WeatherData weatherData = service.GetWeatherData(loc);
            Assert.That(weatherData.CityName, Is.EqualTo("Mountain View"));
            Assert.That(weatherData.CityName, Is.Not.Null);
            Assert.That(weatherData.Temp, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.Humidity, Is.GreaterThanOrEqualTo(0));
            Assert.That(weatherData.WindSpeed, Is.GreaterThanOrEqualTo(0));
        }
    }
}