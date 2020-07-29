using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PBR.PBR_Api.ViewModels
{
    public class PowerBiAccountViewModel
    {
        private readonly Application.Interfaces.IPowerBiApplicationAccountService _powerBiService;

        public PowerBiAccountViewModel()
        {
            AccountList = new List<PowerBiAccountViewModel>();
        }
        public int Id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "UserName is required.")]

        public string UserName { get; set; }
        [DisplayName("Passoword")]
        [Required(ErrorMessage = "Passoword is required.")]

        public string Passoword { get; set; }
        [DisplayName("Client Id")]
        [Required(ErrorMessage = "ClientId is required.")]

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public int ExpiresOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        [DisplayName("Account Name")]
        [Required(ErrorMessage = "AccountName is required.")]
        public string AccountName { get; set; }
        //public bool IsDelete { get; set; }

        public IEnumerable<PowerBiAccountViewModel> AccountList { get; set; }
       
    }
}
