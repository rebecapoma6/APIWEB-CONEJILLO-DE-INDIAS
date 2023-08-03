//using Data;
//using Entitites.Entities;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Http.Cors;
//using WebApplication1.IServices;
//using WebApplication1.Services;

//namespace WebApplication1.Controllers
//{
//    [ApiController]
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    [Route("[controller]/[action]")]
//    public class ClienteController : ControllerBase
//    {
//        private readonly IClienteService _clienteService;
//        private readonly object _serviceContext;

//        public ClienteController(IClienteService clienteService)
//        {
//            _clienteService = clienteService;
//        }

//        [HttpPost(Name = "InsertCliente")]
//        public IActionResult InsertCliente([FromBody] ClientesItem cliente)
//        {
//            int clienteId = _clienteService.InsertCliente(cliente);
//            return Ok(new { ClienteId = clienteId, Message = "Cliente insertado con éxito" });
//        }

//        [HttpPut("{clienteId}", Name = "UpdateCliente")]
//        public IActionResult UpdateCliente(int clienteId, [FromBody] ClientesItem cliente)
//        {
//            cliente.ClienteId = clienteId; // Asegúrate de que el clienteId se establezca correctamente en el modelo
//            _clienteService.UpdateCliente(cliente);
//            return Ok("Cliente actualizado con éxito");
//        }

//        [HttpDelete("{clienteId}", Name = "DeleteCliente")]
//        public IActionResult DeleteCliente(int clienteId)
//        {
//            _clienteService.DeleteCliente(clienteId);
//            return Ok("Cliente eliminado con éxito");
//        }


//        [HttpGet("{clienteId}", Name = "GetCliente")]
//        public IActionResult GetCliente()//(int clienteId)
//        {
//            //var cliente = _serviceContext.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);
//            //if (cliente == null)
//            //{
//            //    return NotFound();
//            //}

//            //return Ok(cliente);

//            var cliente = _serviceContext.Set<ClientesItem>().ToList();
//            return Ok(cliente);
//        }

//    }
//}

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

        [HttpGet(Name = "GetCliente")]
        public IActionResult GetCliente()
        {
            var clientes = _clienteService.GetAllClientes();
            return Ok(clientes);
        }
    }
}







