using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
 

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("[controller]/[action]")]
public class DetalleController : ControllerBase
{
    private readonly DetalleService _detalleService;
    private readonly ServiceContext _serviceContext;

    public DetalleController(DetalleService detalleService, ServiceContext serviceContext)
    {
        _detalleService = detalleService;
        _serviceContext = serviceContext;
    }

    [HttpPost(Name = "InsertDetalle")]
    public int Post([FromBody] Detalles_Pedido detalle)
    {
        return _detalleService.insertDetalle(detalle);
    }


}

