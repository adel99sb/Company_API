using EL_KooD_API.Data.Domain;
using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Models
{
    public class Main_BranchModel
    {        
        public Guid Id { get; }
        [Required(ErrorMessage = "This Filed is Required")]
        [StringLength(50, ErrorMessage = "you can not use more than 50 letter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Guid Company_Id { get; set; }
    }
}
