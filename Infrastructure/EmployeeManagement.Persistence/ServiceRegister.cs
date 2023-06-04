using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.Repositories;
using EmployeeManagement.Application.Repositories.BaseRepository;
using EmployeeManagement.Persistence.Context;
using EmployeeManagement.Persistence.Repositories;
using EmployeeManagement.Persistence.Repositories.BaseRepositories;
using EmployeeManagement.Persistence.Services;
using EmployeeManagement.Persistence.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence
{
    public static class ServiceRegister
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProjectConnectionString")));
            
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

        }
    }
}
