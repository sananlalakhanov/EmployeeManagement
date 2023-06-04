using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.Repositories.BaseRepository;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence.Context;
using EmployeeManagement.Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories
{
    public class EmployeeRepository : CRUDRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
    }
}
