using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using projekt.Models;
using projekt.Services;

namespace projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepo<Employee> _Employee;
        public EmployeeController(IEmployeeRepo<Employee> Employee)
        {
            _Employee = Employee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _Employee.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add(Employee newEmployee)
        {
            try
            {
                if (newEmployee == null)
                {
                    return BadRequest();
                }
                var CreatedEmployee = await _Employee.Add(newEmployee);
                return CreatedAtAction(nameof(GetEmployees), new { id = CreatedEmployee.employeeID }, CreatedEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>>Update(int id, Employee newEmployee)
        {
            try
            {
                if (id != newEmployee.employeeID)
                {
                    return BadRequest("Employee id does not match!");
                }
                var employeeToupdate = await _Employee.GetSingleEmployee(id);
                if (employeeToupdate == null)
                {
                    return NotFound($"Employee with {id} not found...");
                }
                return await _Employee.Update(newEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var employeeToDelete = await _Employee.GetSingleEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with {id} not found...");
                }
                return await _Employee.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            var result = await _Employee.GetSingleEmployee(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

    }
}
