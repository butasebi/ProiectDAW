using ProiectDAW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public interface IClientManager
    {
        List <Client> GetClients();
        List<object> GetClientsServices( string ClientId);

        Task Create(Client client);

        Task Update(Client client);

        Task Delete(Client client);

        List<Client> GetClientById(string id);

        List<object> GetClientByServiceId(string id);
    }
}
