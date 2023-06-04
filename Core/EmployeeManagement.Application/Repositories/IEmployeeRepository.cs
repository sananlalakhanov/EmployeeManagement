using EmployeeManagement.Application.Repositories.BaseRepository;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Repositories
{
    public interface IEmployeeRepository: ICRUDRepository<Employee>
    {
    }
}
