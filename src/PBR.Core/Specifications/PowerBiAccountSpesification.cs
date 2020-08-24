using PBR.Core.Entities;
using PBR.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Core.Specifications
{
  public  class AccountSpesification:BaseSpecification<Account>
    {
        public AccountSpesification()
           : base(b => b.IsDelete != true)
        {
            
        }
        public AccountSpesification(string UserName, string ClientId, string ClientSecret)
          : base(b => b.UserName == UserName && b.ClientId==ClientId && b.ClientSecret==ClientSecret )
        {

        }
        public AccountSpesification(string AccountName)
          : base(b => b.AccountName==AccountName)
        {

        }
    }
}
