using PBR.Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
   public interface IPowerBiApplicationDepartmentService
    {
        Task<ApplicationDepartmentModel> CreateApplicationDepartmentAccount(ApplicationDepartmentModel accountModel);
        //Task<IEnumerable<ApplicationDepartmentModel>> GetApplicationDepartmentList();
        IList GetApplicationDepartmentList();
        Task<ApplicationDepartmentModel> GetApplicationDepartmentById(int id);
        Task DeleteApplicationDepartment(int id);
        Task<ApplicationDepartmentModel> ApplicationDepartmentUpdate(ApplicationDepartmentModel accountModel);
        Task<IEnumerable<ApplicationDepartmentModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId);

        Task<IEnumerable<DepartmentModel>> GetDepartmentList();
    }
}
