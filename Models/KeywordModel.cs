using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KeywordModel
    {
        private OnlineShopContext context=null;

        public KeywordModel()
        {
            context = new OnlineShopContext();
        }

        public List<Keyword> GetKeywords()
        {
            var res = context.Database.SqlQuery<Keyword>("SP_GetKeyword_GetNameBooks").ToList();
            return res;
        }
    }
}
