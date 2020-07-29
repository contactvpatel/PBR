﻿using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
    public interface IPowerBiApplicationDepartmentRepository:IRepository<ApplicationDepartment>
    {
        Task<IEnumerable<ApplicationDepartment>> GetApplicationAccountListAsync ();

    }
}
