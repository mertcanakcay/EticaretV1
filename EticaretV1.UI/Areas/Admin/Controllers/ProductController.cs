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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
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
            return View(service.ProductService.ListPendingProducts());
            
        }

       


        public ActionResult Approval(Guid? id)
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


            Product p = service.ProductService.GetById((Guid)id);
            p.isPending = false;
            service.ProductService.Update(p);
     

            return Redirect("/Admin/Product/List");
        }

        public ActionResult ApprovedProducts()
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

            return View(service.ProductService.ListAcceptedProduct());
        }

        public ActionResult Delete(Guid id)
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

            service.ProductService.Remove(id);
            return Redirect("/Admin/Product/List");
        }

       

    }
}