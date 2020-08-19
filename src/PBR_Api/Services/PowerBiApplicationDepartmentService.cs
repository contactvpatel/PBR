using AutoMapper;
using PBR.PBR_Api.Interfaces;
using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPowerBiInterface = PBR.PBR_Api.Interfaces.IPowerBiApplicationDepartmentService;
using PBR.Application.Models;
using System.Collections;

namespace PBR.PBR_Api.Services
{
    public class PowerBiApplicationDepartmentService : IPowerBiInterface
    {
        private readonly Application.Interfaces.IPowerBiApplicationDepartmentService _powerBiService;
        private readonly IMapper _mapper;

        public PowerBiApplicationDepartmentService(Application.Interfaces.IPowerBiApplicationDepartmentService powerBiService, IMapper mapper)
        {
            _powerBiService = powerBiService ?? throw new ArgumentNullException(nameof(powerBiService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ApplicationDepartmentDelete(int id)
        {
            await _powerBiService.DeleteApplicationDepartment(id);
        }
        public async Task<PowerBiApplicationDepartmentViewModel> ApplicationDepartmentUpdateAccount(PowerBiApplicationDepartmentViewModel powerBiApplicationDepartmentViewModel)
        {
            var ViewModelToDepartmentAccountModel = _mapper.Map<ApplicationDepartmentModel>(powerBiApplicationDepartmentViewModel);

           var UpdateApplicationDepartment =await _powerBiService.ApplicationDepartmentUpdate(ViewModelToDepartmentAccountModel);
            var GetUpdateApplicationDepartment = _mapper.Map<PowerBiApplicationDepartmentViewModel>(UpdateApplicationDepartment);
            return GetUpdateApplicationDepartment;
        }

        public async Task<IEnumerable<PowerBiApplicationDepartmentViewModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId)
        {
            var list = await _powerBiService.CheckApplicatioIdAndDepartmentIdExists(ApplicationId, DepartmentId);
            var mapped = _mapper.Map<IEnumerable<PowerBiApplicationDepartmentViewModel>>(list);
            return mapped;
        }

        public async Task<PowerBiApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(PowerBiApplicationDepartmentViewModel powerBiApplicationDepartmentViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<ApplicationDepartmentModel>(powerBiApplicationDepartmentViewModel);
            var list = await _powerBiService.CreateApplicationDepartmentAccount(ViewModelToAccountModel);
            return null;
        }

        public IList GetAllApplicationDepartmentAccount()
        {
            var GetApplicationDepartmentList =  _powerBiService.GetApplicationDepartmentList();
           
            return GetApplicationDepartmentList;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartment()
        {
            var list = await _powerBiService.GetDepartmentList();
            var mapped = _mapper.Map<IEnumerable<DepartmentViewModel>>(list);
            return mapped;
        }

        public async Task<PowerBiApplicationDepartmentViewModel> GetApplicationDepartmentById(int id)
        {
            var list = await _powerBiService.GetApplicationDepartmentById(id);
            var mapped = _mapper.Map<PowerBiApplicationDepartmentViewModel>(list);
            return mapped;
        }
    }
}
