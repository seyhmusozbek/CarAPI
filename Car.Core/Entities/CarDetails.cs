using Car.Core.Contracts;
using System;

namespace Car.Core.Entities
{
    public class CarDetails:IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Navigation { get; set; }
    }
}
