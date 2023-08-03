
using Data;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class ClienteService : BaseContextService, IClienteService
    {
        public ClienteService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int InsertCliente(ClientesItem cliente)
        {
            _serviceContext.Clientes.Add(cliente);
            _serviceContext.SaveChanges();
            return cliente.ClienteId;
        }

        public void UpdateCliente(ClientesItem cliente)
        {
            _serviceContext.Clientes.Update(cliente);
            _serviceContext.SaveChanges();
        }

        public void DeleteCliente(int clienteId)
        {
            var cliente = _serviceContext.Clientes.Find(clienteId);
            if (cliente != null)
            {
                _serviceContext.Clientes.Remove(cliente);
                _serviceContext.SaveChanges();
            }
        }

        public IEnumerable<ClientesItem> GetAllClientes()
        {
            return _serviceContext.Clientes.ToList();
        }
    }
}







      


