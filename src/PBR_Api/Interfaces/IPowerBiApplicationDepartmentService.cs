using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.Interfaces
{
   public interface IPowerBiApplicationDepartmentService
    {
        Task<PowerBiApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(PowerBiApplicationDepartmentViewModel accountModel);
        Task<IEnumerable<PowerBiApplicationDepartmentViewModel>> GetAllApplicationDepartmentAccount();
        Task<PowerBiApplicationDepartmentViewModel> GetApplicationDepartmentById(int id);
        Task ApplicationDepartmentDelete(int id);
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartment();

    }
}
