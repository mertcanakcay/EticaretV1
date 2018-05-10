using EticaretV1.Model.Option;
using EticaretV1.UI.Areas.Admin.Models;
using EticaretV1.UI.Areas.Member.Controllers;
using EticaretV1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretV1.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        // GET: Admin/AppUser
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
                return Redirect("/Member/Category/List");
            }
            return View();
        }

    

        public ActionResult ListComments()
        {
            AppUser user = new AppUser();
            user = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Member/Account/Login");
            }

            if (user.Role != Role.Admin)
            {
                return Redirect("/Member/Category/List");
            }
            return View(service.CommentService.GetAll());
        }



        public ActionResult ListMember()
        {
           AppUser user = new AppUser();
            user = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Member/Account/Login");
            }

            if (user.Role != Role.Admin)
            {
                return Redirect("/Member/Category/List");
            }
            return View(service.AppUserService.ListUser());
        }
        public ActionResult Update(Guid id)
        {
           
            AppUser user = service.AppUserService.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.Id = user.Id;
            model.UserName = user.UserName;
            model.Password = user.Password;
            model.Role = user.Role;
            model.ImagePath = user.ImagePath;
            model.Email = user.Email;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(AppUserDTO data,HttpPostedFileBase Image)
        {
           
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads", Image);
          
            AppUser user = service.AppUserService.GetById(data.Id);
            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                if (user.ImagePath == null || user.ImagePath == "~/Content/Images/avantaj.png")
                {
                    data.ImagePath = "~/Content/Images/avantaj.png";
                }
                else
                {
                    data.ImagePath = user.ImagePath;
                }
            }
            user.UserName = data.UserName;
            user.Password = data.Password;
            user.Role = data.Role;
            user.ImagePath = data.ImagePath;
            user.Email = data.Email;
            service.AppUserService.Update(user);

            return Redirect("/Admin/AppUser/ListMember");
        }
    }
}