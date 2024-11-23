using BaseBackend.API.Endpoints;

namespace BaseBackend.APi.Extensions;

public static class ApiExtensions
{
    public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapUsersEndpoints();
        app.MapProductsEndpoints();
        //app.MapCategoriesEndpoints();
    }
}