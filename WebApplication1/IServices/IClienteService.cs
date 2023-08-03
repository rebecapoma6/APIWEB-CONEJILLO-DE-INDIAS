using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IClienteService

    {
        //int InsertCliente(ClientesItem cliente);
        //void UpdateCliente(ClientesItem cliente);
        //void DeleteCliente(int clienteId);

        int InsertCliente(ClientesItem cliente);
        void UpdateCliente(ClientesItem cliente);
        void DeleteCliente(int clienteId);
        IEnumerable<ClientesItem> GetAllClientes();

    }
}

