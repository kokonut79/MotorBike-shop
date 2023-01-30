using System.ComponentModel.DataAnnotations.Schema;

namespace MotorbikeShop.Entities
{
    public class Motorbike
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Price{ get; set; }
        public string YearOfProduction { get; set; }
    }
}
