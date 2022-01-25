using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.Managers;
using ProiectDAW.Models;
using ProiectDAW.Repositories;
using System.Linq;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
namespace ProiectDAW.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ServiceController : Controller
    {
        private IServicesManager manager;

        public ServiceController(IServicesManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("servicesauto")]
        public async Task<IActionResult> GetServiceAutos()
        {
            var services_auto =  manager.GetServiceAutos();

            return Ok(services_auto);
        }

        [HttpGet("List all services from the database (with their adresses), ordered by name")]

        public async Task<IActionResult> GetServiceAutosJoinAdressesOrdered()
        {
            var services_auto = manager.GetServiceAutosJoinAdressesOrdered();

            return Ok(services_auto);
        }

        [HttpGet("servicesauto/byId/{id}")]

        public async Task<IActionResult> GetServiceById(string id)
        {
            var services_auto = manager.GetServiceById(id);

            return Ok(services_auto);
        }

        [HttpPost("Get services located in a city received as a parameter")]

        public async Task<IActionResult> GetServicesFromCity([FromBody] string city_name)
        {
            var services_auto = manager.GetServicesFromCity(city_name);

            return Ok(services_auto);
        }

        [HttpPost("serviceCreate")]
        public async Task<IActionResult> Create([FromBody] ServiceCreationModel servicemodel)
        {
            var newService = new Service_Auto
            {
                Id = servicemodel.Id,
                Name = servicemodel.Name
            };

            await manager.Create(newService);

            return Ok();
        }

        [HttpPost("serviceUpdate")]
        public async Task<IActionResult> Update([FromBody] ServiceCreationModel servicemodel)
        {
            var newService = new Service_Auto
            {
                Id = servicemodel.Id,
                Name = servicemodel.Name
            };
            await manager.Update(newService);

            return Ok();
        }

        [HttpPost("serviceDelete")]
        public async Task<IActionResult> Delete([FromBody] ServiceCreationModel servicemodel)
        {
            string serviceId = servicemodel.Id;
            var ServiceToDelete = manager.GetServiceById(serviceId);

            await manager.Delete(ServiceToDelete[0]);

            return Ok();
        }

    }
}
