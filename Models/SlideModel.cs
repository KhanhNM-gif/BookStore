using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SlideModel
    {
        OnlineShopContext context = null;
        public SlideModel()
        {
            context = new OnlineShopContext();
        }

        public List<Slide> GetShow()
        {
            var list = context.Database.SqlQuery<Slide>("SP_Slide_GetShow").ToList();
            return list;
        }
    }
}
