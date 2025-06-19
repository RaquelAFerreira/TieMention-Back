namespace TieMention.Domain.Entities;

public class Image : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid PieceId { get; set; }

    public Guid MentionId { get; set; }

    public int Order { get; set; }
}
