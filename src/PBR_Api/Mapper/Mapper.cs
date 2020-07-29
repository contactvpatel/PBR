using PBR.Application.Models;

using AutoMapper;
using PBR.Core.Entities;
using PBR.PBR_Api.ViewModels;

namespace PBR.UI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            
            CreateMap<AccountModel, PowerBiAccountViewModel>();
            CreateMap<PowerBiAccountViewModel, AccountModel>();
            CreateMap<ApplicationAccountModel, PowerBiAppliactionAccountViewModel>();
            CreateMap<PowerBiAppliactionAccountViewModel, ApplicationAccountModel>();
            CreateMap<PowerBiApplicationDepartmentViewModel, ApplicationDepartmentModel>();
            CreateMap<ApplicationDepartmentModel,PowerBiApplicationDepartmentViewModel>();
            CreateMap<ApplicationAccountModel, PowerBiApplicationViewModel>();

            CreateMap<ApplicationDepartmentModel, DepartmentViewModel>();
            CreateMap<PowerBiApplicationViewModel,ApplicationModel>();
            CreateMap<ApplicationModel, PowerBiApplicationViewModel>();
            CreateMap<DepartmentModel, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, DepartmentModel>();
        }
    }
}
