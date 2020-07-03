using PBR.Application.Interfaces;
using PBR.UI.Interfaces;
using PBR.UI.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICategoryService = PBR.UI.Interfaces.ICategoryService;

namespace PBR.UI.Services
{
    public class CategoryService : ICategoryService
    {        
        private readonly Application.Interfaces.ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryService(Application.Interfaces.ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;
        }
    }
}
