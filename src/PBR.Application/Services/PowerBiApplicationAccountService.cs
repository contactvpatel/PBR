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
    public class ApplicationAccountService : IApplicationAccountService
    {
        private readonly IApplicationAccountRepository _ApplicationAccountService;
        private readonly IApplicationRepository _ApplicationRepository;
        private readonly IAppLogger<ApplicationAccountService> _logger;
        public ApplicationAccountService(IApplicationAccountRepository iApplicationAccountRepository, IApplicationRepository ApplicationRepository, IAppLogger<ApplicationAccountService> logger )
        {
            _ApplicationRepository = ApplicationRepository??throw new ArgumentNullException(nameof(ApplicationRepository));
            _ApplicationAccountService = iApplicationAccountRepository ?? throw new ArgumentNullException(nameof(iApplicationAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ApplicationAccountModel> ApplicationAccountUpdate(ApplicationAccountModel applicationAccount)
        {
            var editProduct = await _ApplicationAccountService.GetByIdAsync(applicationAccount.Id);
            var cc = ObjectMapper.Mapper.Map<ApplicationAccountModel, ApplicationAccount>(applicationAccount, editProduct);
          var ApplicationAccountUpdate=  await _ApplicationAccountService.UpdateAsync(cc);
            var GetApplicationAccount = ObjectMapper.Mapper.Map<ApplicationAccountModel>(ApplicationAccountUpdate);
            return GetApplicationAccount;

        }
          public async Task<IEnumerable<ApplicationAccountModel>> CheckGroupIdExists(string AccountName)
        {
            var applicationAccount = await _ApplicationAccountService.CheakGroupIdExists(AccountName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(applicationAccount);
            return mapped;
            
        }

        public async Task<ApplicationAccountModel> CreateApplicationAccount(ApplicationAccountModel accountModel)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ApplicationAccount>(accountModel);
            if (mappedEntity == null)
            throw new ApplicationException($"Entity could not be mapped.");
            
            var newEntity = await _ApplicationAccountService.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - PBRAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ApplicationAccountModel>(accountModel);
            return newMappedEntity;
        }

        public async Task DeleteApplicationAccount(int id)
        {
            var GetIdByAccountId = await _ApplicationAccountService.GetByIdAsync(id);
            GetIdByAccountId.IsActive = false;
            // var cc = ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editProduct);
            await _ApplicationAccountService.UpdateAsync(GetIdByAccountId);
        }

        public async Task<ApplicationAccountModel> GetApplicationAccountById(int ApplicationAccountid)
        {
            var applicationAccount = await _ApplicationAccountService.GetByIdAsync(ApplicationAccountid);
            var mapped = ObjectMapper.Mapper.Map<ApplicationAccountModel>(applicationAccount);
            return mapped;
        }
        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationAccountList()
        {
            var applicationAccount = await _ApplicationAccountService.GetApplicationAccountListAsync();/*GetAllAsync();*/
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(applicationAccount);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationModel>> GetApplicationList()
        {
            var applicationAccount = await _ApplicationRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationModel>>(applicationAccount);
            return mapped;
        }
    }
}
