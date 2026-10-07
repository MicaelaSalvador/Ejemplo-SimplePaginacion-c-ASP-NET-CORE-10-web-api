using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploPaginacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploPaginacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly List<Producto> productos = new()
        {
            new Producto{Id =1,Nombre="Laptop",Precio = 1500},
            new Producto { Id = 2, Nombre = "Mouse", Precio = 500 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 800 },
            new Producto { Id = 4, Nombre = "Monitor", Precio = 5000 },
            new Producto { Id = 5, Nombre = "Impresora", Precio = 3500 },
            new Producto { Id = 6, Nombre = "Audífonos", Precio = 1200 }
        };

        [HttpGet]
        public IActionResult GetProductos(int page = 1, int pageSize = 3)
        {
            var resultado = productos
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return Ok(resultado);
        }

    }
}



























