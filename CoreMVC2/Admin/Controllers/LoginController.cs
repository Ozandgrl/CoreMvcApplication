using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC2.Admin.Models.DbLayer;
using CoreMVC2.Admin.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC2.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Logon model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.Select(x => x.UserCode == model.UserCode && x.Password == model.Password);
                if (user == null)
                {
                    return NotFound();
                }
                if (user != null)
                {
                    //HttpContext.Session.Set["AdminUser", user];
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı ve / veya Şifre Hatalı");
                    //Log Atılacak
                    TempData["Alert"] = "true";
                }
            }
            else
            {
                TempData["Alert"] = "true";
            }
            return View();

        }

        public ActionResult Logout()
        {
            //Session.Abandon();
            //Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}