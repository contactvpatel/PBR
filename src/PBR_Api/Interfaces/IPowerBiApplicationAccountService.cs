using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IPowerBiApplicationAccountService
    {
        Task<IEnumerable<PowerBiAppliactionAccountViewModel>> CreateAccount(PowerBiAppliactionAccountViewModel powerBiAccountApplicationViewModel);
        Task<IEnumerable<PowerBiAppliactionAccountViewModel>> GetAllApplicationAccount();
        Task<PowerBiAppliactionAccountViewModel> GetApplicationAccountById(int id);
        Task<PowerBiAppliactionAccountViewModel> UpdateApplicationAccount(PowerBiAppliactionAccountViewModel powerBiAccountViewModel);
        Task ApplicationAcccountDelete(int id);
        Task<IEnumerable<PowerBiApplicationViewModel>> GetAllApplication();
        Task<IEnumerable<PowerBiAppliactionAccountViewModel>> CheckGroupIdExists(string GroupId);


    }
}
