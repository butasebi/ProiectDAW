using Microsoft.EntityFrameworkCore;
using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly ProiectDAWContext db;

        public ServicesRepository(ProiectDAWContext proiectDAWContext)
        {
            this.db = proiectDAWContext;
        }

        public async Task Create(Service_Auto service)
        {
            await db.Service_Autos.AddAsync(service);

            await db.SaveChangesAsync();
        }

        public async Task Update(Service_Auto service)
        {
            db.Service_Autos.Update(service);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Service_Auto service)
        {
            db.Service_Autos.Remove(service);

            await db.SaveChangesAsync();
        }

        public IQueryable<Service_Auto> GetServiceAutos()
        {
            var services_auto = db.Service_Autos;

            return services_auto;
        }

        public IQueryable<object> GetServiceAutosJoinAdressesOrdered()
        {
            var services_auto = db.Service_Autos
                                .Include(x => x.ServiceAutoAdress)
                                .OrderBy(x => x.Name);
            return services_auto;
        }

        public IQueryable<Service_Auto> GetServiceById(string id)
        {
            var services_auto = db.Service_Autos
                                .Where(x => x.Id == id);

            return services_auto;
        }

        public IQueryable<string> GetServicesFromCity(string city_name)
        {
            var services_auto = db.Service_Autos
                                .Include(x => x.ServiceAutoAdress)
                                .Where(x => x.ServiceAutoAdress.City == city_name)
                                .Select(x => x.Name);

            return services_auto;
        }

    }
}
