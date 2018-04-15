using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphWebApp.Models;
using GraphWebApp.Services;

namespace GraphWebApp.Controllers
{
    public class HomeController : Controller
    {
        private INeo4jService _neo4jService;

        public HomeController(INeo4jService neo4JService)
        {
            _neo4jService = neo4JService;   
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
