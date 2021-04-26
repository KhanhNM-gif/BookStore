using BookStore.Models;
using Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index(int IDCategory,int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.LinkRootCategory = new CategoryModel().GetLinkRootCategory(IDCategory);
            ViewBag.Name = new CategoryModel().GetItemAtID(IDCategory).Name;
            model.Filter = new BookModel().GetBooksAtIDCt(IDCategory,page,pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }   
        
        // GET: ProductCategory
        public ActionResult New(int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Name = "Mới ra mắt";
            model.Filter = new BookModel().GetNew().ToPagedList(page,pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }
        
        // GET: ProductCategory
        public ActionResult BestSeller(int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Name = "Bán Chạy Nhất";
            model.Filter = new BookModel().GetBestseller().ToPagedList(page,pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }
        
        // GET: ProductCategory
        public ActionResult Sale(int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Name = "Sale Off %";
            model.Filter = new BookModel().GetSale().ToPagedList(page,pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);

        } 
        // GET: ProductCategory
        public ActionResult IDAuthor(int IDAuthor, int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Name = "Tác giả :"+new AuthorModel().GetItemAtID(IDAuthor).Name;
            model.Filter = new BookModel().GetBooksAtIDAuthor(IDAuthor, page, pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }
        // GET: ProductCategory
        public ActionResult IDPublisingCompany(int IDPublisingCompany,int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Name = "Nhà Xuất Bản :" + new PublishingCompanyModel().GetItemAtID(IDPublisingCompany).Name;
            model.Filter = new BookModel().GetBooksAtIDPublisingCompany(IDPublisingCompany, page, pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }
        // GET: ProductCategory
        public ActionResult Search(string search, int page=1,int pagesize=20)
        {
            var model = new ProductViewHome();
            ViewBag.Search = search;
            model.Filter = new BookModel().GetBooksAtKeyword(search, page, pagesize);
            ViewBag.Count = model.Filter.Count();
            return View(model);
        }

        [HttpPost]
        public JsonResult ListName(string term)
        {
            term = term.ToLower();
            var list = new KeywordModel().GetKeywords().Where(x=>x.Name.ToLower().Contains(term)).Select(x=>x.Name).Take(5);
            return Json(new
            {
                data = list
            },JsonRequestBehavior.AllowGet);
        }
    }
}