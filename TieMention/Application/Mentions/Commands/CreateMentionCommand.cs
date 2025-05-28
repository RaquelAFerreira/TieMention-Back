using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Commands;

public record CreateMentionCommand(
    string Description,
    bool IsApproved,
    Guid MentionerPiece,
    Guid MentionedPiece
) : IRequest<Mention>;
