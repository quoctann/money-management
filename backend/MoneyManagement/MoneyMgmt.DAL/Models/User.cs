using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class User
    {
        public User()
        {
            UserAccounts = new HashSet<UserAccount>();
            UserCategories = new HashSet<UserCategory>();
            UserRecords = new HashSet<UserRecord>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public string CurrencyUnit { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; set; }
        public virtual ICollection<UserRecord> UserRecords { get; set; }
    }
}
