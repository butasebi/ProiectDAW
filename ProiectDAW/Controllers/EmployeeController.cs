using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.Managers;
using ProiectDAW.Models;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace ProiectDAW.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeManager manager;

        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("List with all the employees from the database")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetEmployees()
        {
            var services_auto = manager.GetEmployees();

            return Ok(services_auto);
        }

        [HttpGet("employees/byServiceId/{id}")]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetEmployeesByServiceId(string id)
        {
            var employees = manager.GetEmployeesByServiceId(id);

            return Ok(employees);
        }

        [HttpPost("employees/employeeCreate")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreationModel employeemodel)
        {
            var newEmployee = new Employee
            {
                Id = employeemodel.Id,
                FirstName = employeemodel.FirstName,
                LastName = employeemodel.LastName,
                Position = employeemodel.Position,
                Service_Auto = null
            };
            if (employeemodel.Service_AutoId == "")
            {
                await manager.Create(newEmployee);
            }
            else
            {
                await manager.Create(newEmployee, employeemodel.Service_AutoId);
            }
            return Ok();
        }

        [HttpPost("employees/employeeUpdate")]
        public async Task<IActionResult> Update([FromBody] EmployeeCreationModel employeemodel)
        {
            var newEmployee = new Employee
            {
                Id = employeemodel.Id,
                FirstName = employeemodel.FirstName,
                LastName = employeemodel.LastName,
                Position = employeemodel.Position,
                Service_Auto = null
            };
            if (employeemodel.Service_AutoId == "")
            {
                await manager.Update(newEmployee);
            }
            else
            {
                await manager.Update(newEmployee, employeemodel.Service_AutoId);
            }
            return Ok();
        }

        [HttpPost("employees/employeeDelete")]
        public async Task<IActionResult> Delete([FromBody] EmployeeCreationModel employeemodel)
        {
            string employeeId = employeemodel.Id;
            var EmployeeToDelete = manager.GetEmployeeById(employeeId);

            await manager.Delete(EmployeeToDelete[0]);

            return Ok();
        }

    }
}
