using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
    public interface IApplicationDepartmentRepository:IRepository<ApplicationDepartment>
    {
        Task<IEnumerable<ApplicationDepartment>> GetApplicationAccountListAsync ();
        Task<IEnumerable<ApplicationDepartment>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId);
        public IList ApplicationDepartmentListAsync();

    }
}
