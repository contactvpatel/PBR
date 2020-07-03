using System.Collections.Generic;

namespace PBR.UI.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public CategoryViewModel()
        {
            CategoryList = new List<CategoryViewModel>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryViewModel> CategoryList { get; set; }
    }

}
