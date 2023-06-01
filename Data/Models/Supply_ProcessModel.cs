using EL_KooD_API.Data.Domain;
using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Models
{
    public class Supply_ProcessModel
    {
        public Guid Id { get; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Range(0, float.MaxValue, ErrorMessage = "you can not use negative value")]
        public float Quantity { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public DateTime Creation_Date { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Guid Secondary_Branch_Id { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        public Guid Manufacturing_Process_Id { get; set; }
    }
}
