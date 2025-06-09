using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Commands;

public record CreateMentionCommand(
    string Description,
    Guid MentionerPiece,
    Guid MentionedPiece,
    string Image
) : IRequest<Mention>;
