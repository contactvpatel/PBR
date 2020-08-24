using PBR.Core.Entities;
using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.ViewModels
{
    public class ApplicationDepartmentViewModel
    {
        public ApplicationDepartmentViewModel()
        {
            ApplicationDepartmentList = new List<ApplicationDepartmentViewModel>();
        }
        [DisplayName("Application Name")]
        public int ApplicationAccountId { get; set; }
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
        [DisplayName("Is Active")]
        
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        [DisplayName("Account Name")]
        public int AccountId { get; set; }
        public int ApplicationAccount { get; set; }
        public int Id { get; set; }
        //public PowerBiApplicationViewModel Application { get; set; }
        //public PowerBiAppliactionAccountViewModel AppliactionAccount { get; set; }
        public DepartmentViewModel Department { get; set; }
        public IEnumerable<ApplicationDepartmentViewModel> ApplicationDepartmentList { get; set; }
    }
}
