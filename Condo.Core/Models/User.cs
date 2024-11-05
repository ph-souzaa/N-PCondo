using Microsoft.AspNetCore.Identity;

namespace Condo.Core.Models
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; } = string.Empty;
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
