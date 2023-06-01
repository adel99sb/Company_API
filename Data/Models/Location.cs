using System.ComponentModel.DataAnnotations;

namespace EL_KooD_API.Data.Models
{
    public class Location
    {
        [Required(ErrorMessage = "This Filed is Required")]
        [Range(-90,90 , ErrorMessage = "you can only use values between -90 & 90")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "This Filed is Required")]
        [Range(-180, 180, ErrorMessage = "you can only use values between -180 & 180")]
        public double Longitude { get; set; }
        public int SIRD { get; } = 4326;
    }
}