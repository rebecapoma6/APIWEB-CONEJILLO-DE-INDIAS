using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IDetalleService
    {
        int insertDetalle(Detalles_Pedido detalles_pedido);
        void UpdateDetalle(Detalles_Pedido detalles);
        void DeleteDetalle(int detalleId);

    }
}
