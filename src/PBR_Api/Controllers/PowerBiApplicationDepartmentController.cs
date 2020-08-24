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
    public class ApplicationDepartmentController : ControllerBase
    {
        private readonly IAccountService _Service;
        private readonly IApplicationAccountService _ApplicationAccountService;

        private readonly IApplicationDepartmentService _ApplicationDepartmentService;
        public ApplicationDepartmentController(IAccountService Service, IApplicationDepartmentService iApplicationDepartmentService, IApplicationAccountService ApplicationAccountService)
        {
            _ApplicationAccountService = ApplicationAccountService ?? throw new ArgumentNullException(nameof(ApplicationAccountService));

            _Service = Service ?? throw new ArgumentNullException(nameof(Service));
            _ApplicationDepartmentService = iApplicationDepartmentService ?? throw new ArgumentNullException(nameof(iApplicationDepartmentService));
        }
       
        //Display All AplicationDepartment Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ApplicationDepartment = _ApplicationDepartmentService.GetAllApplicationDepartmentAccount();
           
            return Ok(ApplicationDepartment);
        }
       
        //Create ApplicationDepartment Screen Api
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationDepartmentViewModel ApplicationDepartmentViewModel)
        {
            var ApplicatioIdAndDepartmentIdExists = await _ApplicationDepartmentService.CheckApplicatioIdAndDepartmentIdExists(ApplicationDepartmentViewModel.ApplicationAccountId,ApplicationDepartmentViewModel.DepartmentId);
            if (ApplicatioIdAndDepartmentIdExists.Count()>=1)
            {
                ModelState.AddModelError("", "This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id."
                };
                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;
                var result = new BadRequestObjectResult(problemDetails);
                return result;
            }
            else
            {
                ApplicationDepartmentViewModel.CreatedDate = System.DateTime.Now;
                ApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
                ApplicationDepartmentViewModel.IsActive = true;
                await _ApplicationDepartmentService.CreateApplicationDepartmentAccount(ApplicationDepartmentViewModel);
                return Ok();
            }
            
            
        }

        //Get Particular ApplicationDepartmentAccount
        [Route("{GeApplicationAccounttById}/{id}")]
        [HttpGet]
        public async Task<ActionResult> GeApplicationAccounttById(int Id)
        {
            var AccountListById = await _ApplicationDepartmentService.GetApplicationDepartmentById(Id);
            return Ok(AccountListById);
        }
        //Update ApplicationDepartment Api
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(ApplicationDepartmentViewModel ApplicationDepartmentViewModel )

        {

            var GetCurrentFiled = await _ApplicationDepartmentService.GetApplicationDepartmentById(ApplicationDepartmentViewModel.Id);
            ApplicationDepartmentViewModel.CreatedDate = GetCurrentFiled.CreatedDate;
            ApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
            var ApplicatioIdAndDepartmentIdExists = await _ApplicationDepartmentService.CheckApplicatioIdAndDepartmentIdExists(ApplicationDepartmentViewModel.ApplicationAccountId, ApplicationDepartmentViewModel.DepartmentId);

            if (ApplicatioIdAndDepartmentIdExists.Count() >= 1 &&(GetCurrentFiled.ApplicationAccountId!=ApplicationDepartmentViewModel.ApplicationAccountId || GetCurrentFiled.DepartmentId!= ApplicationDepartmentViewModel.DepartmentId))
            {
                ModelState.AddModelError("", "This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title="This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id."
                };

                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;
                var result = new BadRequestObjectResult(problemDetails);
                
                return result;
            }
            else
            {
                ApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
               var GetUpdateApplicationDepartment= await _ApplicationDepartmentService.ApplicationDepartmentUpdateAccount(ApplicationDepartmentViewModel);
                return Ok(GetUpdateApplicationDepartment);
            }
        }

        // Delate ApplicationDepartmentAccount Record(IsActive==False)Update
        [Route("{Delete}/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _ApplicationDepartmentService.ApplicationDepartmentDelete(Id);
            return Ok();
        }
        // DropdownList AccountName And Application And Id        
        [Route("GetApplicationNameAndAccountName")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationNameAndAccountName()
        {
            var applicationNameAndAccountName = await _ApplicationAccountService.GetAllApplicationAccount();
            var ApplicationAccountName = applicationNameAndAccountName.Select(x => new { AccountName = x.Account.AccountName, ApplicationName = x.Application.ApplicationName, id = x.Id });
            return Ok(ApplicationAccountName);
        }
        // DropdownList DepartmentList
        [Route("GetDepartmentList")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentList()
        {
            var GetDepartmentList = await _ApplicationDepartmentService.GetAllDepartment();
            var ApplicationAccountName = GetDepartmentList.Select(x => new { DepartmentName = x.Name, DepartmentId = x.DepartmentId});
            return Ok(ApplicationAccountName);
        }
    }
}
