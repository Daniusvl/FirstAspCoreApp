using Microsoft.AspNetCore.Identity;

namespace Terabaitas.Models
{
    public class UserModel : IdentityUser
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
