using Data;
using Entitites.Entities;
using WebApplication1.IServices;


namespace WebApplication1.Services
{

    public class DetalleService : BaseContextService, IDetalleService
        {
            public DetalleService(ServiceContext serviceContext) : base(serviceContext)
            {
            }

            public int insertDetalle(Detalles_Pedido detalles_pedido)
            {
                _serviceContext.Detalles.Add(detalles_pedido);
                _serviceContext.SaveChanges();
                return detalles_pedido.IdPedido;
            }

            public void UpdateDetalle(Detalles_Pedido detalles)
            {
                _serviceContext.Detalles.Update(detalles);
                _serviceContext.SaveChanges();
            }

            public void DeleteDetalle(int detalleId)
            {
                var detalle = _serviceContext.Detalles.Find(detalleId);
                if (detalle != null)
                {
                    _serviceContext.Detalles.Remove(detalle);
                    _serviceContext.SaveChanges();
                }
            }

    }


  }

