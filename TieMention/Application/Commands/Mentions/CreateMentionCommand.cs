using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Commands;

public record CreateMentionCommand(
    string Description,
    Guid MentionerPieceId,
    Guid MentionedPieceId,
    string Image
) : IRequest<Mention>;
