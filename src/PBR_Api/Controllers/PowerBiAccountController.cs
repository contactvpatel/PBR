using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PBR.PBR_Api.Interfaces;
using PBR.PBR_Api.ViewModels;
namespace PBR_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PowerBiAccountController : ControllerBase
    {
        private readonly IPowerBiAccountService _powerBiService;
        private readonly IPowerBiApplicationAccountService _powerBiApplicationAccountService;
        public PowerBiAccountController(IPowerBiAccountService powerBiService, IPowerBiApplicationAccountService powerBiApplicationAccountService)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _powerBiApplicationAccountService = powerBiApplicationAccountService ?? throw new ArgumentNullException(nameof(powerBiApplicationAccountService));
        }
        [Route("Index")]

        [HttpGet]
        public async Task<IActionResult> Index()
        { 
            var PowerBiAccountList = await _powerBiService.GetAllAccount();
            return Ok(PowerBiAccountList);
        }
        [Route("Create")]

        [HttpPost]
        public async Task<IActionResult> Create(PowerBiAccountViewModel accountModel)
        {
            
            accountModel.ClientSecret = "asas";
            accountModel.AccessToken = "asasasSDdsd";
            accountModel.RefreshToken = "asasasSDdsd";
            accountModel.CreatedDate = System.DateTime.Now;
            accountModel.LastUpdatedDate = System.DateTime.Now;
            accountModel.ExpiresIn = 565656565;
            accountModel.ExpiresOn = 565656565;
            var PowerBiAccountList = await _powerBiService.CreatePowerBiAccount(accountModel);
            return Ok(PowerBiAccountList);
        }
    }
}
