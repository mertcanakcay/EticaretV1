using EticaretV1.Model.Option;
using EticaretV1.UI.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EticaretV1.UI.Areas.Member.Controllers
{
    //[CustomAuthorize(Role.Admin,Role.Member,Role.Company)]
    public class HomeController : BaseController
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";
          
            AppUser user = new AppUser();
            user = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Member/Account/Login");
            }
          
            if (user.Role==Role.Admin)
            {
                return Redirect("/Admin/Home/Index");
            }
            
            return Redirect("/Member/Category/List");
        }

       public ActionResult Guide()
        {
            return View();
        }
        

    }
}