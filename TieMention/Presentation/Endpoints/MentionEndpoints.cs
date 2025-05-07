using MediatR;
using Microsoft.AspNetCore.Mvc;
using TieMention.Application.Mentions.Commands;
using TieMention.Application.Mentions.Queries;

namespace TieMention.Presentation.Endpoints;

public static class MentionEndpoints
{
    public static void MapMentionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/mentions");

        group.MapGet("/{id}", async (int id, IMediator mediator) =>
        {
            var mention = await mediator.Send(new GetMentionQuery(id));
            return mention is not null ? Results.Ok(mention) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] CreateMentionCommand command, IMediator mediator) =>
        {
            var mention = await mediator.Send(command);
            return Results.Created($"/api/mentions/{mention.Id}", mention);
        });
    }
}