using AutoMapper;
using PBR.PBR_Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IInterface = PBR.PBR_Api.Interfaces.IApplicationAccountService;
using PBR.Application.Models;
using PBR.PBR_Api.ViewModels;

namespace PBR.PBR_Api.Services
{
    public class ApplicationAccountService: IInterface
    {
        private readonly Application.Interfaces.IApplicationAccountService _Service;
        private readonly IMapper _mapper;

        public ApplicationAccountService(Application.Interfaces.IApplicationAccountService Service, IMapper mapper)
        {
            _Service = Service ?? throw new ArgumentNullException(nameof(Service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

       

        public async Task ApplicationAcccountDelete(int id)
        {
            await _Service.DeleteApplicationAccount(id);

        }

        public async Task<IEnumerable<AppliactionAccountViewModel>> CheckGroupIdExists(string GroupId)
        {
            var list = await _Service.CheckGroupIdExists(GroupId);
            var mapped = _mapper.Map<IEnumerable<AppliactionAccountViewModel>>(list);
            return mapped;
            
        }

       

        public async Task<IEnumerable<AppliactionAccountViewModel>> CreateAccount(AppliactionAccountViewModel AccountApplicationViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<ApplicationAccountModel>(AccountApplicationViewModel);
            var list = await _Service.CreateApplicationAccount(ViewModelToAccountModel);
            return null;
            
        }

        public async Task<AppliactionAccountViewModel> GetApplicationAccountById(int id)
        {
            var list = await _Service.GetApplicationAccountById(id);
            var mapped = _mapper.Map<AppliactionAccountViewModel>(list);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationViewModel>> GetAllApplication()
        {
            var list = await _Service.GetApplicationList();
            var mapped = _mapper.Map<IEnumerable<ApplicationViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<AppliactionAccountViewModel>> GetAllApplicationAccount()
        {
            var list = await _Service.GetApplicationAccountList();
            var mapped = _mapper.Map<IEnumerable<AppliactionAccountViewModel>>(list);
          
            return mapped;
        }

        public async Task<AppliactionAccountViewModel> UpdateApplicationAccount(AppliactionAccountViewModel AccountViewModel)
        {
             var ViewModelToAccountModel = _mapper.Map<ApplicationAccountModel>(AccountViewModel);

              var UpdateApplicationAccount=  await _Service.ApplicationAccountUpdate(ViewModelToAccountModel);
            var GetUpdateApplicationAccount = _mapper.Map<AppliactionAccountViewModel>(UpdateApplicationAccount);

            return GetUpdateApplicationAccount;
        }
    }
}
