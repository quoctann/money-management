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

        #endregion

        #region -- CREATE --

        #endregion

        #region -- UPDATE --

        #endregion

        #region -- DELETE --

        #endregion
    }
}
