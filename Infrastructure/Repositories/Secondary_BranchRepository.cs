using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class Secondary_BranchRepository : GenericRepository<Secondary_Branch>, ISecondary_BranchRepository
    {
        public Secondary_BranchRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
