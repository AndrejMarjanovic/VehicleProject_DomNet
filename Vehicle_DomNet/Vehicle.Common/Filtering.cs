using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common
{
    public class Filtering
    {
        public string FilterString { get; set; }
        public Filtering(string filterString)
        {
            FilterString = filterString;
        }
        public bool Filter()
        {
            if (!string.IsNullOrEmpty(FilterString))
            {
                FilterString = FilterString.ToLower();
                return true;
            }
            return false;
        }
    }
}
