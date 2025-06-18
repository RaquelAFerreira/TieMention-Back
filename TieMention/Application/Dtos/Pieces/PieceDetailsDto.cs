namespace TieMention.Application.Dtos.Pieces;

public class PieceDetailsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Slug { get; set; } = default!;

    public string Image { get; set; } = default!;

    public string ReleaseYear { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

}