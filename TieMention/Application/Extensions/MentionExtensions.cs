using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Mentions;

namespace TieMention.Application.Extensions;

public static class MentionExtensions
{
    public static MentionGetByIdDto ToMentionGetByIdDto(this Mention mention)
    {
        return new MentionGetByIdDto
        {
            MentionedPiece = mention.MentionedPiece,
            MentioningPiece = mention.MentioningPiece,
            Description = mention.Description,
            IsApproved = mention.IsApproved
        };
    }
}
