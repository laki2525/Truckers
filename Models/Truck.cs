using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truckers.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public City? CityFrom { get; set; }
        public City? CityTo { get; set; }
        public string? CityCurrent { get; set; }
        public Delivery? Delivery { get; set; }
        public string? GotDelivery { get; set; }

        public Truck() { }
    }
}
