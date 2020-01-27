using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorPickerWeb.Models;

namespace MentorPickerWeb.Controllers
{
    public class HomeController : Controller
    {
        private List<Mentor> mentors=new List<Mentor>();
        public IActionResult Index()
        {
            mentors=new List<Mentor>(){new Mentor(){Name="Ali"},
            new Mentor(){Name="Veli"}};
            return View(mentors);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
