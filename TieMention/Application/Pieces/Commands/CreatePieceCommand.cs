using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Pieces.Commands;

public record CreatePieceCommand(
    string Description,
    string Name,
    Guid Category,
    string ReleaseYear
) : IRequest<Piece>;
