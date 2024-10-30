using GameShop.Domain.Models;
using GameShop.Domain.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Implementations;
using Services.Implementations;
using Services.Interfaces;
using System.Security.Claims;

namespace GameShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public readonly BaseRepository<User> _userRepository;
        public AccountController(AccountService accountService, BaseRepository<User> userRepository)
        {
            _accountService = accountService;
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _accountService.Register(model);
                if (response.StatusCode == "OK")
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _accountService.LogIn(model);
                if (response.StatusCode == "OK")
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Profile()
        {
            var ThisUser = _userRepository.GetAll().FirstOrDefault(x => x.Name == User.Identity.Name);
            return View(ThisUser);
        }
        [HttpGet]
        [Authorize]
        public ActionResult ChangeThePassword()
        {
            //var ThisUser = _userRepository.GetAll().FirstOrDefault(x => x.Name == User.Identity.Name);
            //return View(ThisUser);
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangeThePassword(ChangeThePasswordViewModel changeThePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.ChangeThePassword(changeThePasswordViewModel);
                return RedirectToAction("Profile", "Account");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == User.Identity.Name);
            ViewBag.Name = user.Name;
            ViewBag.ProfileName = user.ProfileName;
            ViewBag.Surname = user.Surname;
            ViewBag.Patronymic = user.Patronymic;
            ViewBag.Email = user.Email;
            ViewBag.PhoneNumber = user.PhoneNumber; 
            ViewBag.CreditCard = user.CreditCard;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountService.EditTheProfile(editViewModel);
                return RedirectToAction("Profile", "Account");
            }
            return View();
        }
    }
}
