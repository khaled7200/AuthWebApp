using Microsoft.AspNetCore.Identity;

namespace AuthWebApplication.Models
{
    public class AppUser:IdentityUser
    {
        public string ImagePath { get; set; } = "Avatar.jpg";
        
    }
}
