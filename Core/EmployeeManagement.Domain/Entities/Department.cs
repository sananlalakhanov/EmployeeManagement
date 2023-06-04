using EmployeeManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
