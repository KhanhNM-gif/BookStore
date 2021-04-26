using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    public class BaseControlController : Controller
    {
        public void SetAlert(string message, string type)
        {
            TempData["message"] = message;
            if (type == "success")
            {
                TempData["typeAlert"] = "alert-success";
            }
            else if (type == "warring")
            {
                TempData["typeAlert"] = "alert-warring";
            }
            else if (type == "danger")
            {
                TempData["typeAlert"] = "alert-danger";
            }
        }
        [HttpPost]
        public JsonResult ShowAlert()
        {   
            return Json(new
            {
                isShow = TempData["message"] == null?false:true,
                message = TempData["message"],
                type = TempData["typeAlert"]
            }); 
        }
    }
}