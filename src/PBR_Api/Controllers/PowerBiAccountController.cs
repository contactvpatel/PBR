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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _Service;
        private readonly IApplicationAccountService _ApplicationAccountService;
        public AccountController(IAccountService Service, IApplicationAccountService ApplicationAccountService)
        {
            _Service = Service ?? throw new ArgumentNullException(nameof(Service));
            _ApplicationAccountService = ApplicationAccountService ?? throw new ArgumentNullException(nameof(ApplicationAccountService));
        }
        
        //Display All Account Api
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        { 
         var AccountList = await _Service.GetAllAccount();
         return Ok(AccountList);
        }
        
        //Create Account Screen Api
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(AccountViewModel accountModel)
        {
           
            
            accountModel.AccessToken = "asasasSDdsd";
            accountModel.RefreshToken = "asasasSDdsd";
            accountModel.CreatedDate = System.DateTime.Now;
            accountModel.LastUpdatedDate = System.DateTime.Now;
            accountModel.ExpiresIn = 565656565;
            accountModel.ExpiresOn = 565656565;
            accountModel.AccountName =  accountModel.AccountName.Replace(" ", "");
            accountModel.UserName =     accountModel.UserName.Replace(" ", "");
            accountModel.ClientId =     accountModel.ClientId.Replace(" ", "");
            accountModel.ClientSecret = accountModel.ClientSecret.Replace(" ", "");

            var existUserNameClientIdandClientScret = await _Service.CheckUserNameClientIdClientSecret(accountModel.UserName, accountModel.ClientId, accountModel.ClientSecret);
            var existsAccountName = await _Service.CheckAccountNameExists(accountModel.AccountName);
            if (existsAccountName.Count() >= 1)
            {
                ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title= "This AccountName already exists, Please Enter different Account Name."
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
                    Title= "UserName And ClientId And ClientSecret is already exists, please Try Diffrent."
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
                var AccountList = await _Service.CreateAccount(accountModel);
                return RedirectToAction("Index");
            }

        }

        //Get Particular GetAccountById
        [Route("{GetAccountById}/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAccountById(int Id)
        {
            var AccountList = await _Service.GetAccountById(Id);
            return Ok(AccountList);
        }

        //Update UpdateAccount Api
        [Route("Edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(AccountViewModel AccountViewModel)
        {
            var AccountList = await _Service.GetAccountById(AccountViewModel.Id);
            AccountViewModel.ExpiresIn = AccountList.ExpiresIn;
            AccountViewModel.ExpiresOn= AccountList.ExpiresOn;
            AccountViewModel.CreatedDate= AccountList.CreatedDate;
            AccountViewModel.ClientSecret= AccountList.ClientSecret;
            AccountViewModel.RefreshToken= AccountList.RefreshToken;
            AccountViewModel.AccessToken = AccountList.AccessToken;
            AccountViewModel.LastUpdatedDate = DateTime.Now;
            AccountViewModel.AccountName = AccountViewModel.AccountName.Replace(" ", "");
            AccountViewModel.UserName = AccountViewModel.UserName.Replace(" ", "");
            AccountViewModel.ClientId = AccountViewModel.ClientId.Replace(" ", "");
            AccountViewModel.ClientSecret = AccountViewModel.ClientSecret.Replace(" ", "");
            var existUserNameClientIdandClientScret = await _Service.CheckUserNameClientIdClientSecret(AccountViewModel.UserName, AccountViewModel.ClientId, AccountViewModel.ClientSecret);
            var AccountListById = await _Service.GetAccountById(AccountViewModel.Id);
            if (AccountListById.AccountName != AccountViewModel.AccountName || AccountListById.ClientId != AccountViewModel.ClientId || AccountListById.UserName != AccountViewModel.UserName || AccountListById.ClientSecret != AccountViewModel.ClientSecret)
            {
                var existsAccountName = await _Service.CheckAccountNameExists(AccountViewModel.AccountName);
                if ((existsAccountName.Count() >= 1 && AccountListById.AccountName != AccountViewModel.AccountName) && existUserNameClientIdandClientScret.Count() >= 1 && (AccountListById.ClientId != AccountViewModel.ClientId || AccountListById.UserName != AccountViewModel.UserName || AccountListById.ClientSecret != AccountViewModel.ClientSecret))
                {
                    ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                    ModelState.AddModelError("", "UserName And ClientId And ClientSecret is already exists, please Try Diffrent.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {

                        Status = StatusCodes.Status400BadRequest,
                        Title= "This AccountName already exists, Please Enter different Account Name , UserName And ClientId And ClientSecret is already exists, please Try Diffrent."
                    };

                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;

                    var result = new BadRequestObjectResult(problemDetails);
                    //result.ContentTypes.Add("application/problem+json");
                    //result.ContentTypes.Add("application/problem+xml");
                    return result;
                }
                else if (existsAccountName.Count() >= 1 && AccountListById.AccountName!=AccountViewModel.AccountName)
                {
                    ModelState.AddModelError("AccountName", "This AccountName already exists, Please Enter different Account Name.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "This AccountName already exists, Please Enter different Account Name."
                    };

                    var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                    problemDetails.Extensions["traceId"] = traceId;
                    problemDetails.Title = "This AccountName already exists, Please Enter different Account Name.";
                    var result = new BadRequestObjectResult(problemDetails);
                    //result.ContentTypes.Add("application/problem+json");
                    //result.ContentTypes.Add("application/problem+xml");
                    return result;
                }
                else if (existUserNameClientIdandClientScret.Count() >= 1 && (AccountListById.ClientId != AccountViewModel.ClientId || AccountListById.UserName != AccountViewModel.UserName || AccountListById.ClientSecret != AccountViewModel.ClientSecret))
                {
                    ModelState.AddModelError("", "UserName And ClientId And ClientSecret is already exists, please Try Diffrent.");
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title= "UserName And ClientId And ClientSecret is already exists, please Try Diffrent"
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
                    var GetUpdataData= await _Service.UpdateAccount(AccountViewModel);
                return Ok(GetUpdataData);
                }
            }
            else 
            {
               var GetUpdataData= await _Service.UpdateAccount(AccountViewModel);
                return Ok(GetUpdataData);
            }
             
        }
       
        // Delate Account Record(IsActive==False)Update
        [Route("{DeleteAccount}/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(string Id)
        {
            int DelateAccountId = Convert.ToInt32(Id);
               await _Service.AcccountDelete(DelateAccountId);
            return Ok();
        }
    }
}
