using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploPaginacion.Data;
using EjemploPaginacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploPaginacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductosController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos(int page = 1, int pageSize = 3)
        {
            // Validar página 
            if (page < 1)
            {
                return BadRequest("La página debe ser mayor o igual a 1. ");
            }

            // Validar tamaño de la página
            if (pageSize < 1 || pageSize > 100)
            {
                return BadRequest("El tamaño de la página debe de estar entre 1 y 100 .");
            }

            //Total de Pproductos
            var totalItems = await _context.Productos.CountAsync();

            // Calcular total de páginas
            var totalPages = (int)Math.Ceiling(
                totalItems / (double)pageSize
            );

            // Obtener productos de la página solicitada
            var productos = await _context.Productos
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();


            // Crear respuesta
            var response = new PagedResponse<Producto>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = productos
            };
            return Ok(response);
        }

    }
}



























