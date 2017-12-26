using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using LunchSystem.Interface;
using LunchSystem.Models;
using LunchSystem.Repo;

namespace LunchSystem.Controllers
{
    public class AccountController : Controller
    {
        public ILunchRepository LunchRepository;
        public AccountController()
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
        public ActionResult Login(LoginViewModel viewModel)
        {
            try
            {
                viewModel.Valid();
                LunchRepository.Login(viewModel.LoginUsername, viewModel.LoginPassword);
                Session["auth"] = true;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                viewModel.Message = ex.Message;
            }
            
            return View("Index", viewModel);
        }

        public ActionResult Register(RegisterViewModel viewModel)
        {
            try
            {
                viewModel.Valid();
                LunchRepository.Register(viewModel.RegisterUsername, viewModel.RegisterPassword);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                viewModel.Message = ex.Message;
            }

            ViewData["Register"] = viewModel;
            return PartialView("Index");
        }
    }
}