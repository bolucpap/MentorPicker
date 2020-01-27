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
        Random rng=new Random();

        public IActionResult Index()
        {
            var mentees = new List<Mentee>() { 
                new Mentee() {Name="Ayşe",Ordinal=1 },
                new Mentee() {Name="Berna",Ordinal=2 },
                new Mentee() {Name="Buse",Ordinal=3 },
                new Mentee() {Name="Ceylan",Ordinal=4 },
                 };
            var mentors = new List<Mentor>(){
                new Mentor(){Name="Ali",MenteeCount=2, BannedMentes=new List<int>(){1}},
                new Mentor(){Name="Barış",MenteeCount=1, BannedMentes=new List<int>(){2,3}},
                new Mentor(){Name="Can",MenteeCount=1, BannedMentes=new List<int>(){4}}
            };
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
