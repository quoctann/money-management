using MoneyMgmt.Common.BLL;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL;
using MoneyMgmt.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMgmt.BLL
{
    public class CategoryService : GenericService<CategoryRepository, Category>
    {
        public CategoryService()
        {

        }

        public override SingleResponse Read(int id)
        {
            var res = new SingleResponse();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        public SingleResponse GetCategoriesByUserId(int userId)
        {
            var res = new SingleResponse();
            var m = _rep.GetCategoriesByUserId(userId);
            res.Data = m;
            return res;
        }

        public SingleResponse CreateCategoryByUser(Category category, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.CreateCategoryByUser(category, userId);

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

        public SingleResponse UpdateCategoryByUser(Category category, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.UpdateCategoryByUser(category, userId);

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

        public SingleResponse HardDeleteCategoryByUser(int categoryId, int userId)
        {
            var res = new SingleResponse();
            bool result = _rep.HardDeleteCategoryByUser(categoryId: categoryId, userId: userId);

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
