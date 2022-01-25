using Microsoft.EntityFrameworkCore;
using ProiectDAW.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ProiectDAWContext db;

        public ClientsRepository(ProiectDAWContext proiectDAWContext)
        {
            this.db = proiectDAWContext;
        }

        public async Task Create(Client client)
        {
            await db.Clients.AddAsync(client);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            db.Clients.Remove(client);

            await db.SaveChangesAsync();
        }

        public IQueryable<Client> GetClientById(string client)
        {
            var clients = db.Clients
                          .Where(x => x.Id == client);

            //if (clients.ToList().Count() != 1)
            //    return "Error: client with id: " + client + " does not exist!";

            return clients;
        }

        public IQueryable<object> GetClientByServiceId(string id)
        {
            var clients = from client in db.Clients
                          join clientservice in db.Service_AutoClients
                          on client.Id equals clientservice.ClientId
                          where clientservice.Service_AutoId == id
                          select new { client.Id, client.FirstName, client.LastName, client.RegisterDay };
            
            return clients;
        }
        public IQueryable<Client> GetClients()
        {
            var clients = db.Clients;

            return clients;
        }

        public IQueryable<object> GetClientsServices(string client)
        {
            var service_autos = db.Service_AutoClients
                                .Include(x => x.Service_Auto)
                                .Where (x => x.ClientId == client);

            return service_autos;
        }

        public async Task Update(Client client)
        {
            db.Clients.Update(client);

            await db.SaveChangesAsync();
        }
    }
}
