using System.ComponentModel.DataAnnotations;
using Terabaitas.Models;

namespace Terabaitas.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone]
        [StringLength(9, MinimumLength = 9)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string City { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        public static implicit operator UserModel(UserRegisterViewModel user)
        {
            return new UserModel()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Address = user.Address,
                ZipCode = user.ZipCode
            };
        }
    }
}
