using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(AccountMember model)
        //{
        //    if (model != null && !string.IsNullOrEmpty(model.EmailAddress) && !string.IsNullOrEmpty(model.MemberPassword))
        //    {
        //        var user = _accountService.GetAccountByEmail(model.EmailAddress);

        //        if (user != null && user.MemberPassword == model.MemberPassword)
        //        {
        //            HttpContext.Session.SetString("UserId", user.MemberId);
        //            HttpContext.Session.SetString("Username", user.FullName);

        //            return RedirectToAction("Index", "Products");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid email or password.");
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Login(AccountMember model)
        {
            var user = _accountService.GetAccountByEmail(model.EmailAddress);

            if (user == null)
            {
                ViewBag.Error = "Email not found";
                return View(model);
            }

            if (user.MemberPassword != model.MemberPassword)
            {
                ViewBag.Error = "Wrong password";
                return View(model);
            }

            HttpContext.Session.SetString("UserId", user.MemberId ?? "");
            HttpContext.Session.SetString("Username", user.FullName ?? "");

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Clear();

            Response.Cookies.Delete(".AspNetCore.Session");

            return RedirectToAction("Login");
        }
    }
}
