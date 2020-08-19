using PBR.PBR_Api.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IPowerBiApplicationDepartmentService
    {
        Task<PowerBiApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(PowerBiApplicationDepartmentViewModel accountModel);
        IList GetAllApplicationDepartmentAccount();
        
        Task<PowerBiApplicationDepartmentViewModel> GetApplicationDepartmentById(int id);
        Task ApplicationDepartmentDelete(int id);
        Task<PowerBiApplicationDepartmentViewModel> ApplicationDepartmentUpdateAccount(PowerBiApplicationDepartmentViewModel powerBiApplicationDepartmentViewModel);
        Task<IEnumerable<PowerBiApplicationDepartmentViewModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId);
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartment();

    }
}
