using MoneyMgmt.Common.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyMgmt.DAL
{
    public class RecordRepository : GenericRepository<MoneyManagementContext, Record>
    {
        /// <summary>
        /// Get record by id
        /// </summary>
        /// <param name="id">Record id</param>
        /// <returns>Instance of record that match record id</returns>
        public override Record Read(int id)
        {
            var record = All.FirstOrDefault(r => r.Id == id);
            return record;
        }

        public IQueryable<Record> GetRecordsByUserId(int userId)
        {
            var query = Context.Records.Where(record =>
                record.UserRecords.All(user =>
                    user.UserId.Equals(userId)));

            return query;
        }

        public bool CreateRecordByUser(Record record, int userId, int categoryId, int accountId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    record.Category = Context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    record.Account = Context.Accounts.FirstOrDefault(a => a.Id == accountId);

                    Context.Records.Add(record);

                    User user = Context.Users.FirstOrDefault(u => u.Id == userId);
                    UserRecord ur = new UserRecord
                    {
                        Record = record,
                        User = user,
                    };
                    
                    Context.UserRecords.Add(ur);

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

        public bool UpdateRecordByUser(Record record, int userId, int categoryId, int accountId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    UserRecord ur = Context.UserRecords.FirstOrDefault(x =>
                        x.RecordId == record.Id && x.UserId == userId);

                    // Doesn't exist on database
                    if (null == ur)
                    {
                        return false;
                    }

                    Record dbRecord = Read(record.Id);
                    dbRecord.Type = record.Type;
                    dbRecord.Category = record.Category;
                    dbRecord.Account = record.Account;
                    dbRecord.Description = record.Description;
                    dbRecord.Value = record.Value;
                    dbRecord.DateOfIssue = record.DateOfIssue;

                    dbRecord.Category = Context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    dbRecord.Account = Context.Accounts.FirstOrDefault(a => a.Id == accountId);

                    Context.Update(dbRecord);

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

        public bool HardDeleteRecordByUser(int recordId, int userId)
        {
            // Table impacted: Records junction, User junction
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Record record = Read(recordId);
                    IQueryable<UserRecord> ur = Context.UserRecords.Where(x =>
                        x.RecordId == record.Id && x.UserId == userId);

                    Context.Records.Remove(record);
                    Context.UserRecords.RemoveRange(ur);

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
