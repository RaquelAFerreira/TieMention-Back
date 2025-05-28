namespace TieMention.Application.Dtos.Pieces;

public class PieceGetMentionDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Image { get; set; } = default!;

    public string MentionSlug { get; set; } = default!;

    public string ReleaseYear { get; set; } = string.Empty;
}