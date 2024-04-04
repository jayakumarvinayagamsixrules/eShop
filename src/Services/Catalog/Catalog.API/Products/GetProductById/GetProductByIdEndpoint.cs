
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductsById;

//public record GetProductById(Guid id);
public record GetProductByIdResponse(Product Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>{
            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        });
    }
}