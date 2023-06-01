using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
        //public List<CompanyModel> GetAllCompanies()
        //{
        //    var res = new List<CompanyModel>();
        //    foreach (var item in this.GetAll())
        //    {
        //        res.Add(new CompanyModel(item.Id)
        //        {
        //            Name = item.Name,
        //            Activity = item.Activity,
        //            Creation_Date = item.Creation_Date,
        //            Location = new Location()
        //            {
        //                Latitude = item.Location.X,
        //                Longitude = item.Location.Y
        //            }
        //        });
        //    }
        //    return res;
        //}
    }
}
