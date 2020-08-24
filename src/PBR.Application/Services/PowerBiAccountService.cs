using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PBR.Core.Entities;
using PBR.Core.Interfaces;
using PBR.Core.Repositories;
using PBR.Application.Models;
using PBR.Application.Mapper;
using PBR.Application.Interfaces;
using PBR.Core.Entities.Base;

namespace PBR.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _IAccountRepository;
        private readonly IAppLogger<AccountService> _logger;
        private readonly IApplicationAccountRepository _IApplicationAccountRepository;
        public AccountService(IApplicationAccountRepository IApplicationAccountRepository,
        IAccountRepository iAccountRepository,
        IAppLogger<AccountService> logger)
        {
            _IApplicationAccountRepository = IApplicationAccountRepository?? throw new ArgumentNullException(nameof(IApplicationAccountRepository));
            _IAccountRepository = iAccountRepository ?? throw new ArgumentNullException(nameof(iAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccountModel> CreateAccount(AccountModel accountModel)
        {

            var mappedEntity = ObjectMapper.Mapper.Map<Account>(accountModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _IAccountRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - PBRAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<AccountModel>(accountModel);
            return newMappedEntity;

        }
        public async Task<IEnumerable<AccountModel>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret)
        {
            var account = await _IAccountRepository.checkUserNameClientIdClientSecret(UserName,ClientId,ClientSecret);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(account);
            return mapped;
        }
        public async Task<IEnumerable<AccountModel>> checkAccountNameExists(string AccountName)
        {
            var account = await _IAccountRepository.CheakAccountNameExists(AccountName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(account);
            return mapped;
        }
        public async Task<AccountModel> GetAccountById(int AccountId)
        {
            var account = await _IAccountRepository.GetByIdAsync(AccountId);
            var mapped = ObjectMapper.Mapper.Map<AccountModel>(account);
            return mapped;
        }
        public async Task<IEnumerable<AccountModel>> GetAccountList()
        {
            var accounts = await _IAccountRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
            return mapped;
        }
        public  IEnumerable<AccountModel> GetAccount()
        {
            var accounts =  _IAccountRepository.GetAccountAysc();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
            return mapped;
        }
        public async Task<AccountModel> AccountUpdate(AccountModel accountModel)
        {
            var editAccount = await _IAccountRepository.GetByIdAsync(accountModel.Id);

           var cc= ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editAccount);
           var UpdatedData=  await _IAccountRepository.UpdateAsync(cc);
            var GetUpdatedData = ObjectMapper.Mapper.Map<AccountModel>(UpdatedData);

            return GetUpdatedData;


        }

        public async Task DeleteAccount(int id)
        {
            var GetIdByAccountId = await _IAccountRepository.GetByIdAsync(id);
            GetIdByAccountId.IsActive = false;
            await _IAccountRepository.UpdateAsync(GetIdByAccountId);
        }
        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationByAccount(int id)
        {
            var accounts = await _IApplicationAccountRepository.GetApplicationAccountListAsync(id);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(accounts);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationNameByAccount(int id)
        {
            var accounts = await _IApplicationAccountRepository.GetApplicationNameAccountListAsync(id);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(accounts);
            return mapped;
        }
    }
}
