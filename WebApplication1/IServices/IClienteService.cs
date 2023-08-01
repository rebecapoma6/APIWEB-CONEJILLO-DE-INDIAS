using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IClienteService
    {
        int InsertCliente(ClientesItem clientesItem);

        void UpdateCliente(ClientesItem clienteModificado);
        void DeleteCliente(int ClienteId);
        int DeleteCliente(ClientesItem clienteBorrado);
    }
}

