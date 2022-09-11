using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class Account
    {
        public Account()
        {
            Records = new HashSet<Record>();
            UserAccounts = new HashSet<UserAccount>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int InitialBalance { get; set; }
        public int CurrentBalance { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
