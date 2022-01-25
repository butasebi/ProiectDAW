using ProiectDAW.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public interface IServicesManager
    {
       List <Service_Auto> GetServiceAutos();

       List <object> GetServiceAutosJoinAdressesOrdered();

       List <string> GetServicesFromCity(string city_name);

       Task Create(Service_Auto service);

       Task Update(Service_Auto service);

       Task Delete(Service_Auto service);

       List <Service_Auto> GetServiceById(string id);
    }
}
