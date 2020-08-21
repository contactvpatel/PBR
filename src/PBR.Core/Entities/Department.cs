using PBR.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBR.Core.Entities
{
   public class Department: Entity
    {
        public Department()
        {
        }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Wing { get; set; }
        public DateTime ? Created { get; set;}
        public int ? CreatedBy { get; set; }
        public DateTime ? LastUpdated { get; set;}
        public int ? LastUpdatedBy { get; set;}
        public int id { get; set; }
    }
    
}
