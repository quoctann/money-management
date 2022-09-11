using MoneyMgmt.Common.BLL;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMgmt.BLL
{
    public class UserService : GenericService<UserRepository, User>
    {
        public override SingleResponse Read(int id)
        {
            var res = new SingleResponse();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        /// <summary>
        /// Get User by username
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <returns>Instance of User</returns>
        public User GetUserByUsername(string username)
        {
            var data = _rep.GetUserByUsername(username);
            return data;
        }

        public UserService()
        {

        }
    }
}
