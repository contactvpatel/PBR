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
    public class PowerBiApplicationDepartmentController : ControllerBase
    {
        private readonly IPowerBiAccountService _powerBiService;
        private readonly IPowerBiApplicationAccountService _powerBiApplicationAccountService;

        private readonly IPowerBiApplicationDepartmentService _powerBiApplicationDepartmentService;
        public PowerBiApplicationDepartmentController(IPowerBiAccountService powerBiService, IPowerBiApplicationDepartmentService iPowerBiApplicationDepartmentService, IPowerBiApplicationAccountService powerBiApplicationAccountService)
        {
            _powerBiApplicationAccountService = powerBiApplicationAccountService ?? throw new ArgumentNullException(nameof(powerBiApplicationAccountService));

            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _powerBiApplicationDepartmentService = iPowerBiApplicationDepartmentService ?? throw new ArgumentNullException(nameof(iPowerBiApplicationDepartmentService));
        }
       
        //Display All AplicationDepartment Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ApplicationDepartment = _powerBiApplicationDepartmentService.GetAllApplicationDepartmentAccount();
           
            return Ok(ApplicationDepartment);
        }
       
        //Create ApplicationDepartment Screen Api
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(PowerBiApplicationDepartmentViewModel powerBiApplicationDepartmentViewModel)
        {
            var ApplicatioIdAndDepartmentIdExists = await _powerBiApplicationDepartmentService.CheckApplicatioIdAndDepartmentIdExists(powerBiApplicationDepartmentViewModel.ApplicationAccountId,powerBiApplicationDepartmentViewModel.DepartmentId);
            if (ApplicatioIdAndDepartmentIdExists.Count()>=1)
            {
                ModelState.AddModelError("", "This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id.");
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
                powerBiApplicationDepartmentViewModel.CreatedDate = System.DateTime.Now;
                powerBiApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
                powerBiApplicationDepartmentViewModel.IsActive = true;
                await _powerBiApplicationDepartmentService.CreateApplicationDepartmentAccount(powerBiApplicationDepartmentViewModel);
                return Ok();
            }
            
            
        }

        //Get Particular ApplicationDepartmentAccount
        [Route("{GeApplicationAccounttById}/{id}")]
        [HttpGet]
        public async Task<ActionResult> GeApplicationAccounttById(int Id)
        {
            var AccountListById = await _powerBiApplicationDepartmentService.GetApplicationDepartmentById(Id);
            return Ok(AccountListById);
        }
        //Update ApplicationDepartment Api
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(PowerBiApplicationDepartmentViewModel powerBiApplicationDepartmentViewModel )

        {

            var GetCurrentFiled = await _powerBiApplicationDepartmentService.GetApplicationDepartmentById(powerBiApplicationDepartmentViewModel.Id);
            powerBiApplicationDepartmentViewModel.CreatedDate = GetCurrentFiled.CreatedDate;
            powerBiApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
            var ApplicatioIdAndDepartmentIdExists = await _powerBiApplicationDepartmentService.CheckApplicatioIdAndDepartmentIdExists(powerBiApplicationDepartmentViewModel.ApplicationAccountId, powerBiApplicationDepartmentViewModel.DepartmentId);

            if (ApplicatioIdAndDepartmentIdExists.Count() >= 1 &&(GetCurrentFiled.ApplicationAccountId!=powerBiApplicationDepartmentViewModel.ApplicationAccountId || GetCurrentFiled.DepartmentId!= powerBiApplicationDepartmentViewModel.DepartmentId))
            {
                ModelState.AddModelError("", "This DepartmentId And ApplicationAccountId Is Exists  Please Enter different Id.");
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
                powerBiApplicationDepartmentViewModel.LastUpdatedDate = System.DateTime.Now;
               var GetUpdateApplicationDepartment= await _powerBiApplicationDepartmentService.ApplicationDepartmentUpdateAccount(powerBiApplicationDepartmentViewModel);
                return Ok(GetUpdateApplicationDepartment);
            }
        }

        // Delate ApplicationDepartmentAccount Record(IsActive==False)Update
        [Route("{Delete}/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _powerBiApplicationDepartmentService.ApplicationDepartmentDelete(Id);
            return RedirectToAction("Index");
        }
        // DropdownList AccountName And Application And Id        
        [Route("GetApplicationNameAndAccountName")]
        [HttpGet]
        public async Task<IActionResult> GetApplicationNameAndAccountName()
        {
            var applicationNameAndAccountName = await _powerBiApplicationAccountService.GetAllApplicationAccount();
            var ApplicationAccountName = applicationNameAndAccountName.Select(x => new { AccountName = x.Account.AccountName, ApplicationName = x.Application.ApplicationName, id = x.Id });
            return Ok(ApplicationAccountName);
        }
        // DropdownList DepartmentList
        [Route("GetDepartmentList")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentList()
        {
            var GetDepartmentList = await _powerBiApplicationDepartmentService.GetAllDepartment();
            var ApplicationAccountName = GetDepartmentList.Select(x => new { DepartmentName = x.Name, DepartmentId = x.DepartmentId});
            return Ok(ApplicationAccountName);
        }
    }
}
