using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Models
{
    public class Manufacturing_ReportModel
    {
        [Required(ErrorMessage = "This Filed is Required")]
        public Guid Company_Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Guid Main_Branch_Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime ToDate { get; set; }
    }
}
