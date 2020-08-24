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
            
            CreateMap<AccountModel, AccountViewModel>();
            CreateMap<AccountViewModel, AccountModel>();
            CreateMap<ApplicationAccountModel, AppliactionAccountViewModel>();
            CreateMap<AppliactionAccountViewModel, ApplicationAccountModel>();
            CreateMap<ApplicationDepartmentViewModel, ApplicationDepartmentModel>();
            CreateMap<ApplicationDepartmentModel,ApplicationDepartmentViewModel>();
            CreateMap<ApplicationAccountModel, ApplicationViewModel>();

            CreateMap<ApplicationDepartmentModel, DepartmentViewModel>();
            CreateMap<ApplicationViewModel,ApplicationModel>();
            CreateMap<ApplicationModel, ApplicationViewModel>();
            CreateMap<DepartmentModel, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, DepartmentModel>();
        }
    }
}
