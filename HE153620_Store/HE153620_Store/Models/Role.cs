using System;
using System.Collections.Generic;

namespace HE153620_Store.Models
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
            staff = new HashSet<staff>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
