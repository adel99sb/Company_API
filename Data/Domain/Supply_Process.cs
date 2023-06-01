using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Domain
{
    public class Supply_Process
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "This Filed is Required")]
        [Range(0, float.MaxValue, ErrorMessage = "you can not use negative value")]
        public float Quantity { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime Creation_Date { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Secondary_Branch Secondary_Branch { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Manufacturing_Process Manufacturing_Process { get; set; }
    }
}
