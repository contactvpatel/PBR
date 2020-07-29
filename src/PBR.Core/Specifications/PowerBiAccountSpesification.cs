using PBR.Core.Entities;
using PBR.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Core.Specifications
{
  public  class PowerBiAccountSpesification:BaseSpecification<Account>
    {
        public PowerBiAccountSpesification()
           : base(b => b.IsDelete != true)
        {
            
        }
        public PowerBiAccountSpesification(string UserName, string ClientId, string ClientSecret)
          : base(b => b.UserName == UserName && b.ClientId==ClientId && b.ClientSecret==ClientSecret )
        {

        }
        public PowerBiAccountSpesification(string AccountName)
          : base(b => b.AccountName==AccountName)
        {

        }
    }
}
