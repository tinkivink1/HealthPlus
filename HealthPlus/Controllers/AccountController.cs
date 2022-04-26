using HealthPlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }
        // GET: AccountController
        public ActionResult Account_homepage()
        {
            return View();
        }

        public async Task<IActionResult> Account()
        {
            return View(await db.clients.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            db.clients.Add(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Account");
        }



    }
}
