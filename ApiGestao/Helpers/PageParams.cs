using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;

        public int PageNumber { get; set; }

        private int pageSize = 10;

        /// <summary>
        /// Garantindo que o pagesize nunca vai ser maior que o  MaxPageSize
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
