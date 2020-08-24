using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IAccountService
    {
        Task<IEnumerable<AccountViewModel>> GetAllAccount();
        Task<IEnumerable<AccountViewModel>> CreateAccount(AccountViewModel AccountViewModel);
        Task<AccountViewModel> GetAccountById(int id);
        Task<AccountViewModel> UpdateAccount(AccountViewModel AccountViewModel);
        Task AcccountDelete(int id);
        Task<string> GetApplicationByAccountWingHTML(int wing);
        Task<IEnumerable<AccountViewModel>> CheckUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret);
        Task<IEnumerable<AccountViewModel>> CheckAccountNameExists(string AccountName);
    }
}
