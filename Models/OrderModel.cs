using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderModel
    {
        private OnlineShopContext context = null;
        public OrderModel()
        {
            context = new OnlineShopContext();
        }
        public int Create(Order e)
        {

            object[] paremeter = {
                new SqlParameter("CustomerID",e.CustomerID==null?(object)DBNull.Value:e.CustomerID),
                new SqlParameter("ShipEmail",e.ShipEmail==null?(object)DBNull.Value:e.ShipEmail),
                new SqlParameter("ShipName",e.ShipName==null?(object)DBNull.Value:e.ShipName),
                new SqlParameter("ShipMobile",e.ShipMobile==null?(object)DBNull.Value:e.ShipMobile),
                new SqlParameter("ShipAddress",e.ShipAddress==null?(object)DBNull.Value:e.ShipAddress),
                new SqlParameter("Note",e.Note==null?(object)DBNull.Value:e.Note),
            };
            var res = context.Database.SqlQuery<int>("SP_Order_Create @CustomerID,@ShipEmail,@ShipName,@ShipMobile,@ShipAddress,@Note", paremeter).SingleOrDefault();
            return res;
        }
    }
}
