using EmployeeManagement.Application.Repositories.BaseRepository;
using EmployeeManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence.Repositories.BaseRepositories;
using EmployeeManagement.Persistence.Context;

namespace EmployeeManagement.Persistence.Repositories
{
    public class DepartmentRepository : CRUDRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeManagementDbContext context ): base( context )
        {

        }
    }
}
