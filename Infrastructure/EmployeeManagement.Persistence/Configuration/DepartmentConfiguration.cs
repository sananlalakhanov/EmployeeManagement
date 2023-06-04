using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(d=>d.Name).IsRequired().HasColumnName("NAME").HasColumnType("NVARCHAR(200)");
            builder.Property(d=>d.CreateDate).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            builder.Property(d => d.IsDeleted).HasColumnType("BIT").HasDefaultValue(0);

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
