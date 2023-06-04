﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.Common.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
