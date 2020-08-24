using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAccountInterface = PBR.PBR_Api.Interfaces.IAccountService;
using PBR.Application.Models;
using System.Text;
using PBR.PBR_Api.ViewModels;

namespace PBR.PBR_Api.Services
{
    public class AccountService : IAccountInterface
    {
        private readonly Application.Interfaces.IAccountService _Service;
        private readonly IMapper _mapper;

        public AccountService(Application.Interfaces.IAccountService Service , IMapper mapper)
        {
         _Service = Service ?? throw new ArgumentNullException(nameof(Service));
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

      
        public async Task<IEnumerable<AccountViewModel>> CreateAccount(AccountViewModel AccountViewModel)
        {
           
            var ViewModelToAccountModel = _mapper.Map<AccountModel>(AccountViewModel);
            var list = await _Service.CreateAccount(ViewModelToAccountModel);
            return null;
        }
        public async Task<AccountViewModel> GetAccountById(int AccountId)
        {
            var list = await _Service.GetAccountById(AccountId);
            var mapped = _mapper.Map<AccountViewModel>(list);
            return mapped;
        }
        public async Task<IEnumerable<AccountViewModel>> GetAllAccount()
        {
            var list = await _Service.GetAccountList();
            var mapped = _mapper.Map<IEnumerable<AccountViewModel>>(list);
            return mapped;
        }

        public async Task<AccountViewModel> UpdateAccount(AccountViewModel AccountViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<AccountModel>(AccountViewModel);
            var UpdateData= await _Service.AccountUpdate(ViewModelToAccountModel);
            var GetUpdateData = _mapper.Map<AccountViewModel>(UpdateData);

            return GetUpdateData;
        }
        public async Task AcccountDelete(int id)
        {

            //var ViewModelToAccountModel = _mapper.Map<AccountModel>(AccountViewModel);
            await _Service.DeleteAccount(id);
        }
        public async Task<string> GetApplicationByAccountWingHTML(int id)
        {
            StringBuilder html = new StringBuilder();
            html.Append(@"<option value="""">--- Select ---</option>");
            if (id!=null)
            {
                
                var  reports = await _Service.GetApplicationByAccount(id); 
                foreach (var responsePositionMasterModel in reports)
                {
                 html.AppendFormat(@"<option value=""{0}"">{1}</option>", responsePositionMasterModel.Id, responsePositionMasterModel.Application.ApplicationName);
                }
            }
            return html.ToString();

        }

        public async Task<IEnumerable<AccountViewModel>> CheckUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret)
        {
            var list = await _Service.checkUserNameClientIdClientSecret(UserName,ClientId,ClientSecret);
            var mapped = _mapper.Map<IEnumerable<AccountViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<AccountViewModel>> CheckAccountNameExists(string AccountName)
        {
            var list = await _Service.checkAccountNameExists(AccountName);
            var mapped = _mapper.Map<IEnumerable<AccountViewModel>>(list);
            return mapped;
        }

       
        //public async Task<ApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(ApplicationDepartmentViewModel  ApplicationDepartmentViewModel )
        //{
        //    var ViewModelToAccountModel = _mapper.Map<ApplicationDepartmentModel>(ApplicationDepartmentViewModel);
        //    var list = await _Service.CreateApplicationDepartmentAccount(ViewModelToAccountModel);
        //    return null;
        //}
    }
}
