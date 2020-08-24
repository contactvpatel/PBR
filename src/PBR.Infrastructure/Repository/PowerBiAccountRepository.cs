using PBR.Core.Entities;
using PBR.Core.Repositories;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
   public class AccountRepository: Repository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Account>> CheakAccountNameExists(string AccountName)
        {
            var spec = new AccountSpesification(AccountName);
            var account = (await GetAsync(spec));
            return account;
        }

        public async Task<IEnumerable<Account>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret)
        {
            var spec = new AccountSpesification(UserName,ClientId,ClientSecret);
            var account = (await GetAsync(spec));
            return account;
        }

        public async  Task<IEnumerable<Account>> GetAccountAysc()
        {
            var spec = new AccountSpesification();
            var account = (await GetAsync(spec)).ToList();
            return account;
        }
    }
}
