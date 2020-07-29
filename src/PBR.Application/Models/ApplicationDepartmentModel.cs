using PBR.Application.Models.Base;
using PBR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Application.Models
{
   public class ApplicationDepartmentModel : BaseModel
    {

        public int ApplicationAccountId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        //public ApplicationModel Application { get; set; }
        public DepartmentModel Department { get; set; }
        //public ApplicationAccountModel ApplicationAccount { get; set; }

    }
}
