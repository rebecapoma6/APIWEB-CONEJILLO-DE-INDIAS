using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Entities
{
    public class ClientesItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Correo { get; set; }

    }
}// Método para crear un nuevo cliente

//    public void CrearCliente(ClientesItem nuevoCliente, object clientes)
//    {
//        if (nuevoCliente != null)
//        {
//            // Asignamos un nuevo ID (simplemente el siguiente número disponible)
//            nuevoCliente.ClienteId = clientes.Count + 1;
//            clientes.Add(nuevoCliente);
//        }
//    }
//}




        

