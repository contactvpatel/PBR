using PBR.Application.Models;
using PBR.UI.ViewModels;
using AutoMapper;

namespace PBR.UI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ProductModel, ProductViewModel>();
            CreateMap<CategoryModel, CategoryViewModel>();
        }
    }
}
