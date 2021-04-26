using BookStore.Areas.Admin.Models;
using Microsoft.Ajax.Utilities;
using Models;
using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookStore.Areas.Admin.Controllers
{
    public class BookController : BaseControlController
    {

        // GET: Admin/Book
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = new BookModel().GetBooks(page, pageSize);
            return View(list);
        }

        // GET: Admin/Book/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        // POST: Admin/Book/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Book collection)
        {

            if (ModelState.IsValid)
            {
                SetAlert("Create success", "success");
                new BookModel().Create(collection);
                return RedirectToAction("Index");
            }
            SetAlert("Create failed", "danger");
            return RedirectToAction("Index");

        }

        // GET: Admin/Book/Edit/5
        public ActionResult Edit(int id)
        {

            var collection = new BookModel().GetItemAtID(id);
            SetViewBag(collection.IDPublishingCompany, collection.IDAuthor,collection.IDRootCategory,collection.IDCategorys);
            return View(collection);
        }

        // POST: Admin/Book/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Book collection)
        {

            if (ModelState.IsValid)
            {
                SetAlert("Update success", "success");
                new BookModel().UpdateAtID(collection);
                return RedirectToAction("Index");
            }
            SetAlert("Update failed", "danger");
            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var res = new BookModel().DeleteAtID(ID);
            SetAlert("delete success", "success");
            return Json(new
            {
                message = TempData["message"],
                type = TempData["typeAlert"]
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(int ID)
        {

            var res = new BookModel().ChangeStatusAtID(ID);
            return Json(new
            {
                status = res,
            });
        }


        [HttpPost]
        public JsonResult ChildrenCategories(int IDParent,string IDChilrenCategories)
        {
            var list = new CategoryModel().GetAll().Where(x=>x.IDParent==IDParent);
            string[] listSelectCategories = null;
            if (IDChilrenCategories!="NaN")
            {
                listSelectCategories = IDChilrenCategories.Split(',');
            }
            
            var listIDCategories = new List<int>();
            if (listSelectCategories!=null)
            {
                foreach (var item in listSelectCategories)
                {
                    listIDCategories.Add(Int32.Parse(item));
                }
            }

            var listDrop = new List<DropListItem>();
            list.ForEach(item => listDrop.Add(new DropListItem(item.Name, item.ID.GetValueOrDefault(0), listIDCategories.Exists(item1 => item1 == item.ID))));
            return Json(new
            {
                list = new JavaScriptSerializer().Serialize(listDrop)
            });
        }

        public void SetViewBag(int? selectPublishingCommpany = -1, int? selectAuthor = -1,int? selectRootCategory=null,string IDCategorys=null)
        {
            var list = new CategoryModel().GetAll();
            ViewBag.IDRootCategory=new SelectList(list.Where(x=>x.IDParent==null), "ID", "Name", selectRootCategory);
 
            var listPublishingCommpany = new PublishingCompanyModel().GetPublishingCompanys();
            var defual = new PublishingCompany();
            defual.ID = null; defual.Name = "n/a";
            listPublishingCommpany.Insert(0, defual);
            ViewBag.IDPublishingCompany = new SelectList(listPublishingCommpany, "ID", "Name", selectPublishingCommpany);

            var listAuthor = new AuthorModel().GetAuthors();
            var defual2 = new Author();
            defual2.ID = null; defual2.Name = "n/a";
            listAuthor.Insert(0, defual2);
            ViewBag.IDAuthor = new SelectList(listAuthor, "ID", "Name", selectAuthor);
        }



    }
}