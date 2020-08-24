using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Department>> GetProductListAsync()
        {       
          var spec = new DepartmentSpecification();
          return await GetAsync(spec);
           
        }
    }
}
