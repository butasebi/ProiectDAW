using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public interface IEmployeesRepository
    {
        IQueryable<Employee> GetEmployees();

        Task Create(Employee employee, string Service_AutoId);

        Task Update(Employee employee, string Service_AutoId);

        Task Delete(Employee employee);

        IQueryable<Employee> GetEmployeeById(string employee);

        IQueryable<object> GetEmployeesByServiceId(string id);
    }
}
