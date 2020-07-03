using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBR.UI.Interfaces;
using PBR.UI.ViewModels;

namespace PBR.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }
        public async Task<IActionResult> Index()
        {
            var cv = new CategoryViewModel { CategoryList = await _categoryService.GetCategories() };
            return View(cv);
        }
    }
}
