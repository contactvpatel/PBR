using AutoMapper;
using PBR.PBR_Api.Interfaces;
using PBR.PBR_Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IInterface = PBR.PBR_Api.Interfaces.IApplicationDepartmentService;
using PBR.Application.Models;
using System.Collections;

namespace PBR.PBR_Api.Services
{
    public class ApplicationDepartmentService : IInterface
    {
        private readonly Application.Interfaces.IApplicationDepartmentService _Service;
        private readonly IMapper _mapper;

        public ApplicationDepartmentService(Application.Interfaces.IApplicationDepartmentService Service, IMapper mapper)
        {
            _Service = Service ?? throw new ArgumentNullException(nameof(Service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task ApplicationDepartmentDelete(int id)
        {
            await _Service.DeleteApplicationDepartment(id);
        }
        public async Task<ApplicationDepartmentViewModel> ApplicationDepartmentUpdateAccount(ApplicationDepartmentViewModel ApplicationDepartmentViewModel)
        {
            var ViewModelToDepartmentAccountModel = _mapper.Map<ApplicationDepartmentModel>(ApplicationDepartmentViewModel);

           var UpdateApplicationDepartment =await _Service.ApplicationDepartmentUpdate(ViewModelToDepartmentAccountModel);
            var GetUpdateApplicationDepartment = _mapper.Map<ApplicationDepartmentViewModel>(UpdateApplicationDepartment);
            return GetUpdateApplicationDepartment;
        }

        public async Task<IEnumerable<ApplicationDepartmentViewModel>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId)
        {
            var list = await _Service.CheckApplicatioIdAndDepartmentIdExists(ApplicationId, DepartmentId);
            var mapped = _mapper.Map<IEnumerable<ApplicationDepartmentViewModel>>(list);
            return mapped;
        }

        public async Task<ApplicationDepartmentViewModel> CreateApplicationDepartmentAccount(ApplicationDepartmentViewModel ApplicationDepartmentViewModel)
        {
            var ViewModelToAccountModel = _mapper.Map<ApplicationDepartmentModel>(ApplicationDepartmentViewModel);
            var list = await _Service.CreateApplicationDepartmentAccount(ViewModelToAccountModel);
            return null;
        }

        public IList GetAllApplicationDepartmentAccount()
        {
            var GetApplicationDepartmentList =  _Service.GetApplicationDepartmentList();
           
            return GetApplicationDepartmentList;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartment()
        {
            var list = await _Service.GetDepartmentList();
            var mapped = _mapper.Map<IEnumerable<DepartmentViewModel>>(list);
            return mapped;
        }

        public async Task<ApplicationDepartmentViewModel> GetApplicationDepartmentById(int id)
        {
            var list = await _Service.GetApplicationDepartmentById(id);
            var mapped = _mapper.Map<ApplicationDepartmentViewModel>(list);
            return mapped;
        }
    }
}
