using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook.Business.Abstract;
using PhoneBook.Core.Aspects.Postsharp.AuthorizationAspect;
using PhoneBook.Core.CrossCuttingConcerns.Security.Web;
using PhoneBook.Core.Entities.Concrete;

namespace PhoneBook.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Login()
        {

            return View();
        }
        // GET: Account
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = _accountService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(), user.UserName,
                    DateTime.Now.AddDays(15),
                    new[] { "Admin" },
                    false);
                Session["Account"] = user.UserName;
                return RedirectToAction("Index","Employee");
            }
            ViewBag.message = "User is not authenticated";
            return View();
        }
        public ActionResult ChangePassword()
        {
            if (Session["Account"] == null)
            {
                ViewBag.message = "You must login first.";
                return RedirectToAction("Login");
            }
            return View();
        }
        [SecuredOperation(Roles = "Admin")]
        [HttpPost]
        public ActionResult ChangePassword(string currentPassword, string password, string rePassword)
        {
            var userName = Session["Account"].ToString();
            var check = _accountService.GetByUserNameAndPassword(userName, currentPassword);
            if (check != null)
            {
                if (password == rePassword)
                {
                    var user = _accountService.GetByUserNameAndPassword(userName, currentPassword);
                    Account account = new Account()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Password = password
                    };
                    var newUser = _accountService.UpdatePassword(account);
                    if (newUser!=null)
                    {
                        ViewBag.message = "Your password is updated.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "Passwords do not match.";
                    return View();
                }
            }
            ViewBag.message = "Your current password is wrong.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Employee");
        }
    }
}