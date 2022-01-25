using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public interface IClientsRepository
    {
        IQueryable<Client> GetClients();
        IQueryable<object> GetClientsServices(string client);

        Task Create(Client client);

        Task Update(Client client);

        Task Delete(Client client);

        IQueryable<Client> GetClientById(string client);

        IQueryable<object> GetClientByServiceId(string id);
    }
}
