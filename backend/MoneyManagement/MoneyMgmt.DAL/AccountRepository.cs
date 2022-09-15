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

        public IQueryable<Account> GetAccountsByUserId(int userId)
        {
            var query = Context.Accounts.Where(account =>
                account.UserAccounts.All(user =>
                    user.UserId.Equals(userId)));

            return query;
        }

        public bool CreateAccountByUser(Account account, int userId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    UserAccount ua = new UserAccount
                    {
                        Account = account,
                        UserId = userId
                    };

                    Context.Accounts.Add(account);
                    Context.UserAccounts.Add(ua);

                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }

                return false;
            }
        }

        public bool UpdateAccountByUser(Account account, int userId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    UserAccount ua = Context.UserAccounts.FirstOrDefault(x =>
                        x.AccountId == account.Id && x.UserId == userId);

                    // Doesn't exist on database
                    if (null == ua)
                    {
                        return false;
                    }

                    Account dbAccount = Read(account.Id);                    
                    dbAccount.Type = account.Type;
                    dbAccount.Icon = account.Icon;
                    dbAccount.Name = account.Name;
                    dbAccount.InitialBalance = account.InitialBalance;
                    dbAccount.CurrentBalance = account.CurrentBalance;

                    Context.Update(dbAccount);

                    Context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }

                return false;
            }
        }

        public bool HardDeleteAccountByUser(int accountId, int userId)
        {
            // Table impacted: Records junction, User junction
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Account account = Read(accountId);
                    IQueryable<UserAccount> ua = Context.UserAccounts.Where(x =>
                        x.AccountId == account.Id && x.UserId == userId);
                    IQueryable<Record> records = Context.Records.Where(rc =>
                        rc.AccountId == accountId);

                    Context.Accounts.Remove(account);
                    Context.UserAccounts.RemoveRange(ua);
                    Context.Records.RemoveRange(records);

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
