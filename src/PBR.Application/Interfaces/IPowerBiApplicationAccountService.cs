using PBR.Application.Models;
using PBR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
   public interface IApplicationAccountService
    {
        Task<IEnumerable<ApplicationAccountModel>> GetApplicationAccountList();
        Task<ApplicationAccountModel> CreateApplicationAccount(ApplicationAccountModel accountModel); 
        Task<ApplicationAccountModel> GetApplicationAccountById(int id);
        Task<ApplicationAccountModel> ApplicationAccountUpdate(ApplicationAccountModel accountModel);
        Task DeleteApplicationAccount(int id);
        Task<IEnumerable<ApplicationModel>> GetApplicationList();
        Task<IEnumerable<ApplicationAccountModel>> CheckGroupIdExists(string AccountName);


    }
}
