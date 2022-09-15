using MoneyMgmt.Common.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<Category> GetCategoriesByUserId(int userId)
        {
            var query = Context.Categories.Where(category =>
                category.UserCategories.All(user => 
                    user.UserId.Equals(userId)));

            return query;            
        }

        public bool CreateCategoryByUser(Category category, int userId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {   
                    UserCategory uc = new UserCategory
                    {
                        Category = category,
                        UserId = userId
                    };

                    Context.Categories.Add(category);
                    Context.UserCategories.Add(uc);

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

        public bool UpdateCategoryByUser(Category category, int userId)
        {
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    UserCategory uc = Context.UserCategories.FirstOrDefault(x =>
                        x.CategoryId == category.Id && x.UserId == userId);

                    // Doesn't exist on database
                    if (null == uc)
                    {
                        return false;
                    }

                    Category dbCategory = Read(category.Id);
                    dbCategory.Label = category.Label;
                    dbCategory.Icon = category.Icon;

                    Context.Update(dbCategory);

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

        public bool HardDeleteCategoryByUser(int categoryId, int userId)
        {
            // Table impacted: Records junction, User junction
            using (Context)
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Category category = Read(categoryId);
                    IQueryable<UserCategory> uc = Context.UserCategories.Where(x =>
                        x.CategoryId == category.Id && x.UserId == userId);
                    IQueryable<Record> records = Context.Records.Where(rc =>
                        rc.CategoryId == categoryId);

                    Context.Categories.Remove(category);
                    Context.UserCategories.RemoveRange(uc);
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
