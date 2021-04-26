using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class RootCategoryModel
    {
        OnlineShopContext context = null;
        public RootCategoryModel()
        {
            context = new OnlineShopContext();
        }
    }
}
