using EL_KooD_API.Data.Context;
using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;
using EL_KooD_API.Infrastructure.Contracts;

namespace EL_KooD_API.Infrastructure.Repositories
{
    public class Manufacturing_ProcessRepository : GenericRepository<Manufacturing_Process>, IManufacturing_ProcessRepository
    {
        public Manufacturing_ProcessRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<Manufacturing_Report_ResultModel> GetManufacturing_Report_WithDate(Manufacturing_ReportModel manufacturing_ReportModel)
        {
            float TotalQuantity = 0.0f;
            var FinalResult = new Manufacturing_Report_ResultModel();
            var FilteringProcess =  this.GetAll().Where
             (
                i => i.Main_Branch.Company.Id == manufacturing_ReportModel.Company_Id
                && i.Main_Branch.Id == manufacturing_ReportModel.Main_Branch_Id
             ).Where
             (
                d => d.Creation_Date >= manufacturing_ReportModel.FromDate
                && d.Creation_Date <= manufacturing_ReportModel.ToDate
              ).ToList();
            foreach (var item in FilteringProcess)
            {
                FinalResult.Manufacturing_ProcessesList.Add(new Manufacturing_Report()
                {
                    Manufacturing_Date = item.Creation_Date,
                    Quantity = item.Quantity                    
                });
                TotalQuantity += item.Quantity;
            }
            FinalResult.NomberOfProcess = FilteringProcess.Count;
            FinalResult.TotalQuantity = TotalQuantity;

            return FinalResult;
        }
    }
}
