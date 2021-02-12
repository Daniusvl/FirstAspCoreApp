using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Terabaitas.Models;

namespace Terabaitas.ViewModels
{
    public class ManagerRegisterViewModel
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
        [StringLength(16, MinimumLength = 4)]
        public string SecretKey { get; set; }

        public static implicit operator User(ManagerRegisterViewModel user)
        {
            return new User()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}
