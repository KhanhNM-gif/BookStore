using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MenuModel
    {
        OnlineShopContext context = null;
        public MenuModel()
        {
            context = new OnlineShopContext();
        }

        public List<Menu> GetMenus()
        {
            var list = context.Database.SqlQuery<Menu>("SP_Menu_GetAll").ToList();
            return list;
        }
    }
}
