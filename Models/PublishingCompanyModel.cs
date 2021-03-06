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
    public class PublishingCompanyModel
    {
        OnlineShopContext context = null;
        public PublishingCompanyModel()
        {
            context = new OnlineShopContext();
        }

        public IEnumerable<PublishingCompany> GetPublishingCompanys(int page, int pageSize)
        {
            var list = context.Database.SqlQuery<PublishingCompany>("SP_PublishingCompany_GetAll").ToPagedList(page, pageSize);
            return list;
        }

        public List<PublishingCompany> GetPublishingCompanys()
        {
            var list = context.Database.SqlQuery<PublishingCompany>("SP_PublishingCompany_GetAll").ToList();
            return list;
        }
        public int DeleteAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.ExecuteSqlCommand("SP_PublishingCompany_Delete @ID", paremeter);
            return res;
        }

        public int UpdateAtID(PublishingCompany e)
        {
            object[] paremeter = {
                new SqlParameter("ID",e.ID),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("PhoneNumber",e.PhoneNumber==null?(object)DBNull.Value:e.PhoneNumber),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("ModifileBy",e.CreateBy==null?(object)DBNull.Value:e.CreateBy),
                new SqlParameter("Status",e.Status==null?(object)DBNull.Value:e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_PublishingCompany_Update @ID,@Name,@MetaTitle,@PhoneNumber,@DisplayOrder,@ModifileBy,@Status", paremeter);
            return res;
        }

        public int Create(PublishingCompany e)
        {
            object[] paremeter = {
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("PhoneNumber",e.PhoneNumber==null?(object)DBNull.Value:e.PhoneNumber),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("CreateBy",e.CreateBy==null?(object)DBNull.Value:e.CreateBy),
                new SqlParameter("Status",e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_PublishingCompany_Create @Name,@MetaTitle,@PhoneNumber,@DisplayOrder,@CreateBy,@Status", paremeter);
            return res;
        }

        public bool ChangeStatusAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_PublishingCompany_ChangeStatus @ID", paremeter).SingleOrDefault();
            return res;
        }

        public PublishingCompany GetItemAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<PublishingCompany>("SP_PublishingCompany_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }
    }
}
