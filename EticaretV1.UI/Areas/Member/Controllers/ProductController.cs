using EticaretV1.Model.Option;

using EticaretV1.UI.Areas.Member.Models;
using EticaretV1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretV1.UI.Areas.Member.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Member/Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buy(Guid id)
        {
           
            Product p = service.ProductService.GetById(id);
            ProductDTO data = new ProductDTO();
            data.Id = p.Id;
            data.Name = p.Name;
            data.Quantity = p.Quantity;
            data.UnitPrice = p.Price;
            data.UnitsInStock = p.UnitsInStock;
            data.CategoryId = p.CategoryID;
            return View(data);
        }


        [HttpPost]
        public ActionResult Buy(ProductDTO data)
        { 

            Product p = service.ProductService.GetById(data.Id);
            //Farkındayım bir garip durduğundan :)

            short? toplamStok = p.UnitsInStock;//short'dan 1 çıkaramadığım için boyle bir rötar oldu.2 short'u birbirinden çıkaracağınız zaman sonuç short olmayabiliyormuş.
            int sonuc = (int)toplamStok - 1;

            p.UnitsInStock = (short?)sonuc;
            service.ProductService.Update(p);

            Order order = new Order();
            order.AppUserID = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
            order.OrderDate = DateTime.Now;
            service.OrderService.Add(order);

            OrderDetails orderDetails = new OrderDetails();
            orderDetails.OrderID = order.Id;
            orderDetails.ProductID = data.Id;
            orderDetails.UnitPrice = p.Price;
            orderDetails.Quantity = 1;
            service.OrderDetailsService.Add(orderDetails);

            return Redirect("/Member/Category/List");



        }


        [HttpGet]
        public ActionResult Add()
        {
            ProductVM model = new ProductVM();
            model.Categories = service.CategoryService.GetActive();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product urun,HttpPostedFileBase Image)
        {
            ProductVM data = new ProductVM();

            urun.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);
            if (urun.ImagePath == "0" || urun.ImagePath == "1" || urun.ImagePath == "2")
                urun.ImagePath = "~/Content/Images/avantaj.png";

           
            urun.AppUserID = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
           
            urun.CreatedBy = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
            urun.isPending = true;
            service.ProductService.Add(urun);
           

            return Redirect("/Member/Category/List");
        }

        public ActionResult List(Guid id)
        {
            var model = service.ProductService.GetDefault(x => x.CategoryID == id && x.isPending==false && x.UnitsInStock >=1 ).ToList();
            return View(model);
        }
        public ActionResult MemberProductList()
        {
            MemberProductVM model = new MemberProductVM();
          
            model.AppUserID = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
          

            model.ApprovedProduct = service.ProductService.GetDefault(x => x.isPending == false && x.AppUserID == model.AppUserID && x.Status != Core.Enum.Status.Deleted).ToList();
            model.PendingProduct = service.ProductService.GetDefault(x => x.isPending == true && x.AppUserID == model.AppUserID && x.Status != Core.Enum.Status.Deleted).ToList();

            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            ProductUpdateDTO data = new ProductUpdateDTO();
            Product p = service.ProductService.GetById(id);

            data.CategoryList= service.CategoryService.GetActive();
            data.ProductID = p.Id;
            data.Name = p.Name;
            data.Price = p.Price;
            data.Quantity = p.Quantity;
            data.UnitsInStock = p.UnitsInStock;
            data.ImagePath = p.ImagePath;

            return View(data);
        }
        [HttpPost]
        public ActionResult Update(ProductUpdateDTO data,HttpPostedFileBase Image,ImagesForProducts ımageFor,HttpPostedFileBase Image1)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads", Image);
            
            Product p= service.ProductService.GetById(data.ProductID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                if (p.ImagePath == null || p.ImagePath == "~/Content/Images/avantaj.png")
                {
                    data.ImagePath = "~/Content/Images/avantaj.png";
                }
                else
                {
                    data.ImagePath = p.ImagePath;
                }
            }

            data.ImagePath1 = ImageUploader.UploadSingleImage("~/Uploads/", Image1);
            if (data.ImagePath1 == "0" || data.ImagePath1 == "1" || data.ImagePath1 == "2")
                data.ImageForProducts.ImagePath = "~/Content/Images/avantaj.png";



            ımageFor.ProductID = p.Id;
            ımageFor.ImagePath = data.ImagePath1;
            p.Name = data.Name;
            p.Price = data.Price;
            p.Quantity = data.Quantity;
            p.UnitsInStock = data.UnitsInStock;
            p.ImagePath = data.ImagePath;

            service.ImageForProductsService.Add(ımageFor);
            service.ProductService.Update(p);


            return Redirect("/Member/Product/MemberProductList");
        }

        public JsonResult AddLike(Guid id)
        {
            JsonLikeVM jr = new JsonLikeVM();
            Guid appuserID = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
            if (!(service.LikeService.Any(x => x.AppUserID == appuserID && x.ProductID == id)))
            {
                Like like = new Like();
                like.ProductID = id;
                like.AppUserID = appuserID;
                service.LikeService.Add(like);

                jr.Likes = service.LikeService.GetDefault(x => x.ProductID == id).Count();
                jr.userMessage = "";
                jr.isSuccess = true;
                return Json(jr, JsonRequestBehavior.AllowGet);
            }

            jr.isSuccess = false;
            jr.userMessage = "Bu ürünü daha önce beğendiniz!";
            jr.Likes = service.LikeService.GetDefault(x => x.ProductID == id).Count;

            return Json(jr, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Show(Guid id)
        {
            ProductCommentVM model = new ProductCommentVM();
            model.Product = service.ProductService.GetById(id);

            model.Comments = service.CommentService.GetDefault(x => x.ProductID == id).OrderByDescending(x => x.CreatedDate).Take(10);
            model.ImagesForProducts = service.ImageForProductsService.GetDefault(x => x.ProductID == id).ToList();
            model.Likes = service.LikeService.GetDefault(x => x.ProductID == id).Count();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddComment(CommentVM data)
        {
            Comment comment = new Comment();
            comment.AppUserID = service.AppUserService.UyeAdındanBul(HttpContext.User.Identity.Name).Id;
            comment.ProductID = data.Id;
            comment.Content = data.Content;
            comment.Header = data.Header;
            service.CommentService.Add(comment);

            return Redirect("/Member/Product/Show/" + data.Id);
        }
    }
}