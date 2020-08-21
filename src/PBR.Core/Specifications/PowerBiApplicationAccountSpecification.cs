using PBR.Core.Entities;
using PBR.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Core.Specifications
{
    public class PowerBiApplicationAccountSpecification : BaseSpecification<ApplicationAccount>
    {

        public PowerBiApplicationAccountSpecification(int id)
            : base(b => b.AccountId == id && b.IsActive == true)
        {
            AddInclude(b => b.APPlication);
            AddInclude(b => b.Account);
        }
        public PowerBiApplicationAccountSpecification(string GroupId)
          : base(b => b.GroupId== GroupId)
        {

        }
        public PowerBiApplicationAccountSpecification()
            : base(null)
        {
            AddInclude(b => b.APPlication);
            AddInclude(b => b.Account);
        }
        
    }
}
