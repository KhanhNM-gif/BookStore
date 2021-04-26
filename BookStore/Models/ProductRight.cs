using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ProductRight
    {
        public List<Category> categories { get; set; }
        public IEnumerable<Author> authors { get; set; }
        public IEnumerable<PublishingCompany> publishingCompanies { get; set; }
    }
}