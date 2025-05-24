namespace TieMention.Domain.Entities;

public class Piece
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid Category { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string ReleaseYear { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
}
