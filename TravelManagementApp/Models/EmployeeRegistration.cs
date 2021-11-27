using System;
using System.Collections.Generic;

namespace TravelManagementApp.Models
{
    public partial class EmployeeRegistration
    {
        public EmployeeRegistration()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
