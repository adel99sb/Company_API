using EL_KooD_API.Data.Domain;
using EL_KooD_API.Data.Models;

namespace EL_KooD_API.Infrastructure.Contracts
{
    public interface IManufacturing_ProcessRepository : IGenericRepository<Manufacturing_Process>
    {
        public Task<Manufacturing_Report_ResultModel> GetManufacturing_Report_WithDate(Manufacturing_ReportModel manufacturing_ReportModel);
    }
}
