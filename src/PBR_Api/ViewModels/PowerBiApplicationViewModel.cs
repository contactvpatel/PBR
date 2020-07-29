using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.ViewModels
{
    public class PowerBiApplicationViewModel
    {
        public PowerBiApplicationViewModel() 
        {
            ApplicationList= new List<PowerBiApplicationViewModel>();
        }
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public IEnumerable<PowerBiApplicationViewModel> ApplicationList { get; set; }

    }
}
