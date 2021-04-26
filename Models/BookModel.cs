using Models.Framework;
using Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookModel
    {
        OnlineShopContext context = null;

        public BookModel()
        {
            context = new OnlineShopContext();
        }
        
        public IEnumerable<Book> GetBooks()
        {

            var list = context.Database.SqlQuery<Book>("SP_Book_GetAll").ToList();
            return list;
        }

        public IEnumerable<BookShort> GetSale()
        {

            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetSale").ToList();
            return list;
        }

        public IEnumerable<BookShort> GetBestseller()
        {

            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetBestseller").ToList();
            return list;
        }

        public IEnumerable<BookShort> GetNew()
        {

            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetNew").ToList();
            return list;
        }

        public IEnumerable<Book> GetBooks(int page, int pageSize)
        {

            var list = context.Database.SqlQuery<Book>("SP_Book_GetAll").ToPagedList(page, pageSize);

            return list;
        }

        public int DeleteAtID(int ID)
        {
            new BookCategoryModel().DeleteAtIDBook(ID);
            new BookTagModel().DeleteAtIDBook(ID);
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.ExecuteSqlCommand("SP_Book_Delete @ID", paremeter);
            return res;
        }

        public int Create(Book e)
        {
            
            object[] paremeter = {
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("Image",e.Image==null?(object)DBNull.Value:e.Image),
                new SqlParameter("IDRootCategory",e.IDRootCategory==null?(object)DBNull.Value:e.IDRootCategory),
                new SqlParameter("IDCategorys",e.IDCategorys==null?(object)DBNull.Value:e.IDCategorys),
                new SqlParameter("Price",e.Price==null?(object)DBNull.Value:e.Price),
                new SqlParameter("PromotionPrice",e.PromotionPrice==null?(object)DBNull.Value:e.PromotionPrice),
                new SqlParameter("IncludeVAT",e.IncludeVAT==null?(object)DBNull.Value:e.IncludeVAT),
                new SqlParameter("IDAuthor",e.IDAuthor==null?(object)DBNull.Value:e.IDAuthor),
                new SqlParameter("IDPublishingCompany",e.IDPublishingCompany==null?(object)DBNull.Value:e.IDPublishingCompany),
                new SqlParameter("PublicationDate",e.PublicationDate==null?(object)DBNull.Value:e.PublicationDate),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("Quantity",e.Quantity==null?(object)DBNull.Value:e.Quantity),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("ModifileBy",e.ModifileBy==null?(object)DBNull.Value:e.ModifileBy),
                new SqlParameter("Status",e.Status==null?(object)DBNull.Value:e.Status),
                new SqlParameter("TopHot",e.TopHot==null?(object)DBNull.Value:e.TopHot),
                new SqlParameter("Tag",e.Tags==null?(object)DBNull.Value:e.Tags),
            };
            var res = context.Database.SqlQuery<int>("SP_Book_Create @Name,@MetaTitle,@Image,@IDRootCategory,@IDCategorys,@Price,@PromotionPrice,@IncludeVAT,@IDAuthor" +
                                                         ",@IDPublishingCompany,@PublicationDate,@DisplayOrder,@Quantity,@Detail,@ModifileBy,@Status,@TopHot,@Tag", paremeter).SingleOrDefault();
            
            new BookCategoryModel().Create(res, e.IDCategorys);
            new BookTagModel().Create(res, e.Tags);
            return res;
        }

        public Book GetItemAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<Book>("SP_Book_GetItemAtID @ID", paremeter).SingleOrDefault();
            return res;
        }

        public bool ChangeStatusAtID(int ID)
        {
            object[] paremeter = { new SqlParameter("ID", ID) };
            var res = context.Database.SqlQuery<bool>("SP_Book_ChangedStatus @ID", paremeter).SingleOrDefault();
            return res;
        }

        

        public IEnumerable<BookShort> GetBooksAtIDCt(int IDCategory,int page,int pageSize)
        {
            object[] paremeter = { new SqlParameter("ID", IDCategory) };
            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetBookAtIDCt @ID",paremeter).ToList();
            return list.ToPagedList(page,pageSize);
        }
        public IEnumerable<BookShort> GetBooksAtIDAuthor(int IDCategory,int page,int pageSize)
        {
            object[] paremeter = { new SqlParameter("ID", IDCategory) };
            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetBookAtIDAuthor @ID", paremeter).ToList();
            return list.ToPagedList(page,pageSize);
        }
        public IEnumerable<BookShort> GetBooksAtIDPublisingCompany(int IDCategory,int page,int pageSize)
        {
            object[] paremeter = { new SqlParameter("ID", IDCategory) };
            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetBookAtIDPublisingCompany @ID", paremeter).ToList();
            return list.ToPagedList(page,pageSize);
        }
        public IEnumerable<BookShort> GetBooksAtKeyword(string IDCategory,int page,int pageSize)
        {
            object[] paremeter = { new SqlParameter("Keyword", IDCategory) };
            var list = context.Database.SqlQuery<BookShort>("SP_Book_GetBookAtKeyword @Keyword", paremeter).ToList();
            return list.ToPagedList(page,pageSize);
        }

        public int UpdateAtID(Book e)
        {
            object[] paremeter = {
                new SqlParameter("ID",e.ID),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("MetaTitle",e.MetaTitle==null?(object)DBNull.Value:e.MetaTitle),
                new SqlParameter("Image",e.Image==null?(object)DBNull.Value:e.Image),
                new SqlParameter("IDRootCategory",e.IDRootCategory==null?(object)DBNull.Value:e.IDRootCategory),
                new SqlParameter("IDCategorys",e.IDCategorys==null?(object)DBNull.Value:e.IDCategorys),
                new SqlParameter("Price",e.Price==null?(object)DBNull.Value:e.Price),
                new SqlParameter("PromotionPrice",e.PromotionPrice==null?(object)DBNull.Value:e.PromotionPrice),
                new SqlParameter("IncludeVAT",e.IncludeVAT==null?(object)DBNull.Value:e.IncludeVAT),
                new SqlParameter("IDAuthor",e.IDAuthor==null?(object)DBNull.Value:e.IDAuthor),
                new SqlParameter("IDPublishingCompany",e.IDPublishingCompany==null?(object)DBNull.Value:e.IDPublishingCompany),
                new SqlParameter("PublicationDate",e.PublicationDate==null?(object)DBNull.Value:e.PublicationDate),
                new SqlParameter("DisplayOrder",e.DisplayOrder==null?(object)DBNull.Value:e.DisplayOrder),
                new SqlParameter("Quantity",e.Quantity==null?(object)DBNull.Value:e.Quantity),
                new SqlParameter("QuantitySold",e.QuantitySoled==null?(object)DBNull.Value:e.QuantitySoled),
                new SqlParameter("Detail",e.Detail==null?(object)DBNull.Value:e.Detail),
                new SqlParameter("ModifileBy",e.ModifileBy==null?(object)DBNull.Value:e.ModifileBy),
                new SqlParameter("Status",e.Status==null?(object)DBNull.Value:e.Status),
                new SqlParameter("TopHot",e.TopHot==null?(object)DBNull.Value:e.TopHot),
                new SqlParameter("Tag",e.Tags==null?(object)DBNull.Value:e.Tags),
            };
            var res = context.Database.ExecuteSqlCommand("SP_Book_Update @ID,@Name,@MetaTitle,@Image,@IDRootCategory,@IDCategorys,@Price,@PromotionPrice,@IncludeVAT,@IDAuthor"+
                                                         ",@IDPublishingCompany,@PublicationDate,@DisplayOrder,@Quantity,@QuantitySold,@Detail,@ModifileBy,@Status,@TopHot,@Tag", paremeter);
            new BookCategoryModel().DeleteAtIDBook(e.ID);
            new BookCategoryModel().Create(e.ID, e.IDCategorys);
            new BookTagModel().DeleteAtIDBook(e.ID);
            new BookTagModel().Create(e.ID, e.Tags);
            return res;
        }
    }
}
