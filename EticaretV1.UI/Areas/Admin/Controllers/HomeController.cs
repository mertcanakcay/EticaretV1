using EticaretV1.Model.Option;
using EticaretV1.UI.Areas.Member.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretV1.UI.Areas.Admin.Controllers
{
  
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            AppUser user = new AppUser();
            user = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Member/Account/Login");
            }
           
            if (user.Role != Role.Admin)
            {
                return Redirect("/Member/Home/Index");
            }


            return View();
        }
      


    }
}