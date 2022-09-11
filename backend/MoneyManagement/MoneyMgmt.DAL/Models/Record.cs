using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class Record
    {
        public Record()
        {
            UserRecords = new HashSet<UserRecord>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime? DateOfIssue { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<UserRecord> UserRecords { get; set; }
    }
}
