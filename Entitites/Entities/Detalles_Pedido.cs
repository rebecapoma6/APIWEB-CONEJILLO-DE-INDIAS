using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Entities
{
    public class Detalles_Pedido
    {
            public int IdPedido { get; set; }
            public string Pedido { get; set; }
           
            public int IdCliente { get; set;}
            public int Fecha_Pedido { get; set;}            
            public string Estado {get; set;}
    }
}
