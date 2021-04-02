using FormApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FormApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string firstName, string lastName)
        {
            var form = new Form();
            form.firstName = firstName;
            form.lastName = lastName;


            string path = $"Data/ContactForm.txt.";

            if (!Directory.Exists($"./Data"))
            {
                DirectoryInfo dir = new DirectoryInfo($"./");
                dir.CreateSubdirectory("Data");
            }


            FileInfo f = new FileInfo(path);
            FileStream fs = f.Create();
            fs.Close();


            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("Imię: " + form.firstName);
                file.WriteLine("Nazwisko: " + form.lastName);
                file.WriteLine();

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
