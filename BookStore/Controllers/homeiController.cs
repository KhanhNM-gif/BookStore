using BookStore.Models;
using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class homeiController : Controller
    {
        // GET: homei
        public ActionResult Index()
        {
            var model = new ProductViewHome();
            model.New = new BookModel().GetNew().Take(3);
            model.Sale = new BookModel().GetSale().Take(3);
            model.Bestseller = new BookModel().GetBestseller().Take(3);
            return PartialView(model);
        }

        public ActionResult test()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model =new MenuMain();
            model.menu = new MenuModel().GetMenus();
            model.categoryView = new CategoryModel().GetAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult AgileMainTop()
        {
            var model =new MenuMain();
            model.menu = new MenuModel().GetMenus();
            model.categoryView = new CategoryModel().GetAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult LoginModal()
        {
            return PartialView();
        }  
        
        
        [ChildActionOnly]
        public ActionResult headerBot()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult banner()
        {
            var model = new SlideModel().GetShow();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Ads()
        {
            var model = new AdsModel().GetShow();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult NotificationModal()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult ProductRight()
        {
            var model = new ProductRight();
            model.categories = new CategoryModel().GetAll();
            model.publishingCompanies = new PublishingCompanyModel().GetPublishingCompanys().Take(10);
            model.authors = new AuthorModel().GetAuthors().Take(10);
            return PartialView(model);
        }
    }
}