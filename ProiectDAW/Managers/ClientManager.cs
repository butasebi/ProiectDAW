using ProiectDAW.Entities;
using ProiectDAW.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly IClientsRepository ClientsRepo;
        public ClientManager(IClientsRepository repo)
        {
            this.ClientsRepo = repo;
        }

        public async Task Create(Client client)
        {
            await ClientsRepo.Create(client);
        }

        public async Task Delete(Client client)
        {
            ClientsRepo.Delete(client);
        }

        public List<Client> GetClientById(string id)
        {
            return ClientsRepo.GetClientById(id).ToList();
        }

        public List<object> GetClientByServiceId(string id)
        {
            return ClientsRepo.GetClientByServiceId(id).ToList();
        }

        public List<Client> GetClients()
        {
            return ClientsRepo.GetClients().ToList();
        }

        public List<object> GetClientsServices(string ClientId)
        {
            return ClientsRepo.GetClientsServices(ClientId).ToList();
        }

        public async Task Update(Client client)
        {
            await ClientsRepo.Update(client);
        }
    }

}
