using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constract
{
    public interface IPagingParams
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string SortColumn { get; set; }
        string SortOrder { get; set; }
    }
}
