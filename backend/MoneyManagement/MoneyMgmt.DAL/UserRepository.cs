using MoneyMgmt.Common.DAL;
using MoneyMgmt.Common.Utils;
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

        public bool RegisterUser(User user)
        {
            User dbUser = All.FirstOrDefault(u => u.Username.Equals(user.Username) || u.Email.Equals(user.Email));
            if (null == dbUser) // New user must not already exist on db
            {
                user.Password = Utils.GetMD5HashOfString(user.Password);
                Create(user);
                return true;
            }

            return false;
        }

        public bool DeactiveUser(int userId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    User user = Read(userId);
                    user.IsActive = false;
                    Context.Users.Update(user);
                    Context.SaveChanges();
                    dbContextTransaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }

            return false;               
        }
    }
}
