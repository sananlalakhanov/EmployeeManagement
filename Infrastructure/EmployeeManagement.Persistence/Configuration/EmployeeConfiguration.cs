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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).IsRequired().HasColumnName("NAME").HasColumnType("NVARCHAR(50)");
            builder.Property(e => e.Surname).IsRequired().HasColumnName("SURNAME").HasColumnType("NVARCHAR(50)");
            builder.Property(d => d.CreateDate).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            builder.Property(d => d.IsDeleted).HasColumnType("BIT").HasDefaultValue(0);
            builder.Property(d=>d.BirthDate).HasColumnType("DATETIME");
        }
    }
}
