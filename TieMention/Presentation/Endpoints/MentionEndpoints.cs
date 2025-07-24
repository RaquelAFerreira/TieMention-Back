using MediatR;
using Microsoft.AspNetCore.Mvc;
using TieMention.Application.Mentions.Commands;
using TieMention.Application.Mentions.Queries;
using TieMention.Application.Pieces.Queries;

namespace TieMention.Presentation.Endpoints;

public static class MentionEndpoints
{
    public static void MapMentionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/mention");

        group.MapGet(
            "/{id}",
            async (string id, IMediator mediator) =>
            {
                var mention = await mediator.Send(new GetMentionDetailsQuery(id));
                return mention is not null ? Results.Ok(mention) : Results.NotFound();
            }
        );

        group.MapPost(
            "/",
            async ([FromBody] CreateMentionCommand command, IMediator mediator) =>
            {
                var mention = await mediator.Send(command);
                return Results.Created($"/api/mention/{mention.Id}", mention);
            }
        );
    }
}
