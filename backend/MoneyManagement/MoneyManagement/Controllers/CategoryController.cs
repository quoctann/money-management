using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyMgmt.BLL;
using MoneyMgmt.Common.Request;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL.Models;
using MoneyMgmt.Web.NonDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        private readonly IConfiguration _config;

        public CategoryController(IConfiguration config)
        {
            _config = config;
            categoryService = new CategoryService();
        }

        #region -- READ --

        /// <summary>
        /// Get single record of category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Single record of category id</returns>
        [HttpGet("{id}")]
        //[Authorize]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(categoryService.Read(id));
        }

        /// <summary>
        /// Get all user's categories that created by user (with id)
        /// </summary>
        /// <param name="userId">User id that created categories</param>
        /// <returns>Categories that created by user with following user id</returns>
        [HttpGet("by-user/{userId}")]
        //[Authorize]
        public IActionResult GetCategoriesByUserId(int userId)
        {            
            return Ok(categoryService.GetCategoriesByUserId(userId));
        }

        #endregion

        #region -- CREATE --
        
        /// <summary>
        /// Create category by user (with id)
        /// </summary>
        /// <param name="userCategoryInfo">Data to create category</param>
        /// <returns>Status code</returns>
        [HttpPost("create")]
        //[Authorize]
        public IActionResult CreateCategoryByUser([FromBody]UserCategoryInfo data)
        {
            Category category = new Category
            {
                Id = data.Id,
                Label = data.Label,
                Icon = data.Icon,
            };

            return Ok(categoryService.CreateCategoryByUser(category, data.UserId));
        }

        #endregion

        #region -- UPDATE --

        /// <summary>
        /// Update category by user (with id)
        /// </summary>
        /// <param name="userCategoryInfo">Data to create category</param>
        /// <returns>Status code</returns>
        [HttpPost("update")]
        //[Authorize]
        public IActionResult UpdateCategoryByUser([FromBody] UserCategoryInfo data)
        {
            Category category = new Category
            {
                Id = data.Id,
                Label = data.Label,
                Icon = data.Icon,
            };

            return Ok(categoryService.UpdateCategoryByUser(category, data.UserId));
        }

        #endregion

        #region -- DELETE --

        /// <summary>
        /// Delete category by user (with id)
        /// </summary>
        /// <param name="userCategoryInfo">Data to delete category</param>
        /// <returns></returns>
        [HttpDelete("delete/{userId}/{categoryId}")]
        //[Authorize]
        public IActionResult HardDeleteCategoryByUser(int userId, int categoryId)
        {
            return Ok(categoryService.HardDeleteCategoryByUser(categoryId, userId));
        }

        #endregion
    }
}
