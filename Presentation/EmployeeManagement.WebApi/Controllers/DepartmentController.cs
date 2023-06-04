using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.QueryParameters;
using EmployeeManagement.Application.ResponseModel;
using EmployeeManagement.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [HttpGet("GetAllDepartments")]
        public List<DepartmentDto> GetAllDepartments()
        {
            return _departmentService.GetAllDepartments();
        }

        [HttpGet("GetDepartments")]
        public async Task<DepartmentResponse> GetDepartments([FromQuery] PaginationQueryParameters parameters)
        {
            return await _departmentService.GetDepartments(parameters);
        }

        [HttpGet("FindDepartmentById")]
        public async Task<DepartmentDto> FindDepartmentById(int id)
        {
            return await _departmentService.FindDepartmentById(id);
        }

        [HttpPost("AddDepartment")]
        public async Task<bool> AddDepartment(DepartmentDto entity)
        {
            return await _departmentService.AddDepartment(entity);
        }

        [HttpDelete("DeleteDepartmentById")]
        public async Task DeleteDepartmentById(int id)
        {
            await _employeeService.DeleteByDepartmentId(id);
            await _departmentService.DeleteDepartmentById(id);
        }
        [HttpPut("UpdateDepartment")]
        public async Task<bool> UpdateDepartment(DepartmentEditDto entity)
        {
            return await _departmentService.UpdateDepartment(entity);
        }
    }
}
