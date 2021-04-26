using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BookStore.Areas.Admin.Controllers
{
    public class AuthorController : BaseControlController
    {
        // GET: Admin/Author
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var list = new AuthorModel().GetAuthors(page,pageSize);
            return View(list);
        }

        // GET: Admin/Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Author/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Author collection)
        {
            
                if (ModelState.IsValid)
                {
                    SetAlert("Create success", "success");
                    new AuthorModel().Create(collection);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            
        }

        // GET: Admin/Author/Edit/5
        public ActionResult Edit(int id)
        {
            var collection = new AuthorModel().GetItemAtID(id);
            return View(collection);
        }

        // POST: Admin/Author/Edit/5
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Author collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SetAlert("Update success","success");
                    new AuthorModel().UpdateAtID(collection);
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var res = new AuthorModel().DeleteAtID(ID);
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
            var res = new AuthorModel().ChangeStatusAtID(ID);
            return Json(new
            {
                status = res
            }); 
        }
    }
}
