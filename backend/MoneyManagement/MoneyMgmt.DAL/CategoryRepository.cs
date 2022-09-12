using MoneyMgmt.Common.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyMgmt.DAL
{
    public class CategoryRepository : GenericRepository<MoneyManagementContext, Category>
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Instance of category that match category id</returns>
        public override Category Read(int id)
        {
            var category = All.FirstOrDefault(c => c.Id == id);
            return category;
        }
    }
}
