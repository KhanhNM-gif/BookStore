using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdsModel
    {
        OnlineShopContext context = null;
        public AdsModel()
        {
            context = new OnlineShopContext();
        }

        public List<Ad> GetShow()
        {
            var list = context.Database.SqlQuery<Ad>("SP_Ads_GetShow").ToList();
            return list;
        }
    }
}
