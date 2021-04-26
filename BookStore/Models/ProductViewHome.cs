using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ProductViewHome
    {
        public IEnumerable<BookShort> Bestseller { get; set; }
        public IEnumerable<BookShort> New { get; set; }
        public IEnumerable<BookShort> Sale { get; set; }
        public IEnumerable<BookShort> Filter { get; set; }

    }
}