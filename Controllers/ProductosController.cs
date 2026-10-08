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
            var productos = await _context.Productos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(productos);
        }

    }
}



























