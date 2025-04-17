using Microsoft.AspNetCore.Mvc;
using Project.Data;
namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private myContext _context;
        public AdminController(myContext context)
        {
            _context = context;
        }
        
            public IActionResult adminpanel()
        {
            if (HttpContext.Session.GetString("User_role") == "admin")
            {
                return View(adminpanel);
            }
            else
            {
                return RedirectToAction("Home","Customer");
            }
        }
    }
}
