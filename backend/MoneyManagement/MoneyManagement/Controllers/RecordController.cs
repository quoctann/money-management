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

        [HttpGet("{id}")]
        //[Authorize]
        public IActionResult GetRecordById(int id)
        {
            return Ok(recordService.Read(id));
        }

        [HttpGet("by-user/{userId}")]
        //[Authorize]
        public IActionResult GetRecordsByUserId(int userId)
        {
            return Ok(recordService.GetRecordsByUserId(userId));
        }

        [HttpGet("sum-by-date")]
        //[Authorize]
        public IActionResult SumRecordsByDateRange(
            [FromQuery(Name = "user-id")] int userId,
            [FromQuery(Name = "start-date")] DateTime startDate,
            [FromQuery(Name = "end-date")] DateTime endDate)
        {
            return Ok(recordService.SumRecordsByDateRange(userId, startDate, endDate));
        }

        [HttpGet("sum-by-category")]
        //[Authorize]
        public IActionResult SumRecordsByCategory([FromQuery(Name = "user-id")] int userId,
            [FromQuery(Name = "category-id")] int categoryId)
        {
            return Ok(recordService.SumRecordsByCategory(userId, categoryId));
        }

        [HttpGet("sum-by-account")]
        //[Authorize]
        public IActionResult SumRecordsByAccount([FromQuery(Name = "user-id")] int userId,
            [FromQuery(Name = "account-id")] int accountId)
        {
            return Ok(recordService.SumRecordsByAccount(userId, accountId));
        }

        #endregion

        #region -- CREATE --

        [HttpPost("create")]
        //[Authorize]
        public IActionResult CreateRecordByUser([FromBody] UserRecordInfo data)
        {
            Record record = new Record
            {
                Type = data.Type,
                CategoryId = data.CategoryId,
                AccountId = data.AccountId,
                Description = data.Description,
                Value = data.Value,
                DateOfIssue = data.DateOfIssue
            };

            return Ok(recordService.CreateRecordByUser(record, data.UserId, data.CategoryId, data.AccountId));
        }

        #endregion

        #region -- UPDATE --

        [HttpPost("update")]
        //[Authorize]
        public IActionResult UpdateRecordByUser([FromBody] UserRecordInfo data)
        {
            Record record = new Record
            {
                Id = data.Id,
                Type = data.Type,
                CategoryId = data.CategoryId,
                AccountId = data.AccountId,
                Description = data.Description,
                Value = data.Value,
                DateOfIssue = data.DateOfIssue
            };

            return Ok(recordService.UpdateRecordByUser(record, data.UserId, data.CategoryId, data.AccountId));
        }

        #endregion

        #region -- DELETE --

        [HttpDelete("delete/{userId}/{recordId}")]
        //[Authorize]
        public IActionResult HardDeleteRecordByUser(int userId, int recordId)
        {
            return Ok(recordService.HardDeleteRecordByUser(recordId, userId));
        }

        #endregion
    }
}
