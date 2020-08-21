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
        private  readonly IPowerBiAccountService _powerBiService;

     

        public CustomAdmissionDateAttribute(IPowerBiAccountService powerBiService)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
           
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var student = (PowerBiAccountViewModel)validationContext.ObjectInstance;

            //var existUserNameClientIdandClientScret =  _powerBiService.checkUserNameClientIdClientSecret(accountModel.UserName, accountModel.ClientId, accountModel.ClientSecret);
            var existsAccountName =  _powerBiService.CheckAccountNameExists(student.AccountName);
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