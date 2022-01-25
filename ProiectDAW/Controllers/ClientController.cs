using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.Managers;
using ProiectDAW.Models;
using System;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ClientController : Controller
    {
        private IClientManager manager;

        public ClientController(IClientManager manager)
        {
            this.manager = manager;
        }
        [HttpGet("List with all the clients from the database")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetClients()
        {
            var clients = manager.GetClients();

            return Ok(clients);
        }

        [HttpGet("clients/byServiceId/{id}")]
        public async Task<IActionResult> GetClientsByServiceId(string id)
        {
            var clients = manager.GetClientByServiceId(id);

            return Ok(clients);
        }

        [HttpPost("List with all the services attended by a client")]
        public async Task<IActionResult> GetClientsServices([FromBody] String ClientId)
        {
            var clients = manager.GetClientsServices(ClientId);

            return Ok(clients);
        }

        [HttpPost("Add a new client")]
        public async Task<IActionResult> Create([FromBody] ClientCreationModel clientmodel)
        {
            var newClient = new Client
            {
                Id = clientmodel.Id,
                FirstName = clientmodel.FirstName,
                LastName = clientmodel.LastName,
                RegisterDay = DateTime.Now
            };

            await manager.Create(newClient);

            return Ok();
        }

        [HttpPost("Update an already existing client")]
        public async Task<IActionResult> Update([FromBody] ClientCreationModel clientmodel)
        {
            var newClient = new Client
            {
                Id = clientmodel.Id,
                FirstName = clientmodel.FirstName,
                LastName = clientmodel.LastName,
                RegisterDay = DateTime.Now
            };
            await manager.Update(newClient);

            return Ok();
        }

        [HttpPost("Delete an already existing client")]
        public async Task<IActionResult> Delete([FromBody] string serviceId)
        {
            var ClientToDelete = manager.GetClientById(serviceId);

            await manager.Delete(ClientToDelete[0]);

            return Ok();
        }
    }
}
