using PBR.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
   public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAccountList();
        Task<AccountModel> CreateAccount(AccountModel accountModel);
        Task<AccountModel> GetAccountById(int id);
        Task<AccountModel> AccountUpdate(AccountModel accountModel);
        Task DeleteAccount(int id);
        IEnumerable<AccountModel> GetAccount();
        Task<IEnumerable<ApplicationAccountModel>> GetApplicationByAccount(int id);
        Task<IEnumerable<ApplicationAccountModel>> GetApplicationNameByAccount(int id);
        Task<IEnumerable<AccountModel>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret);
        Task<IEnumerable<AccountModel>> checkAccountNameExists(string AccountName);

    }
}
