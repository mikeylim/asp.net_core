using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers {
    
    public class HomeController : Controller {
        
        public HomeController() 
        {
            
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.ModelFields = ModelState.Values;
            return View();
        }
        
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string firstName, string lastName, string email, int age, string password)
        {
            User NewUser = new User {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Age = age,
                Password = password
            };
            
            // validation fails, redirect back to form
            if (TryValidateModel(NewUser))
            {
                return RedirectToAction("Success");
            }
            // otherwise validation passes, redirect to success
            else
            {
                ViewBag.ModelFields = ModelState.Values;
                return View("Index");
            }
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}