using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common
{
    public class Sorting
    {
        public string SortBy { get; set; }
        public bool IsDesending { get; set; }

        public Sorting(string sortBy, bool desc)
        {
            if (!string.IsNullOrEmpty(sortBy))
            {
                SortBy = sortBy.ToLower();
            }

            IsDesending = desc;
        }
    }
}
