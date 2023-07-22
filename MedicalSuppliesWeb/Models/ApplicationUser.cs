using Microsoft.AspNetCore.Identity;
using MedicalSuppliesData.Contracts;

namespace MedicalSuppliesWeb.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }
    }
}
