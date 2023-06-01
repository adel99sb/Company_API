using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class Supply_ProcessRepository : GenericRepository<Supply_Process>, ISupply_ProcessRepository
    {
        public Supply_ProcessRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
