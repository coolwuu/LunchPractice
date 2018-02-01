using System.Web;
using System.Web.Mvc;
using LunchSystem.Interface;
using LunchSystem.Repo;
using System.IO;

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

        public ActionResult Upload(HttpPostedFileBase file)
        {
            string imageName = Path.GetFileName(file.FileName);
            var folderPath = Path.Combine(Server.MapPath("~/Content/Image"), imageName);
            file.SaveAs(folderPath);
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Restaurant()
        {
            return View();
        }
    }
}