using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    [Serializable]
    public class DropListItem
    {
        public DropListItem(string text,int id,bool isSelect)
        {
            Text = text;
            ID = id;
            this.isSelect = isSelect;
        }
        public string Text { get; set; }
        public int ID { get; set; }     
        public bool isSelect { get; set; }
    }
}