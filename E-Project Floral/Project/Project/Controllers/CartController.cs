using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using Project.Data;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        private myContext _context;
        public static List<Dictionary<string, string>> mycart = BouquetController.mycart;
        public CartController(myContext context)
        {
            _context = context;
        }
        public IActionResult cart()
        {
            if (HttpContext.Session.GetString("User_role") != null)
            {
                if (mycart != null)
                {
                    ViewBag.Cart = mycart;
                    return View();
                }
           
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }
            
        }
        public IActionResult deletecart(int id)
        {
            mycart.RemoveAt(id);
            return  RedirectToAction("cart");
            //return View(cart);
        }

        public IActionResult checkout()
        {
            //return a view for check out
            return View();
        }
    }
}
