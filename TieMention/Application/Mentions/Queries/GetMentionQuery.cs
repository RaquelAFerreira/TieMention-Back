using MediatR;
using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Mentions;

namespace TieMention.Application.Mentions.Queries;

public record GetMentionQuery(Guid Id) : IRequest<MentionGetByIdDto?>;
