using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LunchSystem.Interface;
using LunchSystem.Models;
using LunchSystem.Repo;

namespace LunchSystem.Controllers
{
    public class LoginController : Controller
    {
        public ILunchRepository LunchRepository;

        public LoginController()
        {
            LunchRepository = new LunchRepository();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                model.Valid();
                LunchRepository.AccountIsValid(model.LoginUsername);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index", model);
        }
    }
}