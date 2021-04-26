using BookStore.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        [HttpGet]
        public ActionResult Index(int id)
        {
            var Item = new DetailView();
            Item.BookView = new BookViewModel().GetItemAtID(id);
            Item.ListSuggest = new BookModel().GetBooks().Where(x=>(x.ID!=Item.BookView.ID)&&(x.IDAuthor==Item.BookView.IDAuthor||x.IDRootCategory==Item.BookView.IDRootCategory));
            return View(Item);
        }
        
    }
}