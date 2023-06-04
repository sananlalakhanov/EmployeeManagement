using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.QueryParameters;
using EmployeeManagement.Application.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public List<EmployeeDto> GetAllEmployee()
        {

            return _employeeService.GetAllEmployee();
        }

        [HttpGet("GetEmployees")]
        public async Task<EmployeeResponse> GetEmployees([FromQuery]PaginationQueryParameters parameters)
        {
            return await _employeeService.GetEmployees(parameters);
        }

        [HttpGet("FindEmployeeById")]
        public async Task<EmployeeDto> FindEmployeeById(int id)
        {
            return await _employeeService.FindEmployeeById(id);
        }

        [HttpPost("AddEmployee")]
        public async Task<bool> AddEmployee(EmployeeCreateDto entity)
        {
            return await _employeeService.AddEmployee(entity);
        }

        [HttpDelete("DeleteEmployeeById")]
        public async Task DeleteEmployeeById(int id)
        {
            await _employeeService.DeleteEmployeeById(id);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<bool> UpdateEmployee(EmployeeEditDto entity)
        {
            return await _employeeService.UpdateEmployee(entity);
        }
    }
}
