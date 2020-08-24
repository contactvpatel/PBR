using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.ViewModels
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel() 
        {
            ApplicationList= new List<ApplicationViewModel>();
        }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public IEnumerable<ApplicationViewModel> ApplicationList { get; set; }

    }
}
