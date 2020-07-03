using PBR.Core.Entities;
using PBR.Core.Repositories.Base;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
