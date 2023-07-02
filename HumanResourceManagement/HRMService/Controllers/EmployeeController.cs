using HRMService.Context;
using HRMService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly AppDbContext _dbContext;

        public EmployeeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/getAllEmployees")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return _dbContext.Employees;
        }

        [HttpGet("/getEmployee/{empId:int}")]
        public async Task<ActionResult<Employee>> GetById(int empId)
        {
            var employee = await _dbContext.Employees.FindAsync(empId);
            return employee;
        }

        [HttpPost("/addEmployee")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok("Employee Added Succesfully!");
        }

        [HttpPut("/updateEmployee")]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
            return Ok("Employee Details Updated Successfully!");
        }

        [HttpDelete("/removeEmployee/{empId:int}")]
        public async Task<ActionResult> removeEmployee(int empId)
        {
            var emp = await _dbContext.Employees.FindAsync(empId);
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Ok($"Employee {empId} has been deleted!");
        }






    }
}
