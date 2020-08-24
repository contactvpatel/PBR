using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
   public interface IApplicationAccountRepository:  IRepository<ApplicationAccount>
    {
        Task <IEnumerable<ApplicationAccount>> GetApplicationAccountListAsync(int id);
        Task<IEnumerable<ApplicationAccount>> GetApplicationAccountListAsync();
        Task<IEnumerable<ApplicationAccount>> CheakGroupIdExists(string GroupId);
        Task<IEnumerable<ApplicationAccount>> GetApplicationNameAccountListAsync(int id);


    }
}
