using PBR.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Application.Models
{
   public class ApplicationAccountModel : BaseModel
    {
        public int ApplicationId { get; set; }
        public int AccountId { get; set; }
        public string GroupId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ApplicationModel Application { get; set; }
        public AccountModel Account { get; set; }

    }
}
