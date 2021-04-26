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
    public class AuthorModel
    {
        OnlineShopContext context = null;
        public AuthorModel()
        {
            context = new OnlineShopContext();
        }

        public List<Author> GetAuthors()
        {
            var list = context.Database.SqlQuery<Author>("SP_Author_GetAll").ToList();
            return list;
        }
        public IEnumerable<Author> GetAuthors(int page,int pageSize)
        {
            var list = context.Database.SqlQuery<Author>("SP_Author_GetAll").ToPagedList(page, pageSize);
            return list;
        }

        public int DeleteAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.ExecuteSqlCommand("SP_Author_Delete @ID", paremeter);
            return res;
        }

        public int UpdateAtID(Author e)
        {
            object[] paremeter = {
                new SqlParameter("ID",e.ID),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("Image",e.Image==null?(object)DBNull.Value:e.Image),
                new SqlParameter("Gender",e.Gender==null?(object)DBNull.Value:e.Gender),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("ModifileBy",e.CreateBy==null?(object)DBNull.Value:e.CreateBy),
                new SqlParameter("Status",e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Author_Update @ID,@Name,@MetaTitle,@Image,@Gender,@Detail,@DisplayOrder,@ModifileBy,@Status", paremeter);
            return res;
        }

        public int Create(Author e)
        {
            object[] paremeter = {
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("Image",e.Image==null?(object)DBNull.Value:e.Image),
                new SqlParameter("Gender",e.Gender==null?(object)DBNull.Value:e.Gender),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("CreateBy",e.CreateBy==null?(object)DBNull.Value:e.CreateBy),
                new SqlParameter("Status",e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Author_Create @Name,@MetaTitle,@Image,@Gender,@Detail,@DisplayOrder,@CreateBy,@Status", paremeter);
            return res;
        }

        public bool ChangeStatusAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_Author_ChangeStatus @ID", paremeter).SingleOrDefault();
            return res;
        }

        public Author GetItemAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<Author>("SP_Author_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }
    }
}
