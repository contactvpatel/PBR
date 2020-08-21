using AutoMapper;
using PBR.Application.Interfaces;
using PBR.Application.Mapper;
using PBR.Application.Models;
using PBR.Core.Entities;
using PBR.Core.Interfaces;
using PBR.Core.Repositories;
using System;
using System.Collections;
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
        public async Task<ApplicationDepartmentModel> ApplicationDepartmentUpdate(ApplicationDepartmentModel accountModel)
        {
            var editProduct = await _powerBiApplicationDepartmentService.GetByIdAsync(accountModel.Id);
        

            var cc = ObjectMapper.Mapper.Map<ApplicationDepartmentModel, ApplicationDepartment>(accountModel, editProduct);

          var UpdateApplicationDepartment= await _powerBiApplicationDepartmentService.UpdateAsync(cc);
            var GetApplicationDepartment = ObjectMapper.Mapper.Map<ApplicationDepartmentModel>(UpdateApplicationDepartment);
            return GetApplicationDepartment;
        }
        public async Task<ApplicationDepartmentModel> GetApplicationDepartmentById(int id)
        {
            var applicationDepartment = await _powerBiApplicationDepartmentService.GetByIdAsync(id);
            var mapped = ObjectMapper.Mapper.Map<ApplicationDepartmentModel>(applicationDepartment);
            return mapped;
        }
        public IList GetApplicationDepartmentList()
        {
            
            var applicationDepartment =  _powerBiApplicationDepartmentService.ApplicationDepartmentListAsync();
            return applicationDepartment;
        }

        public async Task<IEnumerable<DepartmentModel>> GetDepartmentList()
        {
            var Department = await _powerBiDepartmentRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<DepartmentModel>>(Department);
            return mapped;
        }

        public async Task<IEnumerable<ApplicationDepartmentModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId)
        {
            var applicationAccount = await _powerBiApplicationDepartmentService.CheckApplicatioIdAndDepartmentIdExists(ApplicationId, DepartmentId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ApplicationDepartmentModel>>(applicationAccount);
            return mapped;
        }
    }
}
