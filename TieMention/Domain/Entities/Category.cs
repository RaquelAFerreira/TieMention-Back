namespace TieMention.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
