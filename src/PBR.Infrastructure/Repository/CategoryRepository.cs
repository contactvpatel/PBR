using PBR.Core.Entities;
using PBR.Core.Repositories;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext dbContext) : base(dbContext)
        {            
        }

        public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
        {            
            var spec = new CategoryWithProductsSpecification(categoryId);
            var category = (await GetAsync(spec)).FirstOrDefault();
            return category;
        }
    }
}
