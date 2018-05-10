using EticaretV1.Model.Option;
using EticaretV1.UI.Areas.Member.Models;
using EticaretV1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EticaretV1.UI.Areas.Member.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Member/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("List", "Category", new { area = "Member" });
            }
            TempData["class"] = "custom-hide";

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.UyeKontrolu(credentials.UserName, credentials.Password))
                {
                    AppUser user = service.AppUserService.UyeAdındanBul(credentials.UserName);

                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    if (user.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    return RedirectToAction("List", "Category", new { area = "Member" });
                }
                else
                {

                    ViewData["hata"] = "Kullanıcı Adı veya Şifre Hatalı";
                    //return RedirectToAction("Login", "Account", new { area = "Member" });
                    return View();
                   
                }
            }
            TempData["class"] = "custom-show";
            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Member/Category/List");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUser user,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.Any(x => x.UserName == user.UserName)) ModelState.AddModelError("UserName", "Kullanıcı adı kullanımda");
                else
                {
                    user.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);
                    if (user.ImagePath == "0" || user.ImagePath == "1" || user.ImagePath == "2")
                        user.ImagePath = "~/Content/Images/avantaj.png";
                    user.Role = Role.Member;
                    service.AppUserService.Add(user);
                    return Redirect("/Member/Account/Login");
                }
            }

            return View(user);
        }

    }
}