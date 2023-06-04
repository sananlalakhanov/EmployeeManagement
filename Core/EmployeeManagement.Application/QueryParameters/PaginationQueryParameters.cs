using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.QueryParameters
{
    public class PaginationQueryParameters
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 5;
    }
}
