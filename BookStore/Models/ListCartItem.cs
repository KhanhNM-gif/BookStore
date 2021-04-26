using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{   
    [Serializable]
    public class ListCartItem
    {
        public ListCartItem()
        {
            Item = new List<CartItem>();
            TotalQuantity = 0;
            Totalmoney = 0;
        }
        public List<CartItem> Item { get; set; }
        public int TotalQuantity { get; set; }
        public Decimal Totalmoney { get; set; }
    }
}