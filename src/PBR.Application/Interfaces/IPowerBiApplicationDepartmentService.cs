using PBR.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
   public interface IPowerBiApplicationDepartmentService
    {
        Task<ApplicationDepartmentModel> CreateApplicationDepartmentAccount(ApplicationDepartmentModel accountModel);
        Task<IEnumerable<ApplicationDepartmentModel>> GetApplicationDepartmentList();
        Task<ApplicationDepartmentModel> GetApplicationDepartmentById(int id);
        Task DeleteApplicationDepartment(int id);
        Task<IEnumerable<DepartmentModel>> GetDepartmentList();
    }
}
