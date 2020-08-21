using PBR.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Core.Entities
{
   public class ApplicationDepartment: Entity
    {
        public ApplicationDepartment()
        {
        }
        public int ApplicationAccountId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public ApplicationAccount ApplicationAccount { get; set; }
        //public APPlication APPlication   { get; set; }
        public  Department  Department { get; set; }

    }
}
