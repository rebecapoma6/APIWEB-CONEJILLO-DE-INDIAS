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

            public int InsertDetalle(Detalles_Pedido detalle)
            {
                _serviceContext.Detalles.Add(detalle);
                _serviceContext.SaveChanges();
                return detalle.IdPedido;
            }

            public void UpdateDetalle(Detalles_Pedido detalle)
            {
                _serviceContext.Detalles.Update(detalle);
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

        int IDetalleService.insertDetalle(Detalles_Pedido detalles_pedido)
        {
            throw new NotImplementedException();
        }
    }


    }

