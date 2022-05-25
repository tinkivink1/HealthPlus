using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthPlus.Data;
using HealthPlus.Models;
using HealthPlus.Controllers;


namespace HealthPlus.Controllers
{
    public class UsersController : Controller
    {

        private readonly HealthPlusUsersContext _context;
        private int IdForAccount;
        public UsersController(HealthPlusUsersContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return _context.Users != null ?
                        View(await _context.Users.ToListAsync()) :
                        Problem("Entity set 'HealthPlusUsersContext.Users' is null.");
        }
        public IActionResult Registration()
        {
            return View();
        }

        public  IActionResult Account(Users users)
        {
            var usersList = _context.Users.Include(c => c.trainings).ToArray();
            foreach (var user in usersList)
                if (user.Id == users.Id)
                    users = new Users(user);
            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,client_name,client_surname,client_password,client_email,age")] Users users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,client_name,client_surname,client_password,client_email,age")] Users users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        public IActionResult Loginn(int id, [Bind("Id,client_name,client_surname,client_password,client_email,age")] Users users)
        {
            _context.Users.Add(users);
            var usersColl =  _context.Users.Select(b => b).ToList();
            for (int i = 0; i < usersColl.Count; i++)
            {
                if (users.client_email == usersColl[i].client_email && users.client_password == usersColl[i].client_password)
                {
                  
                    int id1 = usersColl[i].Id;
                    if (id1 == null || _context.Users == null)
                    {
                        return NotFound();
                    }

                    var users1 =  _context.Users.Find(id1);
                    
                    if (users == null)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Account), new Users(users1));
                }

            }

            return RedirectToAction(nameof(Registration));
        }



        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'HealthPlusUsersContext.Users'  is null.");
            }
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> AppendTrainings(int trainingID, int userID)
        {
            var training = await _context.Trainings.FindAsync(trainingID);
            Users user = await _context.Users.FindAsync(userID);
            user.trainings.Add(training);
            _context.Update(user);
            training.users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Account), new Users(user));
        }

    }
}
