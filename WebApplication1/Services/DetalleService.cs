using Data;
using Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;


namespace WebApplication1.Services
//{

//    public class DetalleService : BaseContextService, IDetalleService
//        {
//            public DetalleService(ServiceContext serviceContext) : base(serviceContext)
//            {
//            }

//            public int insertDetalle(Detalles_Pedido detalles_pedido)
//            {
//                _serviceContext.Detalles.Add(detalles_pedido);
//                _serviceContext.SaveChanges();
//                return detalles_pedido.IdPedido;
//            }

//            public void UpdateDetalle(Detalles_Pedido detalles)
//            {
//                _serviceContext.Detalles.Update(detalles);
//                _serviceContext.SaveChanges();
//            }

//            public void DeleteDetalle(int detalleId)
//            {
//                var detalle = _serviceContext.Detalles.Find(detalleId);
//                if (detalle != null)
//                {
//                    _serviceContext.Detalles.Remove(detalle);
//                    _serviceContext.SaveChanges();
//                }
//            }

//    }


//  }

{
    public class DetalleService : BaseContextService, IDetalleService
    {
        public DetalleService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertDetalle(Detalles_Pedido detalles_pedido)
        {
            try
            {
                _serviceContext.Detalles.Add(detalles_pedido);
                _serviceContext.SaveChanges();
                return detalles_pedido.IdPedido;
            }
            catch (DbUpdateException ex)
            {
                // Aquí puedes capturar más detalles sobre la excepción y proporcionar un mensaje más claro
                var innerExceptionMessage = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error al insertar el detalle: {innerExceptionMessage}");
            }
        }

        public void UpdateDetalle(Detalles_Pedido detalles)
        {
            try
            {
                _serviceContext.Detalles.Update(detalles);
                _serviceContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error al actualizar el detalle: {innerExceptionMessage}");
            }
        }

        public void DeleteDetalle(int detalleId)
        {
            try
            {
                var detalle = _serviceContext.Detalles.Find(detalleId);
                if (detalle != null)
                {
                    _serviceContext.Detalles.Remove(detalle);
                    _serviceContext.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error al eliminar el detalle: {innerExceptionMessage}");
            }
        }
    }
}

