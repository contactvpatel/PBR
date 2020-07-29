using AutoMapper;
using PBR.Application.Interfaces;
using PBR.Application.Mapper;
using PBR.Application.Models;
using PBR.Core.Entities;
using PBR.Core.Interfaces;
using PBR.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Services
{
    
   public class PowerBiApplicationDepartmentService: IPowerBiApplicationDepartmentService
    {
        private readonly IPowerBiApplicationDepartmentRepository _powerBiApplicationDepartmentService;
        private readonly IAppLogger<PowerBiApplicationDepartmentService> _logger;
        private readonly IPowerBiDepartmentRepository _powerBiDepartmentRepository;
        public PowerBiApplicationDepartmentService(IPowerBiDepartmentRepository powerBiDepartmentRepository,IPowerBiApplicationDepartmentRepository  IpowerBiApplicationDepartmentRepository , IAppLogger<PowerBiApplicationDepartmentService> logger)
        {
            _powerBiDepartmentRepository=powerBiDepartmentRepository ?? throw new ArgumentNullException(nameof(powerBiDepartmentRepository));
            _powerBiApplicationDepartmentService = IpowerBiApplicationDepartmentRepository ?? throw new ArgumentNullException(nameof(IpowerBiApplicationDepartmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task<ApplicationDepartmentModel> CreateApplicationDepartmentAccount(ApplicationDepartmentModel applicationDepartmentModel)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ApplicationDepartment>(applicationDepartmentModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _powerBiApplicationDepartmentService.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - PBRAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ApplicationDepartmentModel>(applicationDepartmentModel);
            return newMappedEntity;
        }

        public async Task DeleteApplicationDepartment(int id)
        {
            var GetIdByAccountId = await _powerBiApplicationDepartmentService.GetByIdAsync(id);
            GetIdByAccountId.IsActive = false;
            // var cc = ObjectMapper.Mapper.Map<AccountModel, Account>(accountModel, editProduct);
            await _powerBiApplicationDepartmentService.UpdateAsync(GetIdByAccountId);
        }

        public async Task<ApplicationDepartmentModel> GetApplicationDepartmentById(int id)
        {
            var product = await _powerBiApplicationDepartmentService.GetByIdAsync(id);
            var mapped = ObjectMapper.Mapper.Map<ApplicationDepartmentModel>(product);
            return mapped;
        }
        public async Task<IEnumerable<ApplicationDepartmentModel>> GetApplicationDepartmentList()
        {
            var accounts = await _powerBiApplicationDepartmentService.GetApplicationAccountListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationDepartmentModel>>(accounts);
            return mapped;
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentList()
        {
            var Department = await _powerBiDepartmentRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<DepartmentModel>>(Department);
            return mapped;
        }
    }
}
