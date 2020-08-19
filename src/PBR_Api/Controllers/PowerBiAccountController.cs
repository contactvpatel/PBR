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
    public class PowerBiAccountController : ControllerBase
    {
        private readonly IPowerBiAccountService _powerBiService;
        private readonly IPowerBiApplicationAccountService _powerBiApplicationAccountService;
        public PowerBiAccountController(IPowerBiAccountService powerBiService, IPowerBiApplicationAccountService powerBiApplicationAccountService)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _powerBiApplicationAccountService = powerBiApplicationAccountService ?? throw new ArgumentNullException(nameof(powerBiApplicationAccountService));
        }
        
        //Display All Account Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        { 
         var PowerBiAccountList = await _powerBiService.GetAllAccount();
         return Ok(PowerBiAccountList);
        }
        
        //Create Account Screen Api
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(PowerBiAccountViewModel accountModel)
        {
           accountModel.AccountName= accountModel.AccountName.Replace(" ","");
            
            accountModel.AccessToken = "asasasSDdsd";
            accountModel.RefreshToken = "asasasSDdsd";
            accountModel.CreatedDate = System.DateTime.Now;
            accountModel.LastUpdatedDate = System.DateTime.Now;
            accountModel.ExpiresIn = 565656565;
            accountModel.ExpiresOn = 565656565;

            var existUserNameClientIdandClientScret = await _powerBiService.CheckUserNameClientIdClientSecret(accountModel.UserName, accountModel.ClientId, accountModel.ClientSecret);
            var existsAccountName = await _powerBiService.CheckAccountNameExists(accountModel.AccountName);
            if (existsAccountName.Count() >= 1)
            {
                ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;

                var result = new BadRequestObjectResult(problemDetails);
                //result.ContentTypes.Add("application/problem+json");
                //result.ContentTypes.Add("application/problem+xml");
                return result;
            }
            else if (existUserNameClientIdandClientScret.Count() >= 1)
            {
                ModelState.AddModelError("", "UserName And ClientId And ClientSecret is already exists, please Try Diffrent.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };

                var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                problemDetails.Extensions["traceId"] = traceId;

                var result = new BadRequestObjectResult(problemDetails);
                //result.ContentTypes.Add("application/problem+json");
                //result.ContentTypes.Add("application/problem+xml");
                return result;
            }
            else
            {
                var PowerBiAccountList = await _powerBiService.CreatePowerBiAccount(accountModel);
                return RedirectToAction("Index");
            }

        }

        //Get Particular GetAccountById
        [Route("{GetAccountById}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountById(int Id)
        {
            var PowerBiAccountList = await _powerBiService.GetAccountById(Id);
            return Ok(PowerBiAccountList);
        }

        //Update UpdateAccount Api
        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(PowerBiAccountViewModel powerBiAccountViewModel)
        {
            var PowerBiAccountList = await _powerBiService.GetAccountById(powerBiAccountViewModel.Id);
            powerBiAccountViewModel.ExpiresIn = PowerBiAccountList.ExpiresIn;
            powerBiAccountViewModel.ExpiresOn= PowerBiAccountList.ExpiresOn;
            powerBiAccountViewModel.CreatedDate= PowerBiAccountList.CreatedDate;
            powerBiAccountViewModel.ClientSecret= PowerBiAccountList.ClientSecret;
            powerBiAccountViewModel.RefreshToken= PowerBiAccountList.RefreshToken;
            powerBiAccountViewModel.AccessToken = PowerBiAccountList.AccessToken;
            powerBiAccountViewModel.LastUpdatedDate = DateTime.Now;
            var existUserNameClientIdandClientScret = await _powerBiService.CheckUserNameClientIdClientSecret(powerBiAccountViewModel.UserName, powerBiAccountViewModel.ClientId, powerBiAccountViewModel.ClientSecret);
            var AccountListById = await _powerBiService.GetAccountById(powerBiAccountViewModel.Id);
            if (AccountListById.AccountName != powerBiAccountViewModel.AccountName || AccountListById.ClientId != powerBiAccountViewModel.ClientId || AccountListById.UserName != powerBiAccountViewModel.UserName || AccountListById.ClientSecret != powerBiAccountViewModel.ClientSecret)
            {
                var existsAccountName = await _powerBiService.CheckAccountNameExists(powerBiAccountViewModel.AccountName);
                if ((existsAccountName.Count() >= 1 && AccountListById.AccountName != powerBiAccountViewModel.AccountName) && existUserNameClientIdandClientScret.Count() >= 1 && (AccountListById.ClientId != powerBiAccountViewModel.ClientId || AccountListById.UserName != powerBiAccountViewModel.UserName || AccountListById.ClientSecret != powerBiAccountViewModel.ClientSecret))
                {
                    ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                    ModelState.AddModelError("", "UserName And ClientId And ClientSecret is already exists, please Try Diffrent.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };

                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;

                    var result = new BadRequestObjectResult(problemDetails);
                    //result.ContentTypes.Add("application/problem+json");
                    //result.ContentTypes.Add("application/problem+xml");
                    return result;
                }
                else if (existsAccountName.Count() >= 1 && AccountListById.AccountName!=powerBiAccountViewModel.AccountName)
                {
                    ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };

                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;
                    problemDetails.Title = "This AccountName already exists, Please Enter different Account Name.";
                    var result = new BadRequestObjectResult(problemDetails);
                    //result.ContentTypes.Add("application/problem+json");
                    //result.ContentTypes.Add("application/problem+xml");
                    return result;
                }
                else if (existUserNameClientIdandClientScret.Count() >= 1 && (AccountListById.ClientId != powerBiAccountViewModel.ClientId || AccountListById.UserName != powerBiAccountViewModel.UserName || AccountListById.ClientSecret != powerBiAccountViewModel.ClientSecret))
                {
                    ModelState.AddModelError("", "UserName And ClientId And ClientSecret is already exists, please Try Diffrent.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };

                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;

                    var result = new BadRequestObjectResult(problemDetails);
                    //result.ContentTypes.Add("application/problem+json");
                    //result.ContentTypes.Add("application/problem+xml");
                    return result;
                }
                else
                {
                    var GetUpdataData= await _powerBiService.UpdateAccount(powerBiAccountViewModel);
                return Ok(GetUpdataData);
                }
            }
            else 
            {
               var GetUpdataData= await _powerBiService.UpdateAccount(powerBiAccountViewModel);
                return Ok(GetUpdataData);
            }
             
        }
       
        // Delate Account Record(IsActive==False)Update
        [Route("{DeleteAccount}/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(string Id)
        {
            int DelateAccountId = Convert.ToInt32(Id);
               await _powerBiService.AcccountDelete(DelateAccountId);
            return Ok();
        }
    }
}
