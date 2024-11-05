
using Condo.Api.Common;
using Condo.Api.EndPoints;

namespace Condo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddConfiguration();
            builder.AddSecurity();
            builder.AddDataContexts();
            builder.AddDocumentation();
            builder.AddServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.ConfigureDevEnvironment();

            app.UseCors("AllowFrontend");

            app.UseSecurity();
            app.MapEndPoints();

            app.Run();
        }
    }
}
