using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Dto;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbContext;

        public EmployeesController(ApplicationDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() => Ok(_dbContext.Employees.ToList());

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto update) 
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            employee.Email = update.Email;
            employee.Name = update.Name;
            employee.Salary = update.Salary;
            employee.Phone = update.Phone;
            //_dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employee = new Employee() 
            { 
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email ,
                Phone = addEmployeeDto.Phone ,
                Salary = addEmployeeDto.Salary
            };
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return Ok("Deleted");
        }

    }
}
