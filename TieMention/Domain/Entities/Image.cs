namespace TieMention.Domain.Entities;

public class Image
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid PieceId { get; set; }

    public string MentionId { get; set; } = string.Empty;

    public int Order { get; set; }
}
