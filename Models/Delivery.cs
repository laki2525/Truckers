namespace Truckers.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Goods { get; set; }
        public string? Status { get; set; }
        public string? CityCurrent { get; set; }

        public Delivery() { }
    }
}
