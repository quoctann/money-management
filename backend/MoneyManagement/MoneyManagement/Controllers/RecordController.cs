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
    public class RecordController : ControllerBase
    {
        private readonly RecordService recordService;

        private readonly IConfiguration _config;

        public RecordController(IConfiguration config)
        {
            _config = config;
            recordService = new RecordService();

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
