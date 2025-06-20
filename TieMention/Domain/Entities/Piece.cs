namespace TieMention.Domain.Entities;

public class Piece : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid Category { get; set; }

    public string ReleaseYear { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public static Piece Create(string name, string description, Guid category, string releaseYear, string slug)
    {
        return new Piece
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Category = category,
            ReleaseYear = releaseYear,
            Slug = slug,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public static string GenerateSlug(string name, string releaseYear)
    {
        return $"{name.ToSlug()}-{releaseYear}";
    }
}
