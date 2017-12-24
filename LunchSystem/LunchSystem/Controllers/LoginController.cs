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
        public ILunchRepository _lunchRepository;

        public LoginController()
        {
            _lunchRepository = new LunchRepository();
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
                if (!_lunchRepository.AccountIsValid(model.LoginUsername))
                {
                    model.Message = "You need to register an account.";
                }
                
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index", model);
        }
    }
}