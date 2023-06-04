using EmployeeManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
