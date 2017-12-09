using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using LoginReg.Models;

namespace LoginReg.Controllers
{  
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = ModelState.Values;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUser user)
        {
            List<Dictionary<string, object>> userList = new List<Dictionary<string, object>>();
            string logQuery = $"SELECT user_id, Password FROM user WHERE Email = '{user.LogEmail}'";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                // RegisterUser NewUser = new RegisterUser
                // {
                //     FirstName = user.FirstName,
                //     LastName = user.LastName,
                //     Email = user.Email,
                //     Password = user.Password,
                //     CFPassword = user.CFPassword
                // };

                string regQuery = $@"INSERT INTO user(FirstName, LastName, Email, Password, CFPassword) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}', '{user.CFPassword}')";
                _dbConnector.Query(regQuery);

                ViewBag.Success = "Success!";
                return View("Index");
            }
            else
            {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
        }
    }
}