using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookViewModel
    {
        OnlineShopContext context = null;

        public BookViewModel()
        {
            context = new OnlineShopContext();
        }

        public BookView GetItemAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<BookView>("SP_BookView_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }
    }
}
