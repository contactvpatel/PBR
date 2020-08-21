using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IPowerBiAccountService
    {
        Task<IEnumerable<PowerBiAccountViewModel>> GetAllAccount();
        Task<IEnumerable<PowerBiAccountViewModel>> CreatePowerBiAccount(PowerBiAccountViewModel powerBiAccountViewModel);
        Task<PowerBiAccountViewModel> GetAccountById(int id);
        Task<PowerBiAccountViewModel> UpdateAccount(PowerBiAccountViewModel PowerBiAccountViewModel);
        Task AcccountDelete(int id);
        Task<string> GetApplicationByAccountWingHTML(int wing);
        Task<IEnumerable<PowerBiAccountViewModel>> CheckUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret);
        Task<IEnumerable<PowerBiAccountViewModel>> CheckAccountNameExists(string AccountName);
    }
}
