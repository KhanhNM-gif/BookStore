using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookCategoryModel
    {
        OnlineShopContext context = null;
        public BookCategoryModel()
        {
            context = new OnlineShopContext();
        }

        public int DeleteAtIDBook(int IDBook)
        {
            object[] paremeter = { new SqlParameter("ID", IDBook) };
            var res = context.Database.ExecuteSqlCommand("SP_BookCategory_DeleteAtIDBook @ID", paremeter);
            return res;
        }

        public int DeleteAtIDCategory(int IDBook)
        {
            object[] paremeter = { new SqlParameter("ID", IDBook) };
            var res = context.Database.ExecuteSqlCommand("SP_BookCategory_DeleteAtIDCategory @ID", paremeter);
            return res;
        }

        public int Create(BookCategory e)
        {
            object[] paremeter = {
                new SqlParameter("IDBook",e.IDBook),
                new SqlParameter("IDCategory",e.IDCategory),
  
            };
            var res = context.Database.ExecuteSqlCommand("SP_BookCategory_Create @IDBook,@IDCategory", paremeter);
            return res;
        }

        public int Create(int IDbook,string IDCategories)
        {
            DeleteAtIDBook(IDbook);
            object[] paremeter = {
                new SqlParameter("IDBook",IDbook),
                new SqlParameter("STR",IDCategories==null?(object)DBNull.Value:IDCategories),

            };
            var res = context.Database.ExecuteSqlCommand("SP_BookCategory_CreateFromString @STR,@IDBook", paremeter);
            return res;
        }

    }
}
