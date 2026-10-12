using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploPaginacion.Data;
using EjemploPaginacion.Helpers;
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
        public async Task<IActionResult> GetProductos([FromQuery] PaginationParameters parameters)
        {
            // Si llegaste aqui, Page y PageSize son Validos
            var query = _context.Productos.AsNoTracking().OrderBy(p => p.Id);

            var response = await PaginationHelper.PaginationAsync(
                query,
                parameters
            );

            return Ok(response);
        }

    }
}



























