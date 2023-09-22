using Data;
using Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class OrderService : BaseContextService, IOrderServicecs
    {
        public OrderService(ServiceContext serviceContext) : base(serviceContext) { }

        public Order GetOrderById(int orderId)
        {
            return _serviceContext.Orders.Find(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _serviceContext.Orders.ToList();
        }

        public int InsertOrder(Order order)
        {
            _serviceContext.Orders.Add(order);
            _serviceContext.SaveChanges();
            return order.OrderId;
        }

        public void UpdateOrder(Order order)
        {
            _serviceContext.Entry(order).State = EntityState.Modified;
            _serviceContext.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _serviceContext.Orders.Find(orderId);
            if (order != null)
            {
                _serviceContext.Orders.Remove(order);
                _serviceContext.SaveChanges();
            }
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _serviceContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
