using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.ViewModels
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel() 
        {
            departmentViewModelList =new List<DepartmentViewModel>();
        }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Wing { get; set; }
        public DateTime? Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }
        public IEnumerable<DepartmentViewModel> departmentViewModelList { get; set; }

    }
}
