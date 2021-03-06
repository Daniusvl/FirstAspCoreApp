﻿using Microsoft.AspNetCore.Identity;

namespace Terabaitas.Core.Domain
{
    public class User : IdentityUser
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
