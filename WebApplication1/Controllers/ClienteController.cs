using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost(Name = "InsertCliente")]
        public IActionResult InsertCliente([FromBody] ClientesItem cliente)
        {
            int clienteId = _clienteService.InsertCliente(cliente);
            return Ok(new { ClienteId = clienteId, Message = "Cliente insertado con éxito" });
        }

        [HttpPut("{clienteId}", Name = "UpdateCliente")]
        public IActionResult UpdateCliente(int clienteId, [FromBody] ClientesItem cliente)
        {
            cliente.ClienteId = clienteId; // Asegúrate de que el clienteId se establezca correctamente en el modelo
            _clienteService.UpdateCliente(cliente);
            return Ok("Cliente actualizado con éxito");
        }

        [HttpDelete("{clienteId}", Name = "DeleteCliente")]
        public IActionResult DeleteCliente(int clienteId)
        {
            _clienteService.DeleteCliente(clienteId);
            return Ok("Cliente eliminado con éxito");
        }
    }
}







