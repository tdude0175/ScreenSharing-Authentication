using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationApp.Models;
using System.Text.Encodings.Web;

namespace PresentationApp.Controllers
{
    public class HelloWorldController : Controller
    {

        //
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }


        //
        // GET: /HelloWorld/Welcome/
        public IActionResult Welcome(string name , int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        public string Test()
        {
            return "this is the test.";
        }
    }
}
