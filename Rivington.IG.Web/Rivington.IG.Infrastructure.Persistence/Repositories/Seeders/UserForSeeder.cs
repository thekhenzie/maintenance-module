using Rivington.IG.Infrastructure.Security;

namespace Rivington.IG.Infrastructure.Persistence.Seeders
{
    public class UserForSeeder
    {
        public ApplicationUser AppUser { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}