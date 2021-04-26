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
    public class TagModel
    {
        OnlineShopContext context = null;
        public TagModel()
        {
            context = new OnlineShopContext();
        }

        public IEnumerable<Tag> GetTags(int page, int pageSize)
        {
            var list = context.Database.SqlQuery<Tag>("SP_Tag_GetAll").ToPagedList(page, pageSize);
            return list;
        }

        public int DeleteAtID(string ID)
        {
            new BookTagModel().DeleteAtTag(ID);
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.ExecuteSqlCommand("SP_Tag_Delete @ID",paremeter);
            return res;
        }

        public int UpdateAtID(Tag e)
        {
            object[] paremeter = {
                new SqlParameter("ID",e.ID),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
            };
            var res = context.Database.ExecuteSqlCommand("SP_Tag_Update @ID,@Name", paremeter);
            return res;
        }

        public int Create(Tag e)
        {  
            
            if(!isTagExist(e.ID))
            {
                object[] paremeter = 
                {
                    new SqlParameter("ID",e.ID),
                    new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                };
                var res = context.Database.ExecuteSqlCommand("SP_Tag_Create @ID,@Name", paremeter);
                return res;
            }
            return 0;
        }

        public Tag GetItemAtID(string ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<Tag>("SP_Tag_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }

        public bool isTagExist(string ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_Tag_Exist @ID", paremeter).SingleOrDefault();
            return res;
        }
    }
}
