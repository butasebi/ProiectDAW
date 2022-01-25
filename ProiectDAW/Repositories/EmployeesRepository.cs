using Microsoft.EntityFrameworkCore;
using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ProiectDAWContext db;

        public EmployeesRepository(ProiectDAWContext proiectDAWContext)
        {
            this.db = proiectDAWContext;
        }

        public async Task Create(Employee employee, string ServiceAutoId)
        {
            if(ServiceAutoId != "0")
            {
                var aux = db.Service_Autos
                                        .Where(x => x.Id == ServiceAutoId).ToList();
                employee.Service_Auto = aux[0];
            }
            await db.Employees.AddAsync(employee);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Employee employee)
        {
            db.Employees.Remove(employee);

            await db.SaveChangesAsync();
        }

        public IQueryable<Employee> GetEmployeeById(string employee)
        {
            var employees = db.Employees
                            .Where(x => x.Id == employee);

            return employees;
        }

        public IQueryable<Employee> GetEmployees()
        {
            var employees = db.Employees;

            return employees;
        }

        public IQueryable<object> GetEmployeesByServiceId(string id)
        {
            var employees = db.Employees
                            .Include(x => x.Service_Auto)
                            .Where  (x => x.Service_Auto.Id == id)
                            .Select (x => new {x.Id, x.FirstName, x.LastName, x.Position});
                
            return employees;
        }

        public async Task Update(Employee employee, string ServiceAutoId)
        {
            if (ServiceAutoId != "0")
            {
                var aux = db.Service_Autos
                                        .Where(x => x.Id == ServiceAutoId).ToList();
                employee.Service_Auto = aux[0];
            }
            db.Employees.Update(employee);

            await db.SaveChangesAsync();
        }
    }
}
