using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC2.Models;
using CoreMVC2.Models.Entities;

namespace CoreMVC2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return  View();
        }

        public ViewResult Index2()
        {
            return View();
        }

        public ViewResult Index3()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
