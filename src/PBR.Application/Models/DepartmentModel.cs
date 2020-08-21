using PBR.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBR.Application.Models
{
 public class DepartmentModel:BaseModel
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Wing { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
