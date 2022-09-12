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
    }
}
