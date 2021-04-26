using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderDetailModel
    {
        private OnlineShopContext context = null;
        public OrderDetailModel()
        {
            context = new OnlineShopContext();
        }
        public int Create(int? IDOrder,int? IDProduct,int? Quantity,decimal? Price)
        {
            object[] paremeter = {
                new SqlParameter("IDOrder",IDOrder==null?(object)DBNull.Value:IDOrder),
                new SqlParameter("IDProduct",IDProduct==null?(object)DBNull.Value:IDProduct),
                new SqlParameter("Quantity",Quantity==null?(object)DBNull.Value:Quantity),
                new SqlParameter("Price",Price==null?(object)DBNull.Value:Price),
            };
            var res = context.Database.ExecuteSqlCommand("SP_OrderDetail_Create @IDOrder,@IDProduct,@Quantity,@Price", paremeter);
            return res;
        }
    }
}
