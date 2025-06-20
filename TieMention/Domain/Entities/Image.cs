namespace TieMention.Domain.Entities;

public class Image : BaseEntity
{
    public string Content { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid PieceId { get; set; }

    public Guid MentionId { get; set; }

    public int Order { get; set; }

    public static Image Create(
        string content,
        Guid pieceId,
        Guid mentionId,
        string description,
        int order
    )
    {
        return new Image
        {
            Id = Guid.NewGuid(),
            Content = content,
            PieceId = pieceId,
            MentionId = mentionId,
            Description = description,
            Order = order,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}
