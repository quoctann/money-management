using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class UserRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecordId { get; set; }

        public virtual Record Record { get; set; }
        public virtual User User { get; set; }
    }
}
