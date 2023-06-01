using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
