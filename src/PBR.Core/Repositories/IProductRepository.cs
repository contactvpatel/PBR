using PBR.Core.Entities;
using PBR.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PBR.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);
    }
}
