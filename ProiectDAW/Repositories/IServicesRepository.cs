using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public interface IServicesRepository
    {
        IQueryable<Service_Auto> GetServiceAutos();

        IQueryable<object> GetServiceAutosJoinAdressesOrdered();

        IQueryable<string> GetServicesFromCity(string city_name);

        Task Create(Service_Auto service);

        Task Update(Service_Auto service);

        Task Delete(Service_Auto service);

        IQueryable<Service_Auto> GetServiceById(string id);
    }
}
