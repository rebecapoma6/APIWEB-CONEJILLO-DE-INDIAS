
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

        public void DeleteCliente(int ClienteId)
        {
            throw new NotImplementedException();
        }

        public int DeleteCliente(ClientesItem clienteBorrado)
        {
            throw new NotImplementedException();
        }

        public int InsertCliente(ClientesItem cliente)
        {
            // Agregar el cliente al contexto de base de datos
            _serviceContext.Clientes.Add(cliente);

            // Guardar los cambios en la base de datos
            _serviceContext.SaveChanges();

            // Devolver el ClienteId asignado al cliente
            return cliente.ClienteId;
        }

        void IClienteService.UpdateCliente(ClientesItem clienteModificado)
        {
            throw new NotImplementedException();
        }
    }
}

      


