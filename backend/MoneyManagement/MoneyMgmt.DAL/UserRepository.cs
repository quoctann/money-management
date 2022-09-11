using MoneyMgmt.Common.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyMgmt.DAL
{
    public class UserRepository : GenericRepository<MoneyManagementContext, User>
    {
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>Instance of User</returns>
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(u => u.Id == id);

            return res;
        }

        /// <summary>
        /// Get User by username
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <returns>Instance of User</returns>
        public User GetUserByUsername(string username)
        {
            var res = All.FirstOrDefault(u => u.Username.Equals(username));

            return res;
        }
    }
}
