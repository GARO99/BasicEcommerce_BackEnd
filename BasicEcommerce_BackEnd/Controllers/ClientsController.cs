using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util;
using BasicEcommerce_BackEnd.Util.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicEcommerce_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly Lazy<IClientService> LazyClientService;
        private IClientService ClientService => LazyClientService.Value;

        public ClientsController(Lazy<IClientService> lazyClientService)
        {
            LazyClientService = lazyClientService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all clients", Description = "Gets all clients")]
        [SwaggerResponse(200, Description = "Clients list", Type = typeof(ICollection<Client>))]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.ClientService.GetAll());
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a client by id", Description = "Gets a client by id")]
        [SwaggerResponse(200, Description = "Client info", Type = typeof(ICollection<Client>))]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(this.ClientService.GetById(id));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a client", Description = "Create a client")]
        [SwaggerResponse(200, Description = "Client created", Type = typeof(Client))]
        public IActionResult Post([FromBody] ClientRequest clientRequest)
        {
            try
            {
                return Ok(this.ClientService.Create(clientRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpPut()]
        [SwaggerOperation(Summary = "Update a client", Description = "Update a client")]
        [SwaggerResponse(200, Description = "Product updated", Type = typeof(Client))]
        public IActionResult Put([FromBody] ClientRequest clientRequest)
        {
            try
            {
                return Ok(this.ClientService.Update(clientRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a client by id", Description = "Delete a client by id")]
        [SwaggerResponse(200, Description = "Success messages", Type = typeof(string))]
        public IActionResult Delete(string id)
        {
            try
            {
                this.ClientService.Delete(id);
                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
