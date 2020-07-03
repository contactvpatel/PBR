using PBR.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
    }
}
