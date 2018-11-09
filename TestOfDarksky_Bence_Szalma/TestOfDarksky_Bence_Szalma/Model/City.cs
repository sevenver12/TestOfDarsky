namespace TestOfDarksky_Bence_Szalma.Model
{
    public class City : GeoLoc
    {
        public City()
        {

        }
        public City(string name, double lon, double lat, Country country)
        {
            FName = name;
            Lon = lon;
            Lat = lat;
            Country = country;
        }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public Country Country { get; set; }
    }
}
