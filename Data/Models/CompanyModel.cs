using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Models
{
    public class CompanyModel
    {        
        public CompanyModel(Guid guid)
        {
            id= guid;
        }
        public CompanyModel() { }
        public Guid id { get; }
        [Required(ErrorMessage = "This Filed is Required")]
        [StringLength(50, ErrorMessage = "you can not use more than 50 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Activity { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Location Location { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime Creation_Date { get; set; }
    }
}
