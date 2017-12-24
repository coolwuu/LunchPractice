using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchSystem.Interface;
using LunchSystem.Repo;

namespace LunchSystem.Controllers
{
    public class LoginController : Controller
    {
        private ILunchRepository _lunchRepository;

        public LoginController()
        {
            _lunchRepository = new LunchRepository();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string loginUserName, string loginPassword)
        {
            if (!_lunchRepository.AccountIsValid(loginUserName,loginPassword))
            {
               TempData["NeedRegister"] = true;
            }
            return RedirectToAction("Index");
        }
    }
}