namespace Condo.Api.Common
{
    public interface IEndPoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
