using System;
using System.Collections.Generic;

namespace TravelManagementApp.Models
{
    public partial class Login
    {
        public Login()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
