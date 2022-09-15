using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMgmt.Web.NonDbModels
{
    public class UserAccountInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int InitialBalance { get; set; }
        public int CurrentBalance { get; set; }
        public int UserId { get; set; }
    }
}
