using HRMService.Context;
using HRMService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly AppDbContext _dbContext;

        public DepartmentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/getDepartments")]
        public ActionResult<IEnumerable<Department>> GetDepartment()
        {
            return _dbContext.Departments;
        }

        [HttpPost("/addDepartment")]
        public async Task<ActionResult> AddDep(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return Ok("Department Added Succesfully!");
        }

        [HttpPut("/updateDepartment")]
        public async Task<ActionResult> UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
            return Ok("Department Details Updated Successfully!");
        }

        [HttpDelete("/deleteDepartment/{depId:int}")]
        public async Task<ActionResult> DeleteDepartment(int depID)
        {
            var dep = await _dbContext.Departments.FindAsync(depID);
            _dbContext.Departments.Remove(dep);
            await _dbContext.SaveChangesAsync();
            return Ok($"Department {depID} has been deleted!");
        }


    }
}
