using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IApplicationAccountService
    {
        Task<IEnumerable<AppliactionAccountViewModel>> CreateAccount(AppliactionAccountViewModel AccountApplicationViewModel);
        Task<IEnumerable<AppliactionAccountViewModel>> GetAllApplicationAccount();
        Task<AppliactionAccountViewModel> GetApplicationAccountById(int id);
        Task<AppliactionAccountViewModel> UpdateApplicationAccount(AppliactionAccountViewModel AccountViewModel);
        Task ApplicationAcccountDelete(int id);
        Task<IEnumerable<ApplicationViewModel>> GetAllApplication();
        Task<IEnumerable<AppliactionAccountViewModel>> CheckGroupIdExists(string GroupId);


    }
}
