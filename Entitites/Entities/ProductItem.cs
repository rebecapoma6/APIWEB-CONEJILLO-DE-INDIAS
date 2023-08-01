using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Entities
{
    public class ProductItem
    {     
        public int IdProducto { get; set; } // Clave primaria para la entidad ProductItem
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public string MarcaProducto { get; set; }

    }
}
