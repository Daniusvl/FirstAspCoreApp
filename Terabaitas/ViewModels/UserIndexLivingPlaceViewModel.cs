using System.ComponentModel.DataAnnotations;

namespace Terabaitas.ViewModels
{
    public class UserIndexLivingPlaceViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string City { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }
    }
}
