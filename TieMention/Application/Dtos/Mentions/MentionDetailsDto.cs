using TieMention.Application.Dtos.Pieces;

namespace TieMention.Application.Dtos.Mentions;

public class MentionDetailsDto
{
    public Guid Id { get; set; }

    public string Image { get; set; } = default!;

    public string Description { get; set; } = default!;

    public PieceDetailsDto MentionerPiece { get; set; } = default!;

    public PieceDetailsDto MentionedPiece { get; set; } = default!;
}
