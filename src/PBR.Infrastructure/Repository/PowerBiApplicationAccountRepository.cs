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
    public class ApplicationAccountRepository : Repository<ApplicationAccount>,IApplicationAccountRepository
    {
        public ApplicationAccountRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ApplicationAccount>> CheakGroupIdExists(string GroupId)
        {
            var spec = new ApplicationAccountSpecification(GroupId);
            var account = (await GetAsync(spec)).ToList();
            return account;
           
        }

        public async Task<IEnumerable<ApplicationAccount>> GetApplicationAccountListAsync(int id)
        {
            var spec = new ApplicationAccountSpecification(id);
            var account = (await GetAsync(spec)).ToList();
            return account;
        }

        public async Task<IEnumerable<ApplicationAccount>> GetApplicationAccountListAsync()
        {
            var spec = new ApplicationAccountSpecification();
            var account = (await GetAsync(spec)).ToList();
            return account;
        }

        public Task<IEnumerable<ApplicationAccount>> GetApplicationNameAccountListAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
