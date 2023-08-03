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
    private readonly IDetalleService _detalleService;
    private readonly ServiceContext _serviceContext;

    public DetalleController(IDetalleService detalleService, ServiceContext serviceContext)
    {
        _detalleService = detalleService;
        _serviceContext = serviceContext;
    }

    [HttpPost(Name = "InsertDetalle")]
    public int Post([FromBody] Detalles_Pedido detalle)
    {
        return _detalleService.insertDetalle(detalle);
    }



    [HttpPut("{detalleId}", Name = "UpdateDetalle")]
    public IActionResult UpdateDetalle(int detalleId, [FromBody] Detalles_Pedido detalle)
    {
        try
        {
            var existingDetalle = _serviceContext.Detalles.FirstOrDefault(d => d.IdPedido == detalleId);
            if (existingDetalle == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades específicas del detalle según tus necesidades
            existingDetalle.IdCliente = detalle.IdCliente;
            existingDetalle.Pedido = detalle.Pedido;
            existingDetalle.Fecha_Pedido = detalle.Fecha_Pedido;
            existingDetalle.Estado = detalle.Estado;
            existingDetalle.Precio = detalle.Precio;

            // Llama al método UpdateDetalle del servicio para actualizar la entidad en la base de datos
            _detalleService.UpdateDetalle(existingDetalle);

            return Ok("Detalle actualizado con éxito");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al actualizar el detalle: {ex.Message}");
        }
    }




    [HttpDelete("{detalleId}", Name = "DeleteDetalle")]
    public IActionResult DeleteDetalle(int detalleId)
    {
        try
        {
            var detalle = _serviceContext.Detalles.FirstOrDefault(d => d.IdPedido == detalleId);
            if (detalle == null)
            {
                return NotFound();
            }

            _serviceContext.Detalles.Remove(detalle);
            _serviceContext.SaveChanges();
            return Ok("Detalle eliminado con éxito");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error al eliminar el detalle: {ex.Message}");
        }
    }


    [HttpGet("{detalleId}", Name = "GetDetalle")]
    public IActionResult GetDetalle(int detalleId)
    {
        var detalle = _serviceContext.Detalles.FirstOrDefault(d => d.IdPedido == detalleId);
        if (detalle == null)
        {
            return NotFound();
        }

        return Ok(detalle);
    }


}

