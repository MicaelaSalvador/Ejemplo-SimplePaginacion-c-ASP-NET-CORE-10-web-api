using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploPaginacion.Models
{
    public class PagedResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }
}













