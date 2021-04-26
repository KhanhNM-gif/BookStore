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
    public class CategoryModel
    {
        OnlineShopContext context = null;

        public CategoryModel()
        {
            context = new OnlineShopContext();
        }
        
        public List<Category> GetAll()
        {
            var list = context.Database.SqlQuery<Category>("SP_Category_GetAll").ToList();
            return list;
        }
        public IEnumerable<Category> GetAll(int page, int pageSize)
        {

            var list = context.Database.SqlQuery<Category>("SP_Category_GetAll").ToPagedList(page, pageSize);

            return list;
        }

        public int Delete(int ID)
        {
            new BookCategoryModel().DeleteAtIDCategory(ID);
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.ExecuteSqlCommand("SP_Category_Delete @ID", paremeter);
            return res;
        }

        public bool HasLeaf(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_Category_HasLeaf @ID", paremeter).SingleOrDefault();

            return res;
        }

        public string GetLinkRootCategory(int IDCategory)
        {
            object[] paremeter = { new SqlParameter("ID", IDCategory) };
            var res = context.Database.SqlQuery<string>("SP_Category_GetLinkCategoryRoot @ID", paremeter).SingleOrDefault();
            return res;
        }


        public int Create(Category e)
        {
            object[] paremeter = {
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("IDParent",e.IDParent==null?(object)DBNull.Value:e.IDParent),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("CreateBy",e.CreateBy==null?(object)DBNull.Value:e.CreateBy),
                new SqlParameter("Status",e.Status==null?(object)DBNull.Value:e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Category_Create @Name,@MetaTitle,@IDParent,@DisplayOrder,@Detail,@CreateBy,@Status", paremeter);
            return res;
        }

        public Category GetItemAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<Category>("SP_Category_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }

        public bool ChangedStatus(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_Category_ChangedStatus @ID", paremeter).SingleOrDefault();
            return res;
        }

        public int UpdateAtID(Category e)
        {
            object[] paremeter = {
                new SqlParameter("ID",e.ID),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("IDParent",e.IDParent==null?(object)DBNull.Value:e.IDParent),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("ModifileBy",e.ModifileBy==null?(object)DBNull.Value:e.ModifileBy),
                new SqlParameter("Status",e.Status==null?(object)DBNull.Value:e.Status)
            };
            var res = context.Database.ExecuteSqlCommand("SP_Category_Update @ID,@Name,@MetaTitle,@IDParent,@DisplayOrder,@Detail,@ModifileBy,@Status", paremeter);
            return res;
        }
    }
}
