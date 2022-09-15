using System;
using System.Collections.Generic;

#nullable disable

namespace MoneyMgmt.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Records = new HashSet<Record>();
            UserCategories = new HashSet<UserCategory>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; set; }
    }
}
