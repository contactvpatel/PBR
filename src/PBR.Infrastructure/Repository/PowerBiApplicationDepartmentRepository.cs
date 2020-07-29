using Microsoft.EntityFrameworkCore;
using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
public class PowerBiApplicationDepartmentRepository: Repository<ApplicationDepartment>, IPowerBiApplicationDepartmentRepository
    {
        public PowerBiApplicationDepartmentRepository(DataContext dbContext) : base(dbContext)
        {




        }

        public async Task<IEnumerable<ApplicationDepartment>> GetApplicationAccountListAsync()
        {
           
           
            var spec = new PowerBiApplicationDepartmentSpecification();
            var account = (await GetAsync(spec)).ToList();
            return account;

        }


    }
}
