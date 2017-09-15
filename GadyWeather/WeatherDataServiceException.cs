using System;

namespace GadyWeather
{
    public class WeatherDataServiceException : ApplicationException
    {
        public WeatherDataServiceException(string str) : base(str)
        {

        }
    }
}