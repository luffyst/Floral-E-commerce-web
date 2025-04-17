using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Controllers;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private myContext _context;
        private IWebHostEnvironment _env;
        public CustomerController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Home()
        {
          
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View(_context.Bouquets.ToList());
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Login(string uemail, string upassword)
        {
            var row = _context.Customers.FirstOrDefault(u => u.email == uemail);
            if (row != null && row.password == upassword)
            {
                HttpContext.Session.SetString("User_id", row.id.ToString()); 
              

                HttpContext.Session.SetString("User_role", row.role);


                if (row.role== "admin")
                {
                    return RedirectToAction("adminpanel", "Admin");
                }
                else
                {
                    return View("Home");
                }

                
            }
            else
            {
                ViewBag.message = "*Incorrect Email or Password*";
            }
            _context.SaveChanges();
            return View();
        }
        public IActionResult Logout()
        {
            BouquetController.mycart.Clear();
            HttpContext.Session.Remove("User_id");
            HttpContext.Session.Remove("User_role");
            return RedirectToAction("Home");
        }
    }
}
