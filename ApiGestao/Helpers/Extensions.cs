using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse responde, 
            int CurrentPage, int ItemsPerPage, int TotalItems, int TotalPages)
        {
            var paginationHeader = new PaginationHeader(CurrentPage, ItemsPerPage, TotalItems, TotalPages);

            responde.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            responde.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}
