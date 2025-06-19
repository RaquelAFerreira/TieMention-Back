namespace TieMention.Domain.Entities;

public class Mention : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public Guid MentionerPiece { get; set; }

    public Guid MentionedPiece { get; set; }

    public bool IsApproved { get; set; } = false;

    public string Slug { get; set; } = string.Empty;
}
