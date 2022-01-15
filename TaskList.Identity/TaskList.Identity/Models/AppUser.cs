using Microsoft.AspNetCore.Identity;

namespace TaskList.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            FirstName = "New User";
            LastName = "New User";
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
