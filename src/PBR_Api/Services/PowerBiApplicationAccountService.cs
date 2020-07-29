using AutoMapper;
using PBR.PBR_Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPowerBiInterface = PBR.PBR_Api.Interfaces.IPowerBiApplicationAccountService;
using PBR.Application.Models;
using PBR.PBR_Api.ViewModels;

namespace PBR.PBR_Api.Services
{
    public class PowerBiApplicationAccountService: IPowerBiInterface
    {
        private readonly Application.Interfaces.IPowerBiApplicationAccountService _powerBiService;
        private readonly IMapper _mapper;

        public PowerBiApplicationAccountService(Application.Interfaces.IPowerBiApplicationAccountService powerBiService, IMapper mapper)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

       

        public async Task ApplicationAcccountDelete(int id)
        {
            await _powerBiService.DeleteApplicationAccount(id);

        }

        public async Task<IEnumerable<PowerBiAppliactionAccountViewModel>> checkGroupIdExists(string GroupId)
        {
            var list = await _powerBiService.checkGroupIdExists(GroupId);
            var mapped = _mapper.Map<IEnumerable<PowerBiAppliactionAccountViewModel>>(list);
            return mapped;
            
        }

        public async Task<IEnumerable<PowerBiAppliactionAccountViewModel>> CreateAccount(PowerBiAppliactionAccountViewModel powerBiAccountApplicationViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<ApplicationAccountModel>(powerBiAccountApplicationViewModel);
            var list = await _powerBiService.CreateApplicationAccount(ViewModelToAccountModel);
            return null;
            
        }

        public async Task<PowerBiAppliactionAccountViewModel> GetAccountById(int id)
        {
            var list = await _powerBiService.GetApplicationAccountById(id);
            var mapped = _mapper.Map<PowerBiAppliactionAccountViewModel>(list);
            return mapped;
        }

        public async Task<IEnumerable<PowerBiApplicationViewModel>> GetAllApplication()
        {
            var list = await _powerBiService.GetApplicationList();
            var mapped = _mapper.Map<IEnumerable<PowerBiApplicationViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<PowerBiAppliactionAccountViewModel>> GetAllApplicationAccount()
        {
            var list = await _powerBiService.GetApplicationAccountList();
            var mapped = _mapper.Map<IEnumerable<PowerBiAppliactionAccountViewModel>>(list);
            return mapped;
        }

        public async Task UpdateAccount(PowerBiAppliactionAccountViewModel powerBiAccountViewModel)
        {
             var ViewModelToAccountModel = _mapper.Map<ApplicationAccountModel>(powerBiAccountViewModel);

                await _powerBiService.ApplicationAccountUpdate(ViewModelToAccountModel);

            
        }
    }
}
