using MediatR;
using Microsoft.AspNetCore.Mvc;
using TieMention.Application.Categories.Queries;

namespace TieMention.Presentation.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/category");

        _ = group.MapGet(
            "/",
            async (IMediator mediator) =>
            {
                var category = await mediator.Send(new GetCategoriesQuery());
                return category is not null ? Results.Ok(category) : Results.NotFound();
            }
        );
    }
}
