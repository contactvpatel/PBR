using PBR.Core.Entities;
using PBR.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace PBR.Core.Specifications
{
public class PowerBiApplicationDepartmentSpecification: BaseSpecification<ApplicationDepartment>
    {
        public PowerBiApplicationDepartmentSpecification()
            : base(null)
        {
            //AddInclude(b => b.ApplicationAccount);
            AddInclude(b => b.Department);

        }
    }
}
