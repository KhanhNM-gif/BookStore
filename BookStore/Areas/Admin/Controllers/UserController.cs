/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/PublishingCompany
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = new PublishingCompanyModel().GetPublishingCompanys(page, pageSize);
            return View(list);
        }

        // GET: Admin/PublishingCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PublishingCompany/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(PublishingCompany collection)
        {

            if (ModelState.IsValid)
            {
                SetAlert("Create success", "success");
                new PublishingCompanyModel().Create(collection);
                return RedirectToAction("Index");
            }
            SetAlert("Create failed", "danger");
            return RedirectToAction("Index");

        }

        // GET: Admin/PublishingCompany/Edit/5
        public ActionResult Edit(int id)
        {
            var collection = new PublishingCompanyModel().GetItemAtID(id);
            return View(collection);
        }

        // POST: Admin/PublishingCompany/Edit/5
        [HttpPost]
        public ActionResult Edit(PublishingCompany collection)
        {

            if (ModelState.IsValid)
            {
                SetAlert("Update success", "success");
                new PublishingCompanyModel().UpdateAtID(collection);
                return RedirectToAction("Index");
            }
            SetAlert("Update failed", "danger");
            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var res = new PublishingCompanyModel().DeleteAtID(ID);
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
            var res = new PublishingCompanyModel().ChangeStatusAtID(ID);
            return Json(new
            {
                status = res
            });
        }
    }
}*/