using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Project.Data;


namespace Project.Controllers
{
    public class MessagesController : Controller
    {
        private myContext _context;
        
        public MessagesController(myContext context, IWebHostEnvironment env)
        {
            _context = context;
            
        }
        
            [HttpPost]
        public IActionResult ins_msg(Project.Models.Message messages)
        {
            _context.Messages.Add(messages);
            _context.SaveChanges();
            return RedirectToAction("Contact","Customer");
        }
        public IActionResult fetch_msg()
        {
            if (HttpContext.Session.GetString("User_role") == "admin")
            {
                var msg = _context.Messages.ToList();
                return View(msg);
            }
            else { return RedirectToAction("Error", "Exception"); }
            
        }
        public IActionResult delete_msg(int id)
        {
            var messages = _context.Messages.Find(id);
            _context.Messages.Remove(messages);
            _context.SaveChanges();
            return RedirectToAction("fetch_msg");
        }
    }
}
