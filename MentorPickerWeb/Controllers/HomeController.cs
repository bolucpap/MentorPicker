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
        Random rng = new Random();

        public IActionResult Index()
        {
            var mentees = new List<Mentee>() {
new Mentee() {Name="CAN SARI",Ordinal=1 },
new Mentee() {Name="ALİ CEM YÜCEBAĞ",Ordinal=2 },
new Mentee() {Name="MUHAMMED REHA KARLITEKİN",Ordinal=3 },
new Mentee() {Name="MELTEM GÜRSOY",Ordinal=4 },
new Mentee() {Name="NAZ AKSU",Ordinal=5 },
new Mentee() {Name="BEYZA BARLAS",Ordinal=6 },
new Mentee() {Name="SUMRU REYHAN KAYIKCI",Ordinal=7 },
new Mentee() {Name="MUSTAFA ERGİN KARACAN",Ordinal=8 },
new Mentee() {Name="FIRAT OĞULCAN UYSALOL",Ordinal=9 },
new Mentee() {Name="FATMA SENA DEMİRKIR ŞAHİN",Ordinal=10 },
new Mentee() {Name="ZEYNEP NUR KAYA",Ordinal=11 },
new Mentee() {Name="MERVE KORUKLUOĞLU",Ordinal=12 },
new Mentee() {Name="GÜLDEN ÇELİK",Ordinal=13 },
new Mentee() {Name="DUHAN KULUNÇKIRAN",Ordinal=14 },
new Mentee() {Name="ESAT YALÇIN",Ordinal=15 },
                 };
            var mentors = new List<Mentor>(){
                new Mentor(){Name="EMİN ERDEVİR",MenteeCount=2, BannedMentes=new List<int>(){4,5}},
                new Mentor(){Name="GÜLHİZ DEMİR",MenteeCount=2, BannedMentes=new List<int>(){6,7}},
                new Mentor(){Name="TAHSİN İSTANBULLU",MenteeCount=2, BannedMentes=new List<int>(){1,2,3,8,9}},
                new Mentor(){Name="MURAT DEMİRBİLEK",MenteeCount=2, BannedMentes=new List<int>(){}},
                new Mentor(){Name="SİNAN ONUR ÖZTUNA",MenteeCount=1, BannedMentes=new List<int>(){}},
                new Mentor(){Name="SELİM ÇALIŞKAN",MenteeCount=1, BannedMentes=new List<int>(){1,2,3}},
                new Mentor(){Name="ABDULLAH MUSLU",MenteeCount=1, BannedMentes=new List<int>(){1,2,3}},
                new Mentor(){Name="İLKER ERDUYAN",MenteeCount=1, BannedMentes=new List<int>(){1,2,3}},
                new Mentor(){Name="ZEHRA FİLİZ KOÇHAN",MenteeCount=1, BannedMentes=new List<int>(){4,5}},                                                                
                new Mentor(){Name="CİHANGİR ÇETİNTIRNAK",MenteeCount=1, BannedMentes=new List<int>(){10,11,12,13}},
                new Mentor(){Name="KAFİYE ŞAHİNER",MenteeCount=1, BannedMentes=new List<int>(){10,11,12,13}},


            };
            bool done = false;
            int tryCount = 0;
            while (!done && tryCount < 5)
            {
                try
                {
                    pickMentees(mentors, mentees);
                    done = true;
                }
                catch (Exception excp)
                {
                    foreach (var mentor in mentors)
                    {
                        mentor.Mentees.Clear();
                    }
                    tryCount++;
                }
            }
            return View(mentors);
        }

        private void pickMentees(List<Mentor> mentors, List<Mentee> mentees)
        {
            var unpickedMentees = mentees.ToList();
            foreach (var mentor in mentors)
            {
                while (mentor.Mentees.Count < mentor.MenteeCount)
                {
                    var menteePick = unpickedMentees.Where(mnt => !mentor.BannedMentes.Contains(mnt.Ordinal)).OrderBy(dummy => rng.Next()).First();
                    mentor.Mentees.Add(menteePick);
                    unpickedMentees.Remove(menteePick);
                }
            }

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
