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
    public interface IEmployeeService: IBaseService<Employee>
    {
        List<EmployeeDto> GetAllEmployee();
        Task<EmployeeDto> FindEmployeeById(int id);
        Task<EmployeeResponse> GetEmployees(PaginationQueryParameters parameters);
        Task<bool> AddEmployee(EmployeeCreateDto entity);
        Task<bool> DeleteEmployeeById(int id);
        Task<bool> UpdateEmployee(EmployeeEditDto entity);
        Task<bool> DeleteByDepartmentId(int id);
    }
}
