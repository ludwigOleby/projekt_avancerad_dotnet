using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Projects
    {
        [Key]
        public int projectID { get; set; }
        public string projectName { get; set; }
        public Employee employee { get; set; }
        public int employeeID { get; set; }
    }
}
