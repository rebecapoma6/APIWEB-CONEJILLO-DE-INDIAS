using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers


//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    [Route("[controller]/[action]")]
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderService _orderService;
//        private readonly ServiceContext _serviceContext;

//        public OrderController(IOrderService orderService, ServiceContext serviceContext)
//        {
//            _orderService = orderService;
//            _serviceContext = serviceContext;
//        }

//        [HttpGet(Name = "GetAllOrders")]
//        public IActionResult GetAllOrders()
//        {
//            var orders = _serviceContext.Orders.ToList();
//            return Ok(orders);
//        }

//        [HttpGet("{orderId}", Name = "GetOrderById")]
//        public IActionResult GetOrderById(int orderId)
//        {
//            var order = _serviceContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
//            if (order != null)
//            {
//                return Ok(order);
//            }
//            return NotFound("Orden no encontrada");
//        }

//        [HttpPost(Name = "InsertOrder")]
//        public IActionResult InsertOrder([FromBody] Order order)
//        {
//            _serviceContext.Orders.Add(order);
//            _serviceContext.SaveChanges();
//            return CreatedAtRoute("GetOrderById", new { orderId = order.OrderId }, order);
//        }

//        [HttpPut("{orderId}", Name = "UpdateOrder")]
//        public IActionResult UpdateOrder(int orderId, [FromBody] Order updatedOrder)
//        {
//            var order = _serviceContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
//            if (order != null)
//            {
//                order.OrderDate = updatedOrder.OrderDate;
//                order.Status = updatedOrder.Status;
//                order.ClientId = updatedOrder.ClientId;

//                _serviceContext.SaveChanges();

//                return Ok("La orden se ha modificado correctamente");
//            }
//            else
//            {
//                return NotFound("No se ha encontrado la orden");
//            }
//        }

//        [HttpDelete("{orderId}", Name = "DeleteOrder")]
//        public IActionResult DeleteOrder(int orderId)
//        {
//            var order = _serviceContext.Orders.Find(orderId);
//            if (order != null)
//            {
//                _serviceContext.Orders.Remove(order);
//                _serviceContext.SaveChanges();
//                return Ok("La orden se ha eliminado");
//            }
//            else
//            {
//                return NotFound






//        }
//    }


//    }


{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServicecs _orderService;
        private readonly ServiceContext _serviceContext;

        public OrderController(IOrderServicecs orderService, ServiceContext serviceContext)
        {
            _orderService = orderService;
            _serviceContext = serviceContext;
        }

        [HttpGet(Name = "GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _serviceContext.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{orderId}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int orderId)
        {
            var order = _serviceContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound("Orden no encontrada");
        }

        [HttpPost(Name = "InsertOrder")]
        public IActionResult InsertOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("La orden no puede ser nula");
            }

            // Lógica adicional de validación antes de insertar la orden si es necesario

            _serviceContext.Orders.Add(order);
            _serviceContext.SaveChanges();
            return CreatedAtRoute("GetOrderById", new { orderId = order.OrderId }, order);
        }

        [HttpPut("{orderId}", Name = "UpdateOrder")]
        public IActionResult UpdateOrder(int orderId, [FromBody] Order updatedOrder)
        {
            var order = _serviceContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.OrderDate = updatedOrder.OrderDate;
                order.Status = updatedOrder.Status;
                order.ClientId = updatedOrder.ClientId;

                _serviceContext.SaveChanges();

                return Ok("La orden se ha modificado correctamente");
            }
            else
            {
                return NotFound("No se ha encontrado la orden");
            }
        }

        [HttpDelete("{orderId}", Name = "DeleteOrder")]
        public IActionResult DeleteOrder(int orderId)
        {
            var order = _serviceContext.Orders.Find(orderId);
            if (order != null)
            {
                _serviceContext.Orders.Remove(order);
                _serviceContext.SaveChanges();
                return Ok("La orden se ha eliminado");
            }
            else
            {
                return NotFound("La orden no se encontró o ya ha sido eliminada");
            }
        }
    }





}
   



