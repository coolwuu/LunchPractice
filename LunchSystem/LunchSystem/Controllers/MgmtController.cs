using System.Web.Mvc;
using LunchSystem.Interface;
using LunchSystem.Repo;

namespace LunchSystem.Controllers
{
    public class MgmtController : Controller
    {
        public MgmtController()
        {
            LunchRepository = new LunchRepository();
        }
        public ILunchRepository LunchRepository { get; set; }
        public ActionResult Index()
        {
            var ordersSummaries = LunchRepository.GetOrdersSummary();
            return View(ordersSummaries);
        }
    }
}