namespace TieMention.Domain.Entities;

public class Piece : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid Category { get; set; }

    public string ReleaseYear { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
}
