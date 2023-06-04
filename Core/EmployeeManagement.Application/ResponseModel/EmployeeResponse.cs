using EmployeeManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.ResponseModel
{
    public class EmployeeResponse
    {
        public List<EmployeeDto> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public int TotalPages { get; set; }
    }
}
