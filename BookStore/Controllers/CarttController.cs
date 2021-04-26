using BookStore.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookStore.Controllers
{
    public class CarttController : Controller
    {
        private const string cartSession = "cartSession";
        private const string confirmCartSession = "confirmCartSession";

        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[cartSession];
            var list = new ListCartItem();
            if (cart != null)
            {
                list = (ListCartItem)cart;
            }
            return View(list);
        }

        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (ListCartItem)Session[cartSession];
            foreach (var item in jsonCart)
            {
                if (sessionCart.Item.Exists(x => x.Book.ID == item.Book.ID))
                {
                    var e = sessionCart.Item.SingleOrDefault(x => x.Book.ID == item.Book.ID);
                    var quantityPlus = item.Quantity - e.Quantity;
                    sessionCart.Item.SingleOrDefault(x => x.Book.ID == item.Book.ID).Quantity = item.Quantity;
                    sessionCart.TotalQuantity += quantityPlus;
                    sessionCart.Totalmoney += quantityPlus * ((e.Book.PromotionPrice < e.Book.Price) ? e.Book.PromotionPrice : e.Book.Price).GetValueOrDefault(0);
                }
                else
                {
                    var e = sessionCart.Item.SingleOrDefault(x => x.Book.ID == item.Book.ID);
                    sessionCart.Totalmoney += item.Quantity * ((e.Book.PromotionPrice < e.Book.Price) ? e.Book.PromotionPrice : e.Book.Price).GetValueOrDefault(0);
                    sessionCart.TotalQuantity += item.Quantity;
                    sessionCart.Item.Add(item);
                }
            }
            Session[cartSession] = sessionCart;
            return Json(new
            {
                Status = true
            });
        }

        [HttpPost]
        public JsonResult RemoveAllItemCart()
        {
            Session[cartSession] = null;
            return Json(new
            {
                Status = true
            });
        }

        [HttpPost]
        public JsonResult RemoveItem(int ID)
        {
            var cart = (ListCartItem)Session[cartSession];
            var item = cart.Item.SingleOrDefault(x => x.Book.ID == ID);
            cart.Item.Remove(item);
            cart.TotalQuantity -= item.Quantity;
            cart.Totalmoney -= item.Quantity * ((item.Book.PromotionPrice < item.Book.Price) ? item.Book.PromotionPrice : item.Book.Price).GetValueOrDefault(0);
            return Json(new
            {
                IsCartNull = cart.Item.Count == 0 ? true : false
            });
        }

        [HttpPost]
        public JsonResult UpdateQuantityItem()
        {
            var cart = Session[cartSession];
            var list = new ListCartItem();
            if (cart != null)
            {
                list = (ListCartItem)cart;
            }
            return Json(new
            {
                quantity = list.TotalQuantity
            });
        }

        [HttpPost]
        public JsonResult AddCart(int IDBook, int quantity)
        {
            var cart = Session[cartSession];
            if (cart != null)
            {
                var list = (ListCartItem)cart;
                if (list.Item.Exists(x => x.Book.ID == IDBook))
                {
                    var Item = list.Item.SingleOrDefault(x => x.Book.ID == IDBook);
                    list.TotalQuantity += quantity;
                    list.Totalmoney += quantity * ((Item.Book.PromotionPrice < Item.Book.Price) ? Item.Book.PromotionPrice : Item.Book.Price).GetValueOrDefault(0);
                    Item.Quantity += quantity;

                }
                else
                {
                    var item = new CartItem();
                    item.Book = new BookModel().GetItemAtID(IDBook);
                    item.Quantity = quantity;
                    list.Item.Add(item);
                    list.TotalQuantity += quantity;
                    list.Totalmoney += quantity * ((item.Book.PromotionPrice < item.Book.Price) ? item.Book.PromotionPrice : item.Book.Price).GetValueOrDefault(0);
                }
                Session[cartSession] = list;
            }
            else
            {
                var list = new ListCartItem();
                var item = new CartItem();
                item.Book = new BookModel().GetItemAtID(IDBook);
                item.Quantity = quantity;
                list.Item.Add(item);
                list.TotalQuantity = quantity;
                list.Totalmoney += quantity * ((item.Book.PromotionPrice < item.Book.Price) ? item.Book.PromotionPrice : item.Book.Price).GetValueOrDefault(0);
                Session[cartSession] = list;
            }
            return Json(new
            {
                status = true
            });
        }

/*        [HttpGet]
        public ActionResult Pay()
        {
            var cart = Session[cartSession];
            var list = new ListCartItem();
            if (cart != null)
            {
                list = (ListCartItem)cart;
            }
            ViewBag.Cart = list;

            var userSession = Session[AccountController.userSession];
            var order = new Order();
            var user = new Account();
            if (userSession != null)
            {
                user = (Account)userSession;
                order.CustomerID = 1;
                order.ShipMobile = user.PhoneNumber;
                order.ShipEmail = user.Email;
                order.ShipAddress = user.Address;
                order.ShipName = user.Name;
            }
            
            
            return View(order);
        }*/

        [HttpPost]

        public ActionResult Pay(Order collection)
        {
            if (ModelState.IsValid)
            {
                var cart = Session[cartSession];
                var list = new ListCartItem();
                if (cart != null)
                {
                    list = (ListCartItem)cart;
                }
                var IDOrder = new OrderModel().Create(collection);
                foreach (var item in list.Item)
                {
                    new OrderDetailModel().Create(IDOrder, item.Book.ID, item.Quantity, (item.Book.PromotionPrice < item.Book.Price) ? item.Book.PromotionPrice : item.Book.Price);
                }
            }
            return RedirectToAction("","gio-hang");
        }





    }
}