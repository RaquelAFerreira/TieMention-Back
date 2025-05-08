using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Dtos.Mentions;

public class MentionGetDto
{
    public string Description { get; set; } = string.Empty;

    public Guid MentioningPiece { get; set; }

    public Guid MentionedPiece { get; set; }

    public bool IsApproved { get; set; } = false;
}
