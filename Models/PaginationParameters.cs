using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploPaginacion.Models
{
    public class PaginationParameters
    {
        public const int MaxPageSize = 100;
        public const int DefaultPageSize = 10;  // Publica, visible desde el helper
        public int? _pageSize = DefaultPageSize;

        [Range(1, int.MaxValue, ErrorMessage = "La página debe ser mayor o igual  a 1 . ")]
        public int Page { get; set; } = 1;

        [Range(1, MaxPageSize, ErrorMessage = "El tamaño de la página debe estar entre 1 y 100 .")]
        public int? PageSize
        {
            get => _pageSize;
            set => _pageSize = value;
        }
    }
}















