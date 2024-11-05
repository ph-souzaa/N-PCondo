using Condo.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Condo.Api.Common
{
    public class CustomUserClaimsPrincipalFactory(
    UserManager<User> userManager,
    RoleManager<IdentityRole<long>> roleManager,
    IOptions<IdentityOptions> optionsAccessor) : UserClaimsPrincipalFactory<User, IdentityRole<long>>(userManager, roleManager, optionsAccessor)
    {

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            var userRoles = await userManager.GetRolesAsync(user);
            if (!userRoles.Contains("Usuario"))
            {
                await userManager.AddToRoleAsync(user, "Usuario");
            }

            return principal;
        }
    }
}
