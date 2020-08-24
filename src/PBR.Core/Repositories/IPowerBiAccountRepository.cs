using PBR.Core.Entities;
using PBR.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
   public  interface IAccountRepository:IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountAysc();
        Task<IEnumerable<Account>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret);
        Task<IEnumerable<Account>> CheakAccountNameExists(string AccountName);

    }
}
