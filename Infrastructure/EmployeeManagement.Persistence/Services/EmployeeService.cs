using AutoMapper;
using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.QueryParameters;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.ResponseModel;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence.Repositories.BaseRepositories;
using EmployeeManagement.Persistence.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddEmployee(EmployeeCreateDto entity)
        {
            var mapData = _mapper.Map<Employee>(entity);
            await CreateAsync(mapData);
            await SaveAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            var employee = await FindByIdAsync(id);
            if (employee != null && !employee.IsDeleted)
            {
                employee.IsDeleted = true;
            }
            await SaveAsync();
            return true;
        }

        public async Task<EmployeeDto> FindEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetAll().Where(e => e.IsDeleted == false && e.Id == id).Include(d => d.Department).FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new Exception("Employee cannot find");
            }
            return _mapper.Map<EmployeeDto>(employee);
        }

        public List<EmployeeDto> GetAllEmployee()
        {
            var employees = _employeeRepository.GetAll().Where(x=>x.IsDeleted ==false).Include(e=>e.Department).ToList();
            if (employees.Count == 0)
            {
                throw new Exception("There is no any Employee");
            }
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeResponse> GetEmployees(PaginationQueryParameters parameters)
        {
            var totalPages = await _employeeRepository.GetAll().Where(x => x.IsDeleted == false).CountAsync();
            var pageCount = Math.Ceiling(totalPages / (float)parameters.Size);

            var employees = await _employeeRepository.GetAll().Where(x => x.IsDeleted == false).Include(e=>e.Department)
                .Skip((parameters.Page-1) * parameters.Size)
                .Take(parameters.Size)
                .ToListAsync();

            var response = new EmployeeResponse
            {
                Employees = _mapper.Map<List<EmployeeDto>>(employees),
                CurrentPage = parameters.Page,
                Pages = (int)pageCount,
                TotalPages = totalPages
            };

            return response;
        }

        public async Task<bool> UpdateEmployee(EmployeeEditDto entity)
        {
            var mapData = _mapper.Map<Employee>(entity);
            await UpdateAsync(mapData);
            await SaveAsync();
            return true;
        }

        public async Task<bool> DeleteByDepartmentId(int id)
        {
            var selectedEmployees = _employeeRepository.GetAll().Where(e=>e.IsDeleted ==false && e.DepartmentId == id).ToList();
            if (selectedEmployees is not null &&  selectedEmployees.Count > 0)
            {
                foreach (var employee in selectedEmployees)
                {
                    employee.IsDeleted = true;
                    await UpdateAsync(_mapper.Map<Employee>(employee));
                }
                
            }
            return true;
        }
    }
}
