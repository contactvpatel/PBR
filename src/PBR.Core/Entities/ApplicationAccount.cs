using PBR.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Core.Entities
{
    public class ApplicationAccount : Entity
    {   public ApplicationAccount()
        {

        }
        public int ApplicationId { get; set; }
        public int AccountId { get; set; }
        public string GroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public APPlication APPlication  { get; set; }
        public Account  Account { get; set; }
    }
}
