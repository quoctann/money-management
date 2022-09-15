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

        public SingleResponse GetAccountsByUserId(int userId)
        {
            var res = new SingleResponse();
            var m = _rep.GetAccountsByUserId(userId);
            res.Data = m;
            return res;
        }

        public SingleResponse CreateAccountByUser(Account account, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.CreateAccountByUser(account, userId);

            if (result)
            {
                res.Code = "201";
                res.SetMessage("Create successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Create failed");
            }

            return res;
        }

        public SingleResponse UpdateAccountByUser(Account account, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.UpdateAccountByUser(account, userId);

            if (result)
            {
                res.Code = "200";
                res.SetMessage("Update successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Update failed");
            }

            return res;
        }

        public SingleResponse HardDeleteAccountByUser(int accountId, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.HardDeleteAccountByUser(accountId: accountId, userId: userId);

            if (result)
            {
                res.Code = "200";
                res.SetMessage("Delete successfully");
            }
            else
            {
                res.SetError(code: "400", message: "Delete failed");
            }

            return res;
        }
    }
}
