using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;

namespace TieMention.Application.Extensions;

public static class PieceExtensions
{
    public static PieceDetailsDto ToPieceDetailsDto(this Piece piece)
    {
        return new PieceDetailsDto
        {
            Description = piece.Description,
            ReleaseYear = piece.ReleaseYear,
            Name = piece.Name
        };
    }
}
