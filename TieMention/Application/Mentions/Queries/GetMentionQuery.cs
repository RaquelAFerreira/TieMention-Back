using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Queries;
public record GetMentionQuery(Guid Id) : IRequest<Mention?>;