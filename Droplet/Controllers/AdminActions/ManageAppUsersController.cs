using Droplet.Data;
using Droplet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Droplet.Controllers
{
    public class ManageAppUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageAppUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageAppUsersController
        [Route("/AdminActions/ManageAppUsers", Name ="appuserlist")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.AppUsers
                .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
                .Join(_context.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur.u.Id, ur.u.UserName, ur.u.Email, Role = r.Name })
                .Select(uv => new UserViewModel
                {
                    Id = uv.Id,
                    Username = uv.UserName,
                    Email = uv.Email,
                    Role = uv.Role
                })
                .ToListAsync();
            return View("~/Views/AdminActions/ManageAppusers/Index.cshtml", users);
        }

        // GET: ManageAppUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageAppUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageAppUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageAppUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageAppUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageAppUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageAppUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
