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
    public class PowerBiAccountService : IPowerBiAccountService
    {
        private readonly IPowerBiAccountRepository _IpowerBiAccountRepository;
        private readonly IAppLogger<PowerBiAccountService> _logger;
        private readonly IPowerBiApplicationAccountRepository _IpowerBiApplicationAccountRepository;
        public PowerBiAccountService(IPowerBiApplicationAccountRepository IpowerBiApplicationAccountRepository,
        IPowerBiAccountRepository ipowerBiAccountRepository,
        IAppLogger<PowerBiAccountService> logger)
        {
            _IpowerBiApplicationAccountRepository = IpowerBiApplicationAccountRepository?? throw new ArgumentNullException(nameof(IpowerBiApplicationAccountRepository));
            _IpowerBiAccountRepository = ipowerBiAccountRepository ?? throw new ArgumentNullException(nameof(ipowerBiAccountRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AccountModel> CreateAccount(AccountModel accountModel)
        {
            //await ValidateProductIfExist(productModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Account>(accountModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _IpowerBiAccountRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - PBRAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<AccountModel>(accountModel);
            return newMappedEntity;

        }
        public async Task<IEnumerable<AccountModel>> checkUserNameClientIdClientSecret(string UserName, string ClientId, string ClientSecret)
        {
            var product = await _IpowerBiAccountRepository.checkUserNameClientIdClientSecret(UserName,ClientId,ClientSecret);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(product);
            return mapped;
        }
        public async Task<IEnumerable<AccountModel>> checkAccountNameExists(string AccountName)
        {
            var product = await _IpowerBiAccountRepository.CheakAccountNameExists(AccountName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(product);
            return mapped;
        }
        public async Task<AccountModel> GetAccountById(int AccountId)
        {
            var product = await _IpowerBiAccountRepository.GetByIdAsync(AccountId);
            var mapped = ObjectMapper.Mapper.Map<AccountModel>(product);
            return mapped;
        }
        public async Task<IEnumerable<AccountModel>> GetAccountList()
        {
            var accounts = await _IpowerBiAccountRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
            return mapped;
        }
        public  IEnumerable<AccountModel> GetAccount()
        {
            var accounts =  _IpowerBiAccountRepository.GetPowerBiAccountAysc();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<AccountModel>>(accounts);
            return mapped;
        }
        public async Task AccountUpdate(AccountModel accountModel)
        {
            var editProduct = await _IpowerBiAccountRepository.GetByIdAsync(accountModel.Id);
            //if (editProduct == null)

           var cc= ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editProduct);

            await _IpowerBiAccountRepository.UpdateAsync(cc);
        }

        public async Task DeleteAccount(int id)
        {
            var GetIdByAccountId = await _IpowerBiAccountRepository.GetByIdAsync(id);
            GetIdByAccountId.IsActive = false;
           // var cc = ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editProduct);
            await _IpowerBiAccountRepository.UpdateAsync(GetIdByAccountId);
        }
        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationByAccount(int id)
        {
            var accounts = await _IpowerBiApplicationAccountRepository.GetApplicationAccountListAsync(id);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(accounts);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationAccountModel>> GetApplicationNameByAccount(int id)
        {
            var accounts = await _IpowerBiApplicationAccountRepository.GetApplicationNameAccountListAsync(id);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationAccountModel>>(accounts);
            return mapped;
        }




        //public async Task<ApplicationDepartmentModel> CreateApplicationDepartmentAccount(ApplicationDepartmentModel  applicationDepartmentModel)
        //{
        //    var mappedEntity = ObjectMapper.Mapper.Map<ApplicationDepartment>(applicationDepartmentModel);
        //    if (mappedEntity == null)
        //        throw new ApplicationException($"Entity could not be mapped.");

        //    var newEntity = await _powerBiApplicationDepartmentRepository.AddAsync(mappedEntity);
        //    _logger.LogInformation($"Entity successfully added - PBRAppService");

        //    var newMappedEntity = ObjectMapper.Mapper.Map<ApplicationDepartmentModel>(applicationDepartmentModel);
        //    return newMappedEntity;
        //}


    }
}
