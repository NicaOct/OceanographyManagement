using Microsoft.AspNetCore.Identity;

namespace OceanographyManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string Institution { get; set; }
    }
}