using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MuhtarlıkOtomasyon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MuhtarlıkOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            string tcno = User.Identity.Name;
            var user = c.Users.FirstOrDefault(x => x.Tc_no == tcno);
            ViewData["user"] = user;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(User user)
        {
            var info = c.Users.FirstOrDefault(x => x.Tc_no == user.Tc_no && x.Şifre == user.Şifre);
            if (info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, info.Tc_no)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", new { tcno = info.Tc_no });
            }
            return View();
        }
        public IActionResult SignUp()
        {
            var groups = c.BloodGroups.ToList();
            ViewData["groups"] = groups;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                c.Users.Add(user);
                c.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [Authorize]
        public IActionResult AllBloodGroups()
        {
            string tcno = User.Identity.Name;
            var user = c.Users.FirstOrDefault(x => x.Tc_no == tcno);
            string mahalle = user.Mahalle;
            if (user != null)
            {
                var neighborhoodbloods = c.Users.Where(u => u.Tc_no != tcno && u.Mahalle == mahalle).ToList();
                ViewData["nghbld"] = neighborhoodbloods;
            }
            return View();
        }
        [Authorize]
        public IActionResult CardInfo()
        {
            string tcno = User.Identity.Name;
            var user = c.Users.FirstOrDefault(x => x.Tc_no == tcno);
            ViewData["user"] = user;
            return View();
        }
        public IActionResult AddressUpdate()
        {
            string tcno = User.Identity.Name;
            var user = c.Users.FirstOrDefault(x => x.Tc_no == tcno);
            ViewData["user"] = user;
            return View();
        }
        [HttpPost]
        public IActionResult AddressUpdate(User user)
        {
            string tcno = User.Identity.Name;
            var u = c.Users.FirstOrDefault(c => c.Tc_no == tcno);
            if (u != null)
            {
                u.Adres = user.Adres;
                u.Mahalle = user.Mahalle;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
