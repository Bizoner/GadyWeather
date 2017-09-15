using System;
using System.Linq;
using System.Xml.Linq;

namespace GadyWeather
{
    public class OpenWeather : IWeatherDataService
    {
        private static OpenWeather instance;
        private OpenWeather() { }
        
        public static OpenWeather Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OpenWeather();
                }
                return instance;
            }   
        }

        public WeatherData GetWeatherData(Location location)
        {
            string apiKey = "2c5fbd3b6ce46638d66da27e2d827607";
            string url = "http://api.openweathermap.org/data/2.5/weather?";
            string query = null;
            XDocument Response = null;
            WeatherData WeatherObj = new WeatherData();

            try
            {
                if (location.CityName != null && location.Country != null) {
                    
                    query = "q=" + location.CityName + "," + location.Country;
                    
                } else if ((location.lat != -9999) && (location.lon != -9999)) {
                    
                    query = "lat=" + location.lat + "&" + "lon=" + location.lon;
                    
                } else if (location.zipCode != -9999 && location.Country != null) {
                    
                    query = "zip=" + location.zipCode + "," + location.Country;
                    
                } else {
                    
                    throw new WeatherDataServiceException("Missing Paramaters");
                }
                
                Response = XDocument.Load(url+query+"&mode=xml&appid="+apiKey);
                
                var list = from item in Response.Descendants("current")
                    select new
                    {
                        Title = item.Element("weather").Attribute("value").Value,
                        CityName = item.Element("city").Attribute("name").Value,
                        Temp = item.Element("temperature").Attribute("value").Value,
                        Humidity = item.Element("humidity").Attribute("value").Value,
                        WindSpeed = item.Element("wind").Element("speed").Attribute("value").Value
                    };
                
                foreach (var item in list)
                {
                    WeatherObj.Title = item.Title;
                    WeatherObj.CityName = item.CityName;
                    WeatherObj.Temp = float.Parse(item.Temp);
                    WeatherObj.Humidity = float.Parse(item.Humidity);
                    WeatherObj.WindSpeed = float.Parse(item.WindSpeed); 
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return WeatherObj;
        }
    }
}