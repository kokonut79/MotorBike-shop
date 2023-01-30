using MotorbikeShop.Entities;

namespace MotorbikeShop.Models.ViewModels.OrderVm
{
    public class MyOrders
    {
        public List<Motorbike> motorbike{ get; set; }
        public List<string> Status { get; set; }
        public List<Order> OrderCount { get; set; }
    }
}
