using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EjemploPaginacion.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploPaginacion.Helpers
{
    public class PaginationHelper
    {
        public static async Task<PagedResponse<T>> PaginationAsync<T>(IQueryable<T> query, PaginationParameters parameters)
        {
            int pageSize = parameters.PageSize ?? PaginationParameters.DefaultPageSize; //  o  usa una constante 
            int page = parameters.Page;

            // Total de Items
            var totalItems = await query.CountAsync();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return new PagedResponse<T>
            {
                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };
        }
    }
}