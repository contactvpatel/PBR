using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPowerBiInterface = PBR.PBR_Api.Interfaces.IPowerBiAccountService;
using PBR.Application.Models;
using System.Text;
using PBR.PBR_Api.ViewModels;

namespace PBR.PBR_Api.Services
{
    public class PowerBiAccountService : IPowerBiInterface
    {
        private readonly Application.Interfaces.IPowerBiAccountService _powerBiService;
        private readonly IMapper _mapper;

        public PowerBiAccountService(Application.Interfaces.IPowerBiAccountService powerBiService , IMapper mapper)
        {
         _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

      
        public async Task<IEnumerable<PowerBiAccountViewModel>> CreatePowerBiAccount(PowerBiAccountViewModel powerBiAccountViewModel)
        {
           
            var ViewModelToAccountModel = _mapper.Map<AccountModel>(powerBiAccountViewModel);
            var list = await _powerBiService.CreateAccount(ViewModelToAccountModel);
            return null;
        }
        public async Task<PowerBiAccountViewModel> GetAccountById(int AccountId)
        {
            var list = await _powerBiService.GetAccountById(AccountId);
            var mapped = _mapper.Map<PowerBiAccountViewModel>(list);
            return mapped;
        }
        public async Task<IEnumerable<PowerBiAccountViewModel>> GetAllAccount()
        {
            var list = await _powerBiService.GetAccountList();
            var mapped = _mapper.Map<IEnumerable<PowerBiAccountViewModel>>(list);
            return mapped;
        }

        public async Task UpdateAccount(PowerBiAccountViewModel powerBiAccountViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<AccountModel>(powerBiAccountViewModel);

             await _powerBiService.AccountUpdate(ViewModelToAccountModel);

        }
        public async Task AcccountDelete(int id)
        {

            //var ViewModelToAccountModel = _mapper.Map<AccountModel>(powerBiAccountViewModel);
            await _powerBiService.DeleteAccount(id);
        }
        public async Task<string> GetApplicationByAccountWingHTML(int id)
        {
            StringBuilder html = new StringBuilder();
            html.Append(@"<option value="""">--- Select ---</option>");
            if (id!=null)
            {
                
                var  reports = await _powerBiService.GetApplicationByAccount(id); 
                foreach (var responsePositionMasterModel in reports)
                {
                 html.AppendFormat(@"<option value=""{0}"">{1}</option>", responsePositionMasterModel.Id, responsePositionMasterModel.Application.ApplicationName);
                }
            }
            return html.ToString();

        }

        public async Task<IEnumerable<PowerBiAccountViewModel>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret)
        {
            var list = await _powerBiService.checkUserNameClientIdClientSecret(UserName,ClientId,ClientSecret);
            var mapped = _mapper.Map<IEnumerable<PowerBiAccountViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<PowerBiAccountViewModel>> checkAccountNameExists(string AccountName)
        {
            var list = await _powerBiService.checkAccountNameExists(AccountName);
            var mapped = _mapper.Map<IEnumerable<PowerBiAccountViewModel>>(list);
            return mapped;
        }
        //public async Task<PowerBiApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(PowerBiApplicationDepartmentViewModel  powerBiApplicationDepartmentViewModel )
        //{
        //    var ViewModelToAccountModel = _mapper.Map<ApplicationDepartmentModel>(powerBiApplicationDepartmentViewModel);
        //    var list = await _powerBiService.CreateApplicationDepartmentAccount(ViewModelToAccountModel);
        //    return null;
        //}
    }
}
