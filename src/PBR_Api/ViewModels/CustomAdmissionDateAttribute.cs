using PBR.PBR_Api.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PBR.PBR_Api.Interfaces;
namespace PBR.PBR_Api.ViewModels
{
    internal class CustomAdmissionDateAttribute : ValidationAttribute
    {
        private  readonly IAccountService _accountService;

     

        public CustomAdmissionDateAttribute(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
           
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var student = (AccountViewModel)validationContext.ObjectInstance;

            //var existUserNameClientIdandClientScret =  _Service.checkUserNameClientIdClientSecret(accountModel.UserName, accountModel.ClientId, accountModel.ClientSecret);
            var existsAccountName = _accountService.CheckAccountNameExists(student.AccountName);
            //if (existsAccountName.Count() >= 1)
            //{
            //    return new ValidationResult("This AccountName already exists, Please Enter different Account Name.");
            //}

            return (student.AccountName == "18")
                ? ValidationResult.Success
                : new ValidationResult("Student should be at least 18 years old.");

        }
    }
}