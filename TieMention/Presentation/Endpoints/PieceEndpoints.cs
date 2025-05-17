using MediatR;
using Microsoft.AspNetCore.Mvc;
using TieMention.Application.Pieces.Queries;
using TieMention.Application.Pieces.Commands;

namespace TieMention.Presentation.Endpoints;

public static class PieceEndpoints
{
    public static void MapPieceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/piece");

        group.MapGet("/{id}", async (Guid id, IMediator mediator) =>
        {
            var piece = await mediator.Send(new GetPieceQuery(id));
            return piece is not null ? Results.Ok(piece) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] CreatePieceCommand command, IMediator mediator) =>
        {
            var piece = await mediator.Send(command);
            return Results.Created($"/api/piece/{piece.Id}", piece);
        });

        group.MapGet("/list", async ([AsParameters] GetPiecesQuery query, IMediator mediator) =>
        {
            var piece = await mediator.Send(query);
            return piece is not null ? Results.Ok(piece) : Results.NotFound();
        });

    }
}