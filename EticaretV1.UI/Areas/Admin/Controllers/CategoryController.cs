using EticaretV1.Model.Option;
using EticaretV1.UI.Areas.Admin.Models;
using EticaretV1.UI.Areas.Member.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretV1.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Add()
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
        [HttpPost]
        public ActionResult Add(Category data)
        {
           

            data.CreatedBy = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
            service.CategoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult List()
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


            return View(service.CategoryService.ListCategories());
        }

        public ActionResult Update(Guid id)
        {
           
            Category cat = service.CategoryService.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.Id = cat.Id;
            model.Name = cat.Name;
            model.Description = cat.Description;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
           
            Category cat = service.CategoryService.GetById(data.Id);

            if (service.CategoryService.Any(x => x.Name == data.Name)) return Redirect("/Admin/Category/List");
            cat.Name = data.Name;
            cat.Description = data.Description;
            service.CategoryService.Update(cat);
            return Redirect("/Admin/Category/List");
           
           
        }
    }
}