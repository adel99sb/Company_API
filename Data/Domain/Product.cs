using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Domain
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "This Filed is Required")]
        [StringLength(50, ErrorMessage = "you can not use more than 50 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [StringLength(20, ErrorMessage = "you can not use more than 50 letter")]
        public string Type { get; set; }
    }
}
