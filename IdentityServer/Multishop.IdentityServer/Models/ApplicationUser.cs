using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace Multishop.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
#nullable enable
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }

    }
}
