using ProiectDAW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public interface IEmployeeManager
    {
        List<Employee> GetEmployees();

        Task Create(Employee employee, string Service_AutoId = "0");

        Task Update(Employee employee, string Service_AutoId = "0");

        Task Delete(Employee employee);

        List<Employee> GetEmployeeById(string id);

        List<object> GetEmployeesByServiceId(string id);
    }
}
