using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {   
            // List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            return View();
        }

        [Route("/addQuotes")]
        [HttpPost]
        public IActionResult AddMyQuote(string name, string quote)
        {
            string addQuery = $"INSERT INTO users(name, quote, created_at) VALUES ('{name}', '{quote}', NOW())";
            _dbConnector.Query(addQuery);
            return RedirectToAction("ViewQuotes");
        }

        [Route("/quotes")]
        [HttpGet]
        public IActionResult ViewQuotes()
        {
            string getQuotesQuery = "SELECT name, quote, created_at FROM users ORDER BY created_at desc;";
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query(getQuotesQuery);
            ViewBag.users = AllUsers;
            return View("Quotes");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}