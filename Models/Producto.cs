using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploPaginacion.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}