using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class BookTagModel
    {
        OnlineShopContext context = null;
        public BookTagModel()
        {
            context = new OnlineShopContext();
        }

        public int DeleteAtIDBook(int IDBook)
        {
            object[] paremeter = { new SqlParameter("ID", IDBook) };
            var res = context.Database.ExecuteSqlCommand("SP_BookTag_DeleteAtIDBook @ID", paremeter);
            return res;
        }

        public int DeleteAtTag(string Tag)
        {
            object[] paremeter = { new SqlParameter("ID", Tag) };
            var res = context.Database.ExecuteSqlCommand("SP_BookTag_DeleteAtTag @ID", paremeter);
            return res;
        }

        public int Create(BookTag e)
        {
            object[] paremeter = {
                new SqlParameter("Tag",e.Tag==null?(object)DBNull.Value:e.Tag),
                new SqlParameter("IDBook",e.IDBook),
            };
            var res = context.Database.ExecuteSqlCommand("SP_BookTag_Create @Tag,@IDBook", paremeter);
            return res;
        }

        public int Create(int IDbook, string Tags)
        {
            object[] paremeter = {
                new SqlParameter("IDBook",IDbook),
                new SqlParameter("STR",Tags==null?(object)DBNull.Value:Tags),

            };
            var res = context.Database.ExecuteSqlCommand("SP_BookTag_CreateFromString @STR,@IDBook", paremeter);
            return res;
        }
    }
}
