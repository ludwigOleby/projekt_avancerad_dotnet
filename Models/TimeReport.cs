using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TimeReport
    {
        [Key]
        public int reportID { get; set; }

        public int Week { get; set; }
        public int date { get; set; }
        public double reportedHours { get; set; }
        public Employee Employee { get; set; }
        public int employeeID { get; set; }

        //TODO Properties that defines the time and date could be changed from int/double to DateTime in the future to ensure more accurate reporting

    }
}
