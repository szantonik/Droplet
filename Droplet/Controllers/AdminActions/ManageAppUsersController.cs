using Droplet.Data;
using Droplet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Droplet.Controllers
{
    public class ManageAppUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageAppUsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: ManageAppUsersController
        [Route("/AdminActions/ManageAppUsers", Name ="appuserlist")]
        public async Task<IActionResult> Index()
        {
            var usersWithRoles = new List<UserViewModel>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault(); // Assuming each user has exactly one role

                usersWithRoles.Add(new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = role ?? "No role assigned"
                });
            }
            return View("~/Views/AdminActions/ManageAppusers/Index.cshtml", usersWithRoles);
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
