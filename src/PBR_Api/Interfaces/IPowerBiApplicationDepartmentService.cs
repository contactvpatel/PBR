using PBR.PBR_Api.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IApplicationDepartmentService
    {
        Task<ApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(ApplicationDepartmentViewModel accountModel);
        IList GetAllApplicationDepartmentAccount();
        
        Task<ApplicationDepartmentViewModel> GetApplicationDepartmentById(int id);
        Task ApplicationDepartmentDelete(int id);
        Task<ApplicationDepartmentViewModel> ApplicationDepartmentUpdateAccount(ApplicationDepartmentViewModel ApplicationDepartmentViewModel);
        Task<IEnumerable<ApplicationDepartmentViewModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId);
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartment();

    }
}
