using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Context
{
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
