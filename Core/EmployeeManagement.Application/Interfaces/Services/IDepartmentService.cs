using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.QueryParameters;
using EmployeeManagement.Application.ResponseModel;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interfaces.Services
{
    public interface IDepartmentService : IBaseService<Department>
    {
        List<DepartmentDto> GetAllDepartments();
        Task<DepartmentDto> FindDepartmentById(int id);
        Task<bool> AddDepartment(DepartmentDto entity);
        Task<bool> DeleteDepartmentById(int id);
        Task<bool> UpdateDepartment(DepartmentEditDto entity);
        Task<DepartmentResponse> GetDepartments(PaginationQueryParameters parameters);
    }
}
