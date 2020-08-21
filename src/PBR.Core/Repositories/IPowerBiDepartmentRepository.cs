using PBR.Core.Entities;
using PBR.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
   public interface IPowerBiDepartmentRepository:IRepository<Department>
    {
        Task<IEnumerable<Department>> GetProductListAsync();

    }
}
