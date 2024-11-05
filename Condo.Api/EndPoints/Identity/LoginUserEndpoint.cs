using Condo.Api.Common;
using Condo.Core.Models;
using Condo.Core.Requests.Identity;
using Condo.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Api.EndPoints.Identity
{
    public class LoginUserEndpoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/login", Handle)
                .WithName("LoginUser")
                .WithDescription("Método para logar na aplicação");

        private static async Task<IResult> Handle([FromBody] LoginUserRequest request, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return Results.BadRequest(Response<string>.Error( "Email e senha são obrigatórios."));
            }

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Results.BadRequest(Response<string>.Error("Credenciais inválidas."));
            }

            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);

            if (result.Succeeded)
            {
                return Results.Ok(Response<string>.SuccessMessage(null, "Login realizado com sucesso."));
            }

            return Results.BadRequest(Response<string>.Error("Falha no login. Verifique suas credenciais."));
        }
    }
}
