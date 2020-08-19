using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PowerBiApplicationAccountController : ControllerBase
    {
        private readonly IPowerBiAccountService _powerBiService;
        private readonly IPowerBiApplicationAccountService _powerBiApplicationAccountService;

        public PowerBiApplicationAccountController(IPowerBiAccountService powerBiService, IPowerBiApplicationAccountService powerBiApplicationAccountService, IPowerBiApplicationAccountService powerBiApplicationAccountServic)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _powerBiApplicationAccountService = powerBiApplicationAccountService ?? throw new ArgumentNullException(nameof(powerBiApplicationAccountService));
        }
        
        //Display All ApplicationAccount Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationAccount = await _powerBiApplicationAccountService.GetAllApplicationAccount();
            return Ok(applicationAccount);
        }
        
        //Create ApplicationAccount Screen Api
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(PowerBiAppliactionAccountViewModel powerBiAppliactionAccountViewModel)
        {
            powerBiAppliactionAccountViewModel.CreatedDate = System.DateTime.Now;
            powerBiAppliactionAccountViewModel.LastUpdatedDate = System.DateTime.Now;

            var GroupIdListByGroupId = await _powerBiApplicationAccountService.CheckGroupIdExists(powerBiAppliactionAccountViewModel.GroupId);
            if (GroupIdListByGroupId.Count() >= 1)
            {                
                ModelState.AddModelError("GroupId", "This GroupId already exists, Please Enter different GroupId.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;
                var result = new BadRequestObjectResult(problemDetails);
                return result;
            }
            else
            {
                await _powerBiApplicationAccountService.CreateAccount(powerBiAppliactionAccountViewModel);

                return RedirectToAction("Index");
            }
        }
       
        //Display All ApplicationAccount Api
        [Route("{GeApplicationAccountById}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GeApplicationAccounttById(int Id)
        {
         var AccountListById = await _powerBiApplicationAccountService.GetApplicationAccountById(Id);
         return Ok(AccountListById);
        }
        
        //Update  ApplicationAccount Api
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(PowerBiAppliactionAccountViewModel powerBiAppliactionAccountViewModel)
        {
            var PowerBiApplicationAccountList = await _powerBiApplicationAccountService.GetApplicationAccountById(powerBiAppliactionAccountViewModel.Id);
            powerBiAppliactionAccountViewModel.CreatedDate =PowerBiApplicationAccountList.CreatedDate;
            powerBiAppliactionAccountViewModel.LastUpdatedDate = System.DateTime.Now;
            var GroupIdListByGroupId = await _powerBiApplicationAccountService.CheckGroupIdExists(powerBiAppliactionAccountViewModel.GroupId);
            if (PowerBiApplicationAccountList.GroupId!=powerBiAppliactionAccountViewModel.GroupId && GroupIdListByGroupId.Count() >= 1) 
            {
               
                    ModelState.AddModelError("GroupId", "This GroupId already exists, Please Enter different GroupId.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;
                    var result = new BadRequestObjectResult(problemDetails);
                    return result;
               
            }
            else 
            {
                var GetApplicationAccount = await _powerBiApplicationAccountService.UpdateApplicationAccount(powerBiAppliactionAccountViewModel);
                return Ok(GetApplicationAccount);
            }

           
                  
        }
        
        // Delate ApplicationAccount Record(IsActive==False)Update
        [Route("{Delete}/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _powerBiApplicationAccountService.ApplicationAcccountDelete(Id);
            return Ok();
        }
        
        // DropdownList ApplicationId And ApplicationName        
        [Route("GetApplicationList")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationList()
        {
            var ApplicationList = await _powerBiApplicationAccountService.GetAllApplication();
            var ApplicationNameAndValueList  = ApplicationList.Select(x => new { ApplicationId = x.ApplicationId, ApplicationName = x.ApplicationName });
            return Ok(ApplicationNameAndValueList);
        }
        
        // GetAccountList 
        [Route("GetAccountList")]
        [HttpGet]
        public async Task<IActionResult> GetAccountList()
        {
            var AccountList = await _powerBiService.GetAllAccount();
            var AccountNameAndValueList = AccountList.Select(x => new { Id = x.Id, AccountName = x.AccountName });
            return Ok(AccountNameAndValueList);
        }
        
    }
}
