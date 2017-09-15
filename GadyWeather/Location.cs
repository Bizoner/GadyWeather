namespace GadyWeather
{
    public class Location
    {
        public string CityName { get; set; } = null;
        public string Country { get; set; } = null;
        public float lon { get; set; } = -9999;
        public float lat { get; set; } = -9999;
        public int zipCode { get; set; } = -9999;
    }
}