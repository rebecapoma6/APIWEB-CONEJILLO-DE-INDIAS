using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IOrderServicecs
    {
        Order GetOrderById(int orderId);
        List<Order> GetAllOrders();
        int InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        List<OrderDetail> GetOrderDetails(int orderId);

    }
}