namespace Truckers.Models
{
    public class Highway
    {
        public string? Name { get; set; }
        public int Distance { get; set; }
        public City? CityA { get; set; }
        public City? CityB { get; set; }
    }
}