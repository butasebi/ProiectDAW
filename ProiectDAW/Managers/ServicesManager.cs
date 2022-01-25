using ProiectDAW.Entities;
using ProiectDAW.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public class ServicesManager : IServicesManager
    {
        private readonly IServicesRepository ServicesRepo;

        public ServicesManager(IServicesRepository repo)
        {
            this.ServicesRepo = repo;
        }

        public async Task Create(Service_Auto service)
        {
            await ServicesRepo.Create(service);
        }

        public async Task Delete(Service_Auto service)
        {
            ServicesRepo.Delete(service);
        }

        public List<Service_Auto> GetServiceAutos()
        {
            return ServicesRepo.GetServiceAutos().ToList();
        }

        public List<object> GetServiceAutosJoinAdressesOrdered()
        {
            return ServicesRepo.GetServiceAutosJoinAdressesOrdered().ToList();
        }

        public List<Service_Auto> GetServiceById(string id)
        {
            return ServicesRepo.GetServiceById(id).ToList();
        }

        public List<string> GetServicesFromCity(string city_name)
        {
            return ServicesRepo.GetServicesFromCity(city_name).ToList();
        }

        public async Task Update(Service_Auto service)
        {
            await ServicesRepo.Update(service);
        }
    }


}
