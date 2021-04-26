using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class MenuMain
    {
        public List<Menu> menu { get; set; }
        public List<Category> categoryView { get; set; }
    }
}