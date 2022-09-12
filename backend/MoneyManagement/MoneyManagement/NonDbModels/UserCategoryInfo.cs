using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoneyMgmt.Web.NonDbModels
{
    public class UserCategoryInfo
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public int UserId { get; set; }
    }
}
