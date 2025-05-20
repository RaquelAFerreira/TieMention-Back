namespace TieMention.Application.Dtos.Pieces;

public class PieceGetFilterDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Slug { get; set; } = default!;

    public string Image { get; set; } = default!;

    public string ReleaseYear { get; set; } = string.Empty;
}