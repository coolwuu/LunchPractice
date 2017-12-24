using System.Web.Mvc;
using LunchSystem.Interface;
using LunchSystem.Repo;

namespace LunchSystem.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
            LunchRepository = new LunchRepository();
        }

        public ILunchRepository LunchRepository { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            var meals = LunchRepository.GetOrderedMeals();
            return View(meals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(string memberName, string meal, string cost)
        {

            LunchRepository.Order(memberName, meal, cost);
            return RedirectToAction("Index");
        }
    }
}