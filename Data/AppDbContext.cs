using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploPaginacion.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploPaginacion.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Producto> Productos { get; set; }
    }
}