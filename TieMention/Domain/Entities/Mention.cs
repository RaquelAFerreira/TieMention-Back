namespace TieMention.Domain.Entities;

public class Mention : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public Guid MentionerPieceId { get; set; }

    // public Mention MentionerPiece { get; set; }

    public Guid MentionedPieceId { get; set; }

    // public Mention MentionedPiece { get; set; }

    public bool IsApproved { get; set; } = false;

    public string Slug { get; set; } = string.Empty;
}
