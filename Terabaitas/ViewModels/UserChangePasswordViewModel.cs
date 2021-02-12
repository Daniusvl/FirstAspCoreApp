using System.ComponentModel.DataAnnotations;

namespace Terabaitas.ViewModels
{
    public class UserChangePasswordViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        [Compare("ConfirmNewPassword")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name = "ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
