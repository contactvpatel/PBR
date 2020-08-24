using PBR.Core.Entities;
using PBR.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace PBR.Core.Specifications
{
public class ApplicationDepartmentSpecification: BaseSpecification<ApplicationDepartment>
    {
        public ApplicationDepartmentSpecification()
            : base(null)
        {
            AddInclude(b => b.ApplicationAccount);
            AddInclude(b => b.Department);
            

        }
         public ApplicationDepartmentSpecification(int ApplicationId,int DepartmentId)
          : base(b => b.ApplicationAccountId == ApplicationId && b.DepartmentId == DepartmentId)
        {
        }
    }
}
