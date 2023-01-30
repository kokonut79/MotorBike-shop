using Microsoft.AspNetCore.Mvc;
using MotorbikeShop.Database;
using MotorbikeShop.Entities;
using MotorbikeShop.Models.ViewModels.CommentVm;
using MotorbikeShop.Models.ViewModels.MotorbikeVm;
using MotorbikeShop.Models.ViewModels.OrderVm;
using MotorbikeShop.Session;

namespace MotorbikeShop.Controllers
{
    public class OrderController : Controller
    {

        [HttpGet] 
        public IActionResult AllOrders(AllOrderVm model)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();
            // Takes all Orders and pass to view
            model.Orders = context.Orders.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult MyOrders(MyOrders model)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();

            //Takes curr logged user id
            var loggedUserId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            
            // Takes all Orders of curr logged user and pass to view

            model.motorbike = context.Orders.Where(x => x.UserId == loggedUserId).Select(x => x.Motorbike).ToList();
            var orders = context.Orders.Where(x => x.UserId == loggedUserId).ToList();
            model.Status = orders.Select(x => x.Status).ToList();
            model.OrderCount = orders;

            return View(model);
        }

        [HttpGet]
        public IActionResult MakeOrder(int id)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();

            //Takes curr logged user id
            var loggedUserId = HttpContext.Session.GetObject<User>("loggedUser").Id;

            //Creates new order

            Order newOrder = new Order();
            newOrder.UserId = loggedUserId;
            newOrder.MotorbikeId = id;
            newOrder.Status = "Processing";
            context.Orders.Add(newOrder);
            context.SaveChanges();

            return RedirectToAction(nameof(MyOrders));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();

            //Returns selected order and deletes from db
            var foundOrder = context.Orders.FirstOrDefault(x => x.Id == id);

            context.Orders.Remove(foundOrder);
            context.SaveChanges();

            //returns to myOrders
            return RedirectToAction(nameof(MyOrders));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();

            //Returns selected order and deletes from db 
            var foundOrder = context.Orders.FirstOrDefault(x => x.Id == id);

            context.Orders.Remove(foundOrder);
            context.SaveChanges();

            //returns to AllOrders
            return RedirectToAction(nameof(AllOrders));
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            MotorbikeDbContext context = new MotorbikeDbContext();

            //Take selected Order and change its status
            var foundOrder = context.Orders.FirstOrDefault(x => x.Id == order.Id);

            foundOrder.Status = order.Status;

            context.Orders.Update(foundOrder);
            context.SaveChanges();

            //Returns to allOrders
            return RedirectToAction(nameof(AllOrders));
        }
    }
}
