using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common
{
    public class Paging
    {
        public int PageSize { get; set; }
        public int? Page { get; set; }
        public int ItemsToSkip { get; set; }
        public Paging(int? page)
        {
            PageSize = 4;
            Page = page;
            ItemsToSkip = PageSize * ((Page ?? 1) - 1);
        }
    }
}
