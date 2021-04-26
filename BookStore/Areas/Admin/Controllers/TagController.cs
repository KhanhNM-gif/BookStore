using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class TagController : BaseControlController
    {
        // GET: Admin/Tag
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = new TagModel().GetTags(page,pageSize);
            return View(list);
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Tag collection)
        {

            if (ModelState.IsValid)
            {
                var res=new TagModel().Create(collection);
                
                if(res!=0) SetAlert("Create success", "success");
                else SetAlert("Create failed because ID existed", "danger");
                return RedirectToAction("Index");
            }
            SetAlert("Create failed", "danger");
            return RedirectToAction("Index");

        }

        // GET: Admin/Tag/Edit/5
        public ActionResult Edit(string id)
        {
            var collection = new TagModel().GetItemAtID(id);
            return View(collection);
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(Tag collection)
        {

            if (ModelState.IsValid)
            {
                SetAlert("Update success", "success");
                new TagModel().UpdateAtID(collection);
                return RedirectToAction("Index");
            }
            SetAlert("Update failed", "danger");
            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult Delete(string ID)
        {
            var res = new TagModel().DeleteAtID(ID);
            SetAlert("delete success", "success");
            return Json(new
            {
                message = TempData["message"],
                type = TempData["typeAlert"]
            });
        }
    }
}