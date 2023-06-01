using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Domain
{
    public class Main_Branch
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "This Filed is Required")]
        [StringLength(50, ErrorMessage = "you can not use more than 50 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Company Company { get; set; }
    }
}
