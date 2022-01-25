using ProiectDAW.Entities;
using ProiectDAW.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeesRepository EmployeesRepo;
        public EmployeeManager(IEmployeesRepository repo)
        {
            this.EmployeesRepo = repo;
        }

        public async Task Create(Employee employee, string Service_AutoId = "0")
        {
            await EmployeesRepo.Create(employee, Service_AutoId);
        }

        public async Task Delete(Employee employee)
        {
            EmployeesRepo.Delete(employee);
        }

        public List<Employee> GetEmployeeById(string id)
        {
            return EmployeesRepo.GetEmployeeById(id).ToList();
        }

        public List<Employee> GetEmployees()
        {
            return EmployeesRepo.GetEmployees().ToList();
        }

        public List<object> GetEmployeesByServiceId(string id)
        {
            return EmployeesRepo.GetEmployeesByServiceId(id).ToList();
        }

        public async Task Update(Employee employee, string Service_AutoId = "0")
        {
            await EmployeesRepo.Update(employee, Service_AutoId);
        }
    }
}
