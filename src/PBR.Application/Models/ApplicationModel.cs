using PBR.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Application.Models
{
   public class ApplicationModel: BaseModel
    {
        public ApplicationModel() 
        {
        }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

    }
}
