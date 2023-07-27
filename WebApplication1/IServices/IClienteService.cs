using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IClienteService
    {
        int InsertCliente(ClientesItem clientesItem);

        void deleteCliente(int clienteId);
    }
}
