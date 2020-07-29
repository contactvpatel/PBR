using PBR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories.Base
{
   public interface IPowerBiApplicationRepository: IRepository<APPlication>
    {

        Task<IEnumerable<APPlication>> GetProductListAsync();
    }
}
