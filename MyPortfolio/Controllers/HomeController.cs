using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
	    [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
	    [Route("/projects")]
        public IActionResult ShowProjects()
        {
            ViewBag.Title = TempData["Title"];
            ViewBag.Desc = TempData["Desc"];
            
            return View("Projects");
        }

        [HttpGet]
	    [Route("/contact")]
        public IActionResult ShowContact()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Email = TempData["Email"];
            ViewBag.Message =  TempData["Message"];

            return View("contact");
        }

        [HttpPost]
	    [Route("/AddProject")]
        public IActionResult AddAProject(string title, string desc)
        {
            TempData["Title"] = title;
            TempData["Desc"] = desc;

            return RedirectToAction("ShowProjects"); // method name
        }

        [HttpPost]
	    [Route("/AddContact")]
        public IActionResult AddAContact(string name, string email, string message)
        {
            TempData["Name"] = name;
            TempData["Email"] = email;
            TempData["Message"] = message;

            return RedirectToAction("ShowContact"); // method name
        }
    }
}