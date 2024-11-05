using Condo.Api.Common;
using Condo.Api.EndPoints.Identity;

namespace Condo.Api.EndPoints
{
    public static class EndPoint
    {
        public static void MapEndPoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/identity")
                .WithTags("Identity")
                .MapEndpoint<LoginUserEndpoint>()
                .MapEndpoint<RegisterUserEndpoint>()
                .MapEndpoint<LogoutEndPoint>();

        }

        private static IEndpointRouteBuilder MapEndpoint<TEndPoint>(this IEndpointRouteBuilder app)
            where TEndPoint : IEndPoint
        {
            TEndPoint.Map(app);
            return app;
        }
    }
}
