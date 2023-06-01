using Microsoft.AspNetCore.Identity;
using System;

namespace WebApplicationIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateofBirth { get; set; }
    }
}
    