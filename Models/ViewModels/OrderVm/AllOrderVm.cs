using MotorbikeShop.Entities;

namespace MotorbikeShop.Models.ViewModels.OrderVm
{
    public class AllOrderVm
    {
        public List<Order> Orders { get; set; }
        public List<Motorbike> Motorbikes { get; set; }
    }
}
