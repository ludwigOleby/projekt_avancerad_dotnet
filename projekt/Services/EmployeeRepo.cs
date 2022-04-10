using Microsoft.EntityFrameworkCore;
using Models;
using projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public class EmployeeRepo : IEmployeeRepo<Employee>
    {

        private ApiDbContext _employeeRepo;
        public EmployeeRepo(ApiDbContext EmployeeContext)
        {
            _employeeRepo = EmployeeContext;
        }
        public async Task<Employee> Add(Employee newEmployee)
        {
            var result = await _employeeRepo.Employees.AddAsync(newEmployee);
            await _employeeRepo.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int employeeID)
        {
            var result = await _employeeRepo.Employees.FirstOrDefaultAsync(p => p.employeeID == employeeID);
            if (result != null)
            {
                _employeeRepo.Employees.Remove(result);
                await _employeeRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepo.Employees.ToListAsync();
        }

        public async Task<Employee> GetSingleEmployee(int employeeID)
        {
            return await _employeeRepo.Employees.FirstOrDefaultAsync(x => x.employeeID == employeeID);
        }

        public async Task<Employee> Update(Employee Employee)
        {
            var result = await _employeeRepo.Employees.FirstOrDefaultAsync(e => e.employeeID == Employee.employeeID);
            if (result != null)
            {
                result.firstName = Employee.firstName;
                result.lastName = Employee.lastName;
                result.phone = Employee.phone;
                result.project = Employee.project;
                result.timeReports = Employee.timeReports;

                await _employeeRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
