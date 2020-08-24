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
    public class ApplicationAccountController : ControllerBase
    {
        private readonly IAccountService _accountService ;
        private readonly IApplicationAccountService _ApplicationAccountService;

        public ApplicationAccountController(IAccountService accountService, IApplicationAccountService ApplicationAccountService, IApplicationAccountService ApplicationAccountServic)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _ApplicationAccountService = ApplicationAccountService ?? throw new ArgumentNullException(nameof(ApplicationAccountService));
        }
        
        //Display All ApplicationAccount Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationAccount = await _ApplicationAccountService.GetAllApplicationAccount();
            return Ok(applicationAccount);
        }
        
        //Create ApplicationAccount Screen Api
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AppliactionAccountViewModel AppliactionAccountViewModel)
        {
            AppliactionAccountViewModel.CreatedDate = System.DateTime.Now;
            AppliactionAccountViewModel.LastUpdatedDate = System.DateTime.Now;
            AppliactionAccountViewModel.GroupId = AppliactionAccountViewModel.GroupId.Replace(" ","");

            var GroupIdListByGroupId = await _ApplicationAccountService.CheckGroupIdExists(AppliactionAccountViewModel.GroupId);
          
            if (GroupIdListByGroupId.Count() >= 1)
            {                
                ModelState.AddModelError("GroupId", "This GroupId already exists, Please Enter different GroupId.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "This GroupId already exists, Please Enter different GroupId."
                };

                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;
                var result = new BadRequestObjectResult(problemDetails);
                return result;
            }
            else
            {
                await _ApplicationAccountService.CreateAccount(AppliactionAccountViewModel);

                return RedirectToAction("Index");
            }
        }
       
        //Display All ApplicationAccount Api
        [Route("{GeApplicationAccountById}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GeApplicationAccounttById(int Id)
        {
         var AccountListById = await _ApplicationAccountService.GetApplicationAccountById(Id);
         return Ok(AccountListById);
        }
        
        //Update  ApplicationAccount Api
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(AppliactionAccountViewModel AppliactionAccountViewModel)
        {
            var ApplicationAccountList = await _ApplicationAccountService.GetApplicationAccountById(AppliactionAccountViewModel.Id);
            AppliactionAccountViewModel.CreatedDate =ApplicationAccountList.CreatedDate;
            AppliactionAccountViewModel.LastUpdatedDate = System.DateTime.Now;
            AppliactionAccountViewModel.GroupId = AppliactionAccountViewModel.GroupId.Replace(" ", "");
            var GroupIdListByGroupId = await _ApplicationAccountService.CheckGroupIdExists(AppliactionAccountViewModel.GroupId);
            if (ApplicationAccountList.GroupId!=AppliactionAccountViewModel.GroupId && GroupIdListByGroupId.Count() >= 1) 
            {
               
                    ModelState.AddModelError("GroupId", "This GroupId already exists, Please Enter different GroupId.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "This GroupId already exists, Please Enter different GroupId."
                    };
                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;
                    var result = new BadRequestObjectResult(problemDetails);
                    return result;
               
            }
            else 
            {
                var GetApplicationAccount = await _ApplicationAccountService.UpdateApplicationAccount(AppliactionAccountViewModel);
                return Ok(GetApplicationAccount);
            }

           
                  
        }
        
        // Delate ApplicationAccount Record(IsActive==False)Update
        [Route("{Delete}/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _ApplicationAccountService.ApplicationAcccountDelete(Id);
            return Ok();
        }
        
        // DropdownList ApplicationId And ApplicationName        
        [Route("GetApplicationList")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationList()
        {
            var ApplicationList = await _ApplicationAccountService.GetAllApplication();
            var ApplicationNameAndValueList  = ApplicationList.Select(x => new { ApplicationId = x.ApplicationId, ApplicationName = x.ApplicationName });
            return Ok(ApplicationNameAndValueList);
        }
        
        // GetAccountList 
        [Route("GetAccountList")]
        [HttpGet]
        public async Task<IActionResult> GetAccountList()
        {
            var AccountList = await _accountService.GetAllAccount();
            var AccountNameAndValueList = AccountList.Select(x => new { Id = x.Id, AccountName = x.AccountName });
            return Ok(AccountNameAndValueList);
        }
        
    }
}
