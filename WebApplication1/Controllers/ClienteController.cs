using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ServiceContext _serviceContext;

        public ClienteController(IClienteService clienteService, ServiceContext serviceContext)
        {
            _clienteService = clienteService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertCliente")]
        public int Post([FromBody] ClientesItem cliente)
        {
            return _clienteService.InsertCliente(cliente);
        }

        [HttpPatch(Name = "ClienteModificado")]
        public int Patch([FromBody] ClientesItem clienteModificado)
        {
            return _clienteService.InsertCliente(clienteModificado);
        }
        [HttpPatch(Name = "ClienteBorrado")]
        public int Patch([FromBody] ClientesItem clienteBorrado)
        {
            return _clienteService.DeleteCliente(clienteBorrado);
        }




    }
}

