using PBR.Core.Entities;
using PBR.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
   public  interface IPowerBiAccountRepository:IRepository<Account>
    {
        Task<IEnumerable<Account>> GetPowerBiAccountAysc();
        Task<IEnumerable<Account>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret);
        Task<IEnumerable<Account>> CheakAccountNameExists(string AccountName);

    }
}
