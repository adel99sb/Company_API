using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Domain
{
    public class Company
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="This Filed is Required")]
        [StringLength(50, ErrorMessage = "you can not use more than 50 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Activity { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Point Location { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime Creation_Date { get; set; }
    }
}
