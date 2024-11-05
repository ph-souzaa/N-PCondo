using Condo.Api.Common;
using Condo.Core.Models;
using Condo.Core.Responses;
using Microsoft.AspNetCore.Identity;

namespace Condo.Api.EndPoints.Identity
{
    public class LogoutEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("/logout", HandleAsync)
                .RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok(Response<string>.SuccessMessage(null, "Deslogado com sucesso."));
        }
    }
}
