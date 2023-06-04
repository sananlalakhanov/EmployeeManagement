using AutoMapper;
using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Mapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentEditDto>();
            CreateMap<DepartmentEditDto, Department>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeEditDto>();
            CreateMap<EmployeeEditDto, Employee>();
            CreateMap<Employee, EmployeeCreateDto>();
            CreateMap<EmployeeCreateDto, Employee>();
        }
    }
}
