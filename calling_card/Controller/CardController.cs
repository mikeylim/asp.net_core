using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace calling_card.Controllers
{
    public class CardController : Controller
    {
        [HttpGet]
        [Route("{firstName}/{lastName}/{age}/{color}")]
        public JsonResult Index(string firstName, string lastName, int age, string color)
        {
            var cardObject = new {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Color = color
            };
            return Json(cardObject);
        }
    }
}
