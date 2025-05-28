namespace TieMention.Domain.Entities;

public class Mention
{
    public Guid Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid MentionerPiece { get; set; }

    public Guid MentionedPiece { get; set; }

    public bool IsApproved { get; set; } = false;

    public string Slug { get; set; } = string.Empty;
}
