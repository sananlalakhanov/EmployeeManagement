using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Dtos
{
    public class EmployeeEditDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
