using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BookStore.Areas.Admin.Controllers
{
    public class CategoryController : BaseControlController
    {
        // GET: Admin/Book
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = new CategoryModel().GetAll(page, pageSize);
            return View(list);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        public void SetViewBag(int? select = 1)
        {
            var list = new CategoryModel().GetAll().Where(x => x.IDParent == null).ToList();
            var defual = new Category();
            defual.ID = null; defual.Name = "n/a";
            list.Insert(0, defual);
            ViewBag.IDParent = new SelectList(list, "ID", "Name", select);
        }

        // POST: Admin/Category/Create
        [HttpPost,ValidateInput(false)]
        public ActionResult Create(Category collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new CategoryModel().Create(collection);
                    SetAlert("Create success", "success");
                    return RedirectToAction("Index");
                }
                SetViewBag(collection.IDParent);
                SetAlert("Create failed", "danger");
                return View(collection);
            }
            catch
            {
                SetViewBag(collection.IDParent);
                return View(collection);
            }

        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            
            var Collection = new CategoryModel().GetItemAtID(id);
            SetViewBag(Collection.IDParent);
            return View(Collection);

        }

        // POST: Admin/Category/Edit/5
        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(Category collection)
        {
            SetAlert("Update success", "success");
            new CategoryModel().UpdateAtID(collection);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var Category = new CategoryModel();
            if (Category.HasLeaf(ID))
            {
                SetAlert("delete failed because it is Leaf", "danger");
                return Json(new {
                    isDelete=false,
                    message= TempData["message"],
                    type = TempData["typeAlert"]
                });
            }
            else
            {
                var res = new CategoryModel().Delete(ID);
                SetAlert("delete success", "success");
                return Json(new
                {
                    isDelete = true,
                    message = TempData["message"],
                    type = TempData["typeAlert"]
                });
            }
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = new CategoryModel().ChangedStatus(id);
            return Json(new
            {
                status = res
            });

        }
    }
}
