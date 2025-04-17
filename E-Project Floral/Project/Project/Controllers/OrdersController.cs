using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Migrations;
using Project.Models;

namespace Project.Controllers
{
    public class OrdersController : Controller
    {
        private myContext _context;

        public static List<Dictionary<string, string>> mycart = BouquetController.mycart;
        public OrdersController(myContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult addorders(string deliveryaddress, string custId)
        {
            foreach (var order in mycart)
            {
                Order o = new Order();//int.Parse(HttpContext.Session.GetString("User_id").ToString()), int.Parse(order["id"]), int.Parse(order["qty"]),deliveryaddress,"pending"
                //Console.WriteLine(int.Parse(HttpContext.Session.GetString("User_id").ToString()));
                o.CustId = int.Parse(custId);
                o.BouqId = int.Parse(order["id"]);
                o.Quantity = int.Parse(order["qty"]);
                o.DiliveryAddress = deliveryaddress;
                o.Status = "pending";
                _context.Orders.Add(o);
                _context.SaveChanges();
            }
            
        
            return RedirectToAction("fetchOrder");
        
        }
            public IActionResult fetchOrder()
        {
            var orders = _context.Orders.Include(c => c.Bouquet).Include(c => c.Customer).ToList();
            return View(orders);
        }
        public IActionResult deleteOrder(int id)
        {
            var orders = _context.Orders.Find(id);
            _context.Orders.Remove(orders);
            _context.SaveChanges();
            return RedirectToAction("fetchOrder");
        }
    }
}
