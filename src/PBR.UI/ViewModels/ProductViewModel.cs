using System.Collections.Generic;

namespace PBR.UI.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            ProductList = new List<ProductViewModel>();
        }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<ProductViewModel> ProductList { get; set; }
        public string SearchTerm { get; set; }
    }
}
