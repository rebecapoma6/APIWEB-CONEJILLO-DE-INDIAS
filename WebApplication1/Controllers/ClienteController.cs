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
        private readonly ClienteService _clienteService;
        private readonly ServiceContext _serviceContext;

        public ClienteController(ClienteService clienteService, ServiceContext serviceContext)
        {
            _clienteService = clienteService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertCliente")]
        public int Post([FromBody] ClientesItem cliente)
        {
            return _clienteService.InsertCliente(cliente);
        }
    }
}

