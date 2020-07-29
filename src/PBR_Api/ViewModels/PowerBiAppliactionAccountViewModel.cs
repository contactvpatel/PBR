using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.PBR_Api.ViewModels
{
    public class PowerBiAppliactionAccountViewModel
    {
        public PowerBiAppliactionAccountViewModel()
        {

            ApplicationAccountList = new List<PowerBiAppliactionAccountViewModel>();
        }
        [DisplayName("Application Name")]

        public int ApplicationId { get; set; }
        [DisplayName("Account Name")]
        public int AccountId { get; set; }
        [DisplayName("Group Id")]

        public string GroupId { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public List<SelectListItem> IsActiveOptionList { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Id { get; set; }
        public PowerBiApplicationViewModel Application { get; set; }
        public PowerBiAccountViewModel Account { get; set; }

        public IEnumerable<PowerBiAppliactionAccountViewModel> ApplicationAccountList { get; set; }
    }
}
