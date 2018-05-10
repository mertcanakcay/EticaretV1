using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretV1.UI.Areas.Member.Controllers
{
  
    public class CategoryController : BaseController
    {
        // GET: Member/Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            

            ViewBag.CurrentUser = User.Identity.Name;
            return View(service.CategoryService.GetActive());
        }


    }
}