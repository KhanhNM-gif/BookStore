using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        OnlineShopContext context = null;

        public UserModel()
        {
            context = new OnlineShopContext();
        }

        public int Create(Account e)
        {
            object[] paremeter = {
                new SqlParameter("UserName",e.UserName==null?(object)DBNull.Value:e.UserName),
                new SqlParameter("Password",e.Password==null?(object)DBNull.Value:e.Password),
                new SqlParameter("Name",e.Name==null?(object)DBNull.Value:e.Name),
                new SqlParameter("Gender",e.Gender==null?(object)DBNull.Value:e.Gender),
                new SqlParameter("PhoneNumber",e.PhoneNumber==null?(object)DBNull.Value:e.PhoneNumber),
                new SqlParameter("Email",e.Email==null?(object)DBNull.Value:e.Email),
                new SqlParameter("Birthday",e.Birthday==null?(object)DBNull.Value:e.Birthday),
                new SqlParameter("Address",e.Address==null?(object)DBNull.Value:e.Address),
            };
            var res = context.Database.ExecuteSqlCommand("SP_Account_Create @UserName,@Password ,@Name,@Gender,@PhoneNumber,@Email,@Birthday,@Address", paremeter);
            return res;
        }

        public bool Login(string Username ,string Password)
        {
            object[] paremeter = {
                new SqlParameter("UserName",Username==null?(object)DBNull.Value:Username),
                new SqlParameter("Password",Password==null?(object)DBNull.Value:Password),
            };
            var res = context.Database.SqlQuery<bool>("SP_Account_Login @UserName,@Password", paremeter).SingleOrDefault();
            return res;
        }
        public Account GetUser(string Username)
        {
            object[] paremeter = {
                new SqlParameter("Username",Username==null?(object)DBNull.Value:Username),
            };
            var res = context.Database.SqlQuery<Account>("SP_Account_GetUser @Username", paremeter).SingleOrDefault();
            return res;
        }
    }
}
