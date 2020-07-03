using PBR.UI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBR.UI.Interfaces
{
    // NOTE : This is the whole page service, it could be include all categories and products
    // this is the razor page based service
    public interface IIndexPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();        
    }
}
