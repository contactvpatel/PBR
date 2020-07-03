using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBR.UI.Interfaces;
using PBR.UI.ViewModels;

namespace PBR.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        public async Task<IActionResult> Index(string productName)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductList = await _productService.GetProducts(productName)
            };
            return View(productViewModel);
        }
    }
}
