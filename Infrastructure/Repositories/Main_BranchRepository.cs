using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class Main_BranchRepository : GenericRepository<Main_Branch>, IMain_BranchRepository
    {
        public Main_BranchRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
