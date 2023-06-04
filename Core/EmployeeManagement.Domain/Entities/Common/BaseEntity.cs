using EmployeeManagement.Domain.Entities.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
