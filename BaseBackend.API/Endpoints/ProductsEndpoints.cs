using BaseBackend.API.Contracts.Products;
using BaseBackend.Application.Interfaces.Services;

namespace BaseBackend.API.Endpoints;

public static class ProductsEndpoints
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("getallproducts", GetAll);

        return app;
    }

    private static async Task<IResult> GetAll(IProductsService productsService)
    {
        var products = await productsService.GetAllProducts();

        var response = products.Select(p => 
            new ProductsResponse(p.Id, p.Name, p.Price, p.Description));

        return Results.Ok(response);
    }
}