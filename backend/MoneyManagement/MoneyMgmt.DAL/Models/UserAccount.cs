using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
