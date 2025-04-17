using Microsoft.AspNetCore.Mvc;
using Project.Data;

using Project.Models;
using System.Net;

namespace Project.Controllers
{
    public class BouquetController : Controller
    {
        private myContext _context;
        private IWebHostEnvironment _env;
        public static List<Dictionary<string,string>> mycart=new List<Dictionary<string,string>>();
        public BouquetController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Ins_bouquet()
        {
            return View();
        }
        
        [HttpPost]
        
        public IActionResult Ins_bouquet(IFormFile image, Bouquet bqt)
        {
            string filename = Path.GetFileName(image.FileName);
            string filepath = Path.Combine(_env.WebRootPath, "images/"+filename);
            FileStream fs = new FileStream(filepath, FileMode.Create);
            image.CopyTo(fs);
            bqt.image = filename;
            _context.Bouquets.Add(bqt);
            _context.SaveChanges();
            return RedirectToAction("Showbqt");
        }
        public IActionResult Showbqt()
        {
            if (HttpContext.Session.GetString("User_role") == "admin")
            {
                var students = _context.Bouquets.ToList();
                return View(students);
            }
            else { return RedirectToAction("Error", "Exception"); }
        }
        public IActionResult deletebouquets(int id)
        {
            var bouquets = _context.Bouquets.Find(id);
            _context.Bouquets.Remove(bouquets);
            _context.SaveChanges();
            return RedirectToAction("Showbqt");
        }
        public IActionResult editbouquets(int id)
        {
            var bouquets = _context.Bouquets.Find(id);
            return View(bouquets);
        }
        [HttpPost]
        public IActionResult editbouquets(Bouquet std)
        {
            _context.Bouquets.Update(std);
            _context.SaveChanges();
            return RedirectToAction("Showbqt");
        }
        public IActionResult Detailpage(int id)
        {
            List<Bouquet> bqts = _context.Bouquets.ToList();
            Bouquet bqt = bqts.Find(b=> b.id== id);
            //Bouquet bqt= (Bouquet)_context.Bouquets.Where(b => b.id == id);
            return View(bqt);
        }
        [HttpPost]
        public IActionResult addtocart(int id, string name, string price,string image, int qty)

        {
            if (HttpContext.Session.GetString("User_role") != null)
            { 
                mycart.Add(new Dictionary<string, string>());
            mycart[mycart.Count - 1].Add("id", id.ToString());
            mycart[mycart.Count - 1].Add("name", name);
            mycart[mycart.Count - 1].Add("price", price);
            mycart[mycart.Count - 1].Add("image", image);
            mycart[mycart.Count - 1].Add("qty", qty.ToString());
            return RedirectToAction("cart","Cart");
            }
            else
            {
                return RedirectToAction("Login", "Customer");
                    
                    }
        }

        }
}
