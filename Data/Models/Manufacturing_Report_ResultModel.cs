using EL_KooD_API.Data.Domain;

namespace EL_KooD_API.Data.Models
{
    public class Manufacturing_Report_ResultModel
    {
        public List<Manufacturing_Report> Manufacturing_ProcessesList { get; set; } = new();
        public float TotalQuantity { get; set; }
        public int NomberOfProcess { get; set; }
    }
    public class Manufacturing_Report
    {
        public float Quantity { get; set; }
        public DateTime Manufacturing_Date { get; set; }
    }
}
