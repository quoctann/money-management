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
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;

        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
            accountService = new AccountService();
        }

        #region -- READ --

        /// <summary>
        /// Get single record of account by id
        /// </summary>
        /// <param name="id">Account id</param>
        /// <returns>Single record of account id</returns>
        [HttpGet("{id}")]
        //[Authorize]
        public IActionResult GetAccountById(int id)
        {
            return Ok(accountService.Read(id));
        }

        /// <summary>
        /// Get all user's accounts that created by user (with id)
        /// </summary>
        /// <param name="userId">User id that created accounts</param>
        /// <returns>Accounts that created by user with following user id</returns>
        [HttpGet("by-user/{userId}")]
        //[Authorize]
        public IActionResult GetAccountsByUserId(int userId)
        {
            return Ok(accountService.GetAccountsByUserId(userId));
        }

        #endregion

        #region -- CREATE --

        /// <summary>
        /// Create account by user (with id)
        /// </summary>
        /// <param name="data">Data to create account</param>
        /// <returns>Status code</returns>
        [HttpPost("create")]
        //[Authorize]
        public IActionResult CreateAccountByUser([FromBody] UserAccountInfo data)
        {
            Account account = new Account
            {
                Id = data.Id,
                Type = data.Type,
                Name = data.Name,
                Icon = data.Icon,
                InitialBalance = data.InitialBalance,
                CurrentBalance = data.CurrentBalance,
            };

            return Ok(accountService.CreateAccountByUser(account, data.UserId));
        }

        #endregion

        #region -- UPDATE --

        /// <summary>
        /// Update account by user (with id)
        /// </summary>
        /// <param name="data">Data to update account</param>
        /// <returns>Status code</returns>
        [HttpPost("update")]
        //[Authorize]
        public IActionResult UpdateAccountByUser([FromBody] UserAccountInfo data)
        {
            Account account = new Account
            {
                Id = data.Id,
                Type = data.Type,
                Name = data.Name,
                Icon = data.Icon,
                InitialBalance = data.InitialBalance,
                CurrentBalance = data.CurrentBalance,
            };

            return Ok(accountService.UpdateAccountByUser(account, data.UserId));
        }

        #endregion

        #region -- DELETE --

        /// <summary>
        /// Hard delete account and relative records on database
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="accountId">Account id</param>
        /// <returns></returns>
        [HttpDelete("delete/{userId}/{accountId}")]
        //[Authorize]
        public IActionResult HardDeleteCategoryByUser(int userId, int accountId)
        {
            return Ok(accountService.HardDeleteAccountByUser(accountId, userId));
        }

        #endregion

    }
}
