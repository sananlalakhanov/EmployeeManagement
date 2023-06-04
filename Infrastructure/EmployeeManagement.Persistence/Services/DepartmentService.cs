using AutoMapper;
using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.QueryParameters;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.ResponseModel;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence.Repositories;
using EmployeeManagement.Persistence.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper):base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddDepartment(DepartmentDto entity)
        {
            await _departmentRepository.CreateAsync(_mapper.Map<Department>(entity));
            await SaveAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentById(int id)
        {
            var _data = await FindDepartmentById(id);
            
            if (_data != null)
            {
                var data = _mapper.Map<Department>(_data);
                data.IsDeleted = true;
                await UpdateAsync(data);
            }
            return true;
        }

        public async Task<DepartmentDto> FindDepartmentById(int id)
        {
            var dep = await _departmentRepository.GetAll().Where(d=>d.IsDeleted== false && d.Id == id).FirstOrDefaultAsync();
            if (dep == null)
            {
                throw new Exception("Departament cannot find");
            }
            return _mapper.Map<DepartmentDto>(dep);
        }

        public List<DepartmentDto> GetAllDepartments()
        {
            var deps = _departmentRepository.GetAll().Where(d => d.IsDeleted == false).ToList();
            return _mapper.Map<List<DepartmentDto>>(deps);
        }

        public async Task<DepartmentResponse> GetDepartments(PaginationQueryParameters parameters)
        {
            var totalPages = await _departmentRepository.GetAll().Where(x => x.IsDeleted == false).CountAsync();

            var pageCount = Math.Ceiling(totalPages / (float)parameters.Size);

            var departments = await _departmentRepository.GetAll().Where(x => x.IsDeleted == false)
                .Skip((parameters.Page - 1) * parameters.Size)
                .Take(parameters.Size)
                .ToListAsync();

            var response = new DepartmentResponse
            {
                Departments = _mapper.Map<List<DepartmentDto>>(departments),
                CurrentPage = parameters.Page,
                Pages = (int)pageCount,
                TotalPages = totalPages
            };

            return response;
        }

        public async Task<bool> UpdateDepartment(DepartmentEditDto entity)
        {
            var mapData = _mapper.Map<Department>(entity);
            await UpdateAsync(mapData);
            await SaveAsync(); 
            return true;
        }
    }
}
