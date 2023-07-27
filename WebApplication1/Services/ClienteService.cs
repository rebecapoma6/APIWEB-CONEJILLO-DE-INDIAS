using Data;
using Entitites.Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class ClienteService : BaseContextService, IClienteService
    {
        public ClienteService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public void deleteCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public int InsertCliente(ClientesItem clientesItem)
        {
            throw new NotImplementedException();
        }
    }
}
