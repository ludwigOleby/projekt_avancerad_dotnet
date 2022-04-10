using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace projekt.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee
            modelBuilder.Entity<Employee>().HasData(new Employee { employeeID = 1, firstName = "Ludwig", lastName = "Oleby", phone = "0736004656" });
            modelBuilder.Entity<Employee>().HasData(new Employee { employeeID = 2, firstName = "Anas", lastName = "Qlok", phone = "0701231231" });
            modelBuilder.Entity<Employee>().HasData(new Employee { employeeID = 3, firstName = "Tobias", lastName = "Qlok", phone = "0701231232" });
            modelBuilder.Entity<Employee>().HasData(new Employee { employeeID = 4, firstName = "Reidar", lastName = "Qlok", phone = "0701231233" });

            // Seed Projects
            modelBuilder.Entity<Projects>().HasData(new Projects { employeeID = 1, projectID = 1, projectName = "C#" });
            modelBuilder.Entity<Projects>().HasData(new Projects { employeeID = 2, projectID = 2, projectName = "C#" });
            modelBuilder.Entity<Projects>().HasData(new Projects { employeeID = 3, projectID = 3, projectName = "HTML" });
            modelBuilder.Entity<Projects>().HasData(new Projects { employeeID = 4, projectID = 4, projectName = "CSS" });

            // Seed TimeReports
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { reportID = 1, employeeID = 1, date = 20220410, Week = 1, reportedHours = 37.5 });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { reportID = 2, employeeID = 2, date = 20220410, Week = 1, reportedHours = 20 });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { reportID = 3, employeeID = 3, date = 20220417, Week = 2, reportedHours = 40 });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { reportID = 4, employeeID = 4, date = 20220417, Week = 2, reportedHours = 30 });


        }
    }
}
