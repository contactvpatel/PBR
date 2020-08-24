using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories;
using PBR.Core.Repositories.Base;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
   public class ApplicationRepository: Repository<APPlication>, IApplicationRepository
    {
        public ApplicationRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<APPlication>> GetProductListAsync()
        {
            var spec = new ApplicationSpesification();
            return await GetAsync(spec);
        }
    }
}
