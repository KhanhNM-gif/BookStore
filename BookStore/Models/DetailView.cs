using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DetailView
    {
        public BookView BookView { get; set; }
        public IEnumerable<Book> ListSuggest { get; set; }
    }
}
