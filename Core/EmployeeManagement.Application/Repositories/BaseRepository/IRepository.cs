using EmployeeManagement.Domain.Entities.Common.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Repositories.BaseRepository
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        DbSet<T> Table { get; }
    }
}
