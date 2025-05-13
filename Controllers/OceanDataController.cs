using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OceanographyManager.Data;
using OceanographyManager.Models;

namespace OceanographyManager.Controllers
{
    [Authorize]
    public class OceanDataController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OceanDataController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var data = _context.OceanData
                .Where(d => d.UserId == user.Id)
                .ToList();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OceanData model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                model.UserId = user.Id;

                _context.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}