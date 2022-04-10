using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        [Key]
        public int employeeID{ get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public ICollection<Projects> project { get; set; }
        public ICollection<TimeReport> timeReports { get; set; }
    }
}
