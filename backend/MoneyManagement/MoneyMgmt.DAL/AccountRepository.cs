using MoneyMgmt.Common.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyMgmt.DAL
{
    public class AccountRepository : GenericRepository<MoneyManagementContext, Account>
    {
        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns>Instance of account that match account id</returns>
        public override Account Read(int id)
        {
            var account = All.FirstOrDefault(a => a.Id == id);
            return account;
        }        
    }
}
