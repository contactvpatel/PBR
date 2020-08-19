using AutoMapper;
using PBR.Application.Interfaces;
using PBR.Application.Mapper;
using PBR.Application.Models;
using PBR.Core.Entities;
using PBR.Core.Interfaces;
using PBR.Core.Repositories;
using PBR.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Services
{
    public class PowerBiApplicationAccountService : IPowerBiApplicationAccountService
    {
        private readonly IPowerBiApplicationAccountRepository _powerBiApplicationAccountService;
        private readonly IPowerBiApplicationRepository _powerBiApplicationRepository;
        private readonly IAppLogger<PowerBiApplicationAccountService> _logger;
        public PowerBiApplicationAccountService(IPowerBiApplicationAccountRepository iPowerBiApplicationAccountRepository, IPowerBiApplicationRepository powerBiApplicationRepository, IAppLogger<PowerBiApplicationAccountService> logger )
        {
            _powerBiApplicationRepository = powerBiApplicationRepository??throw new ArgumentNullException(nameof(powerBiApplicationRepository));
            _powerBiApplicationAccountService = iPowerBiApplicationAccountRepository ?? throw new ArgumentNullException(nameof(iPowerBiApplicationAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ApplicationAccountModel> ApplicationAccountUpdate(ApplicationAccountModel applicationAccount)
        {
            var editProduct = await _powerBiApplicationAccountService.GetByIdAsync(applicationAccount.Id);
            var cc = ObjectMapper.Mapper.Map<ApplicationAccountModel, ApplicationAccount>(applicationAccount, editProduct);
          var ApplicationAccountUpdate=  await _powerBiApplicationAccountService.UpdateAsync(cc);
            var GetApplicationAccount = ObjectMapper.Mapper.Map<ApplicationAccountModel>(ApplicationAccountUpdate);
            return GetApplicationAccount;

        }
          public async Task<IEnumerable<ApplicationAccountModel>> CheckGroupIdExists(string AccountName)
        {
            var applicationAccount = await _powerBiApplicationAccountService.CheakGroupIdExists(AccountName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(applicationAccount);
            return mapped;
            
        }

        public async Task<ApplicationAccountModel> CreateApplicationAccount(ApplicationAccountModel accountModel)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ApplicationAccount>(accountModel);
            if (mappedEntity == null)
            throw new ApplicationException($"Entity could not be mapped.");
            
            var newEntity = await _powerBiApplicationAccountService.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - PBRAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ApplicationAccountModel>(accountModel);
            return newMappedEntity;
        }

        public async Task DeleteApplicationAccount(int id)
        {
            var GetIdByAccountId = await _powerBiApplicationAccountService.GetByIdAsync(id);
            GetIdByAccountId.IsActive = false;
            // var cc = ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editProduct);
            await _powerBiApplicationAccountService.UpdateAsync(GetIdByAccountId);
        }

        public async Task<ApplicationAccountModel> GetApplicationAccountById(int ApplicationAccountid)
        {
            var applicationAccount = await _powerBiApplicationAccountService.GetByIdAsync(ApplicationAccountid);
            var mapped = ObjectMapper.Mapper.Map<ApplicationAccountModel>(applicationAccount);
            return mapped;
        }
        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationAccountList()
        {
            var applicationAccount = await _powerBiApplicationAccountService.GetApplicationAccountListAsync();/*GetAllAsync();*/
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(applicationAccount);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationModel>> GetApplicationList()
        {
            var applicationAccount = await _powerBiApplicationRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationModel>>(applicationAccount);
            return mapped;
        }
    }
}
