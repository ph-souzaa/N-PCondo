using Condo.Api.Common;
using Condo.Core.Models;
using Condo.Core.Requests.Identity;
using Condo.Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Api.EndPoints.Identity
{
    public class RegisterUserEndpoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/register", HandleAsync)
                .WithName("RegisterUser")
                .WithDescription("Metodo para se registrar na aplicação");

        private static async Task<IResult> HandleAsync([FromBody] RegisterUserRequest request, UserManager<User> userManager)
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Nome) ||
                string.IsNullOrWhiteSpace(request.Celular))
            {
                return Results.BadRequest("Todos os campos são obrigatórios.");
            }

            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Nome,
                PhoneNumber = request.Celular
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return Results.Ok(Response<string>.SuccessMessage(null,"Usuário registrado com sucesso."));
            }

            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return Results.BadRequest(Response<string>.Error(errors));
        }
    }
}
