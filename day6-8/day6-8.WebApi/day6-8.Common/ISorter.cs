using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_8.Common
{
    public interface ISorter
    {
        string SortOrder { get; set; }
        string SortBy { get; set; }
        bool isNull();
    }
}
