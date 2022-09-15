using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMgmt.Web.NonDbModels
{
    public class UserRecordInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public int UserId { get; set; }
    }
}
