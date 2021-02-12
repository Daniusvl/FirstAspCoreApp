using System.ComponentModel.DataAnnotations;

namespace Terabaitas.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
    }
}