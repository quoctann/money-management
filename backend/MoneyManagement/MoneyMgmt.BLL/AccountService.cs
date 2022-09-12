using MoneyMgmt.Common.BLL;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMgmt.BLL
{
    public class AccountService : GenericService<AccountRepository, Account>
    {
        public AccountService()
        {

        }

        public override SingleResponse Read(int id)
        {
            var res = new SingleResponse();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
    }
}
