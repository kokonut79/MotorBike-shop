using System.ComponentModel.DataAnnotations.Schema;

namespace MotorbikeShop.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MotorbikeId { get; set; }

        public string Status { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(MotorbikeId))]
        public Motorbike Motorbike { get; set; }
    }
}
